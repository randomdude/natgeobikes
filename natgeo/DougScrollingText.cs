using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace DougScrollingText
{
    /// <summary>
    /// Summary description for DougScrollingTextCtrl.
    /// </summary>
    public class DougScrollingTextCtrl : Control
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        /// <summary>
        /// Timer for text animation
        /// </summary>
        private readonly Timer _timer;

        /// <summary>
        /// Text to be displayed in the control
        /// </summary>
        private string sScrollText;

        /// <summary>
        /// The size, in pixels, of the entire text string, as rendered
        /// </summary>
        private SizeF textSize;

        /// <summary>
        /// This will notify us when our input file has changed
        /// </summary>
        private readonly FileSystemWatcher fileWatcher;
        
        /// <summary>
        /// How far through the message we are
        /// </summary>
        private int scrollOffsetPixels = 0;

        /// <summary>
        /// Add member variables.
        /// </summary>
        public DougScrollingTextCtrl()
        {
            _timer = new Timer();

            // Set the timer speed and properties.
            _timer.Interval = 100;
            _timer.Tick += Animate;
            _timer.Enabled = true;

            fileWatcher = new FileSystemWatcher
            {
                Path = Environment.CurrentDirectory,
                // FIXME: are all these flags neccessary?
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*.txt"
            };
            fileWatcher.Changed += m_updateScrollingMessage;
            // Begin watching.
            fileWatcher.EnableRaisingEvents = true;
        }

        /// <summary>
        /// Sets up the animation of the text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Animate( object sender, EventArgs e )
        {
            if (sScrollText == null)
            {
                scrollOffsetPixels = -ClientRectangle.Width;
                sScrollText = Text;
                using (Font myFont = new Font(Font.Name, (ClientRectangle.Height * 3) / 4, Font.Style, GraphicsUnit.Pixel))
                {
                    using (BufferedGraphics gfx = BufferedGraphicsManager.Current.Allocate(this.CreateGraphics(), ClientRectangle))
                    {
                        textSize = gfx.Graphics.MeasureString(sScrollText, myFont);
                    }
                }
            }

            scrollOffsetPixels += 10;

            // Reset the scroller when the text is not visible
            if (scrollOffsetPixels > textSize.Width)
                scrollOffsetPixels = -ClientRectangle.Width;
            
            Invalidate();
        }
        
        /// <summary>
        /// If/when the string text is changed, I need to update the sScrollText string
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged( EventArgs e )
        {
            sScrollText = null;

            base.OnTextChanged( e );
        }

        public void SetText(string newText)
        {
            // Updates should be done from the UI thread
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetText), newText);
                return;
            }

            Text = newText;
        }

        private void m_updateScrollingMessage(object sender, FileSystemEventArgs e)
        {
            using (StreamReader sr = new StreamReader("ReadMessages.txt"))
            {
                while (!sr.EndOfStream)
                {
                    SetText(sr.ReadToEnd());
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                fileWatcher.Dispose();
                _timer.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Paint the DougScrollingTextCtrl
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint( PaintEventArgs pe )
        {
            if (textSize.Height == 0.0f)
                return;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRectangle(ClientRectangle);

                using (SolidBrush bgBrush = new SolidBrush(Color.White))
                {
                    using (PathGradientBrush myBrush = new PathGradientBrush(path))
                    {
                        myBrush.CenterColor = ForeColor;
                        myBrush.SurroundColors = new Color[] {Color.Transparent };
                        // Allow some space for descenders.
                        using (Font myFont = new Font(Font.Name, textSize.Height * 0.75f , Font.Style, GraphicsUnit.Pixel))
                        {
                            using (Graphics dblBuf = CreateGraphics())
                            {
                                using (BufferedGraphics gfx = BufferedGraphicsManager.Current.Allocate(dblBuf, ClientRectangle))
                                {
                                    gfx.Graphics.FillRectangle(bgBrush, ClientRectangle);
                                    gfx.Graphics.DrawString(sScrollText, myFont, myBrush, -scrollOffsetPixels, 0);
                                    gfx.Render(pe.Graphics);
                                }
                            }
                            base.OnPaint(pe);
                        }
                    }
                }
            }
        }
    }
}
