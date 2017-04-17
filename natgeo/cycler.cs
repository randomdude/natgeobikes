using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace natgeo
{
    public partial class cycler : UserControl
    {
        private bool _isFastest;
        private bool _isIdle;

        private bool isIdle
        {
            get { return _isIdle; }
            set
            {
                if (_isIdle != value)
                    this.Invalidate(this.ClientRectangle, true);
                _isIdle = value;
            }
        }

        public cycler()
        {
            InitializeComponent();

            powerMeter1.maxValue = 75;
        }

        public bicycle cyclistPowerSource { get; set; }

        public bool isFastest
        {
            get { return _isFastest; }
            set
            {
                if (value == _isFastest)    // make sure we don't re-load the image if we haven't changed, since perf will plummet
                    return;

                _isFastest = value;

                this.Invalidate(this.ClientRectangle, true);
            }
        }

        public void displayBicycle(bicycle sender, DateTime timestamp)
        {
            lblPower.Text = sender.lastPowerReadingA.ToString("F") + " A";
            powerMeter1.value = (int) sender.lastPowerReadingA;

            if (powerMeter1.value <= 0)
                isIdle = true;
            else
                isIdle = false;
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            if (isIdle)
                e.Graphics.DrawImage(new Bitmap(Properties.Resources.Cycling_512), lblCyclePic.ClientRectangle);
            else if (isFastest)
                e.Graphics.DrawImage(new Bitmap(Properties.Resources.Cycling_512_fastest), lblCyclePic.ClientRectangle);
            else
                e.Graphics.DrawImage(new Bitmap(Properties.Resources.Cycling_512_normal), lblCyclePic.ClientRectangle);
        }
    }
}
