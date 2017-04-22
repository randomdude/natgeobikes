using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace natgeo
{
    public partial class ctlBargraph : PictureBox
    {
        private readonly List<bicycle> bikes = new List<bicycle>();

        private const double maxPowerExpectedPerCyclist = 500.0;

        private Bitmap lastRender = null;

        private bool topThreeFlash = false;

        private bool putLabelsAtTop = false;

        public ctlBargraph()
        {
            InitializeComponent();
            
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
//            SetStyle(ControlStyles.DoubleBuffer, true);
//            SetStyle(ControlStyles.UserPaint, true);
//            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.BackColor = Color.Transparent;
        }

        public void addBicycle(bicycle toAdd)
        {
            bikes.Add(toAdd);
            //toAdd.onNewPowerReading += (a,b) => this.Invalidate();
            //this.Invalidate();
        }

        public void redrawTimer()
        {
            topThreeFlash = !topThreeFlash;

            lastRender = new Bitmap(ClientSize.Width, ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics tmpGfx = Graphics.FromImage(lastRender))
            {
                renderToBuffer(tmpGfx);
            }
            lastRender.MakeTransparent(Color.White);
            //using (Graphics dblBuf = CreateGraphics())
            //using (BufferedGraphics gfx = BufferedGraphicsManager.Current.Allocate(dblBuf, ClientRectangle))
            //{
                //gfx.Graphics.Clear(Color.Transparent);
                //gfx.Graphics.DrawImage(lastRender, 0, 0);
                //e.Graphics.DrawImage(lastRender, 0, 0);
                //gfx.Render(e.Graphics);

                this.Image = lastRender;
                this.SizeMode = PictureBoxSizeMode.StretchImage;
            
            //this.BackColor = Color.Transparent;
            //}
        }

        private void ctlBargraph_Paint(object sender, PaintEventArgs e)
        {
            /*
            }
            else
            {
                if (lastRender == null)
                    return;

                //using (Graphics dblBuf = CreateGraphics())
                //using (BufferedGraphics gfx = BufferedGraphicsManager.Current.Allocate(dblBuf, ClientRectangle))
                {
                    //gfx.Graphics.Clear(Color.White);
                    //gfx.Graphics.DrawImage(lastRender, 0, 0);
                    //gfx.Render(e.Graphics);
                    //this.Image = lastRender;
                    //this.BackColor = Color.Transparent;
                }
            }*/
        }

        private void renderToBuffer(Graphics gfx)
        {
            if (bikes.Count == 0)
                return;

            int[] topThreeBikes = bikes.OrderByDescending(x => x.lastPowerReadingW).Select(x => x.bikeIndex).Take(3).ToArray();

            int bottomMargin = ClientRectangle.Height / 10;

            int barSpacing = ClientRectangle.Width / bikes.Count;
            int barWidth = barSpacing;
            int barMaxHeight = ClientRectangle.Height - bottomMargin;

            int barLeft = 0;
            gfx.Clear(Color.White);
            using (SolidBrush textBrush = new SolidBrush(Color.Black))
            using (SolidBrush barBrush = new SolidBrush(Color.Brown))
            {
                foreach (bicycle thisBike in bikes.OrderBy(x => x.bikeIndex))
                {
                    switch (thisBike.bikeIndex % 3)
                    {
                        case 0:
                            barBrush.Color = ColorTranslator.FromHtml("#20A4F3");
                            break;
                        case 1:
                            barBrush.Color = ColorTranslator.FromHtml("#2EC4B6");
                            break;
                        case 2:
                            barBrush.Color = ColorTranslator.FromHtml("#FF3366");
                            break;
                    }
                    int barHeight = (int) (barMaxHeight * (thisBike.lastPowerReadingW / maxPowerExpectedPerCyclist));
                    int barTop = ClientRectangle.Height - barHeight - bottomMargin;
                    // Draw the bar itself
                    if (topThreeBikes.Contains(thisBike.bikeIndex))
                    {
                        if (topThreeFlash)
                            barBrush.Color = Color.FromArgb((barBrush.Color.ToArgb() ^ 0x00ffffff));
                    }
                    gfx.FillRectangle(barBrush, barLeft, barTop, barWidth, barHeight);

                    // Axis labels are always bold.
                    FontStyle axisStyle = Font.Style | FontStyle.Bold;

                    using (Font axisLabelFont = new Font(Font.Name, bottomMargin * 0.75f, axisStyle, GraphicsUnit.Pixel))
                    {
                        // Now draw the label on each bar. Take care to clamp so it is always visible, even when the bar is tiny or huge.
                        string txtlabel = thisBike.lastPowerReadingW.ToString("F0");
                        if (txtlabel.Length == 0)
                            txtlabel = "0";

                        using (Font valueFont = new Font(Font.Name, (barWidth * 0.75f * 2) / txtlabel.Length, Font.Style, GraphicsUnit.Pixel))
                        {
                            SizeF valueTextSize = gfx.MeasureString(txtlabel, valueFont);

                            // Clamp position if neccessary
                            barTop = (int) (barTop - valueTextSize.Height);
                            if (barTop < 0 || putLabelsAtTop)
                                barTop = 0;
                            if (barTop > barMaxHeight - valueTextSize.Height)
                                barTop = barMaxHeight;

                            // Draw the power value itself
                            gfx.DrawString(txtlabel, valueFont, textBrush, barLeft, barTop);

                            // Also draw the legend label, taking care to center-align it
                            string axisLabelText = thisBike.bikeIndex.ToString();
                            SizeF axisLabelSize = gfx.MeasureString(axisLabelText, axisLabelFont);
                            gfx.DrawString(axisLabelText, axisLabelFont, textBrush, (barLeft + (barWidth / 2)) - (axisLabelSize.Width / 2), barMaxHeight);

                            barLeft += barSpacing;
                        }
                    }
                }
            }
        }

    }
}
