using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace natgeo
{
    public partial class powerMeter : UserControl
    {
        private int _value;
        private int _maxValue;

        public int value
        {
            get { return _value; }
            set
            {
                _value = value;
                this.Invalidate();
            }
        }

        public int maxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                this.Invalidate();
            }
        }

        public Brush bgRed { get; set; }
        public Brush bgYellow { get; set; }
        public Brush bgGreen { get; set; }
        public Brush fgRed { get; set; }
        public Brush fgYellow { get; set; }
        public Brush fgGreen { get; set; }

        public powerMeter()
        {
            bgRed = new SolidBrush(Color.DarkRed);
            bgYellow = new SolidBrush(Color.DarkGoldenrod);
            bgGreen = new SolidBrush(Color.DarkGreen);
            fgRed = new SolidBrush(Color.Red);
            fgYellow = new SolidBrush(Color.Yellow);
            fgGreen = new SolidBrush(Color.LawnGreen);

            InitializeComponent();
        }

        private void powerMeter_Load(object sender, EventArgs e)
        {

        }

        private void powerMeter_Paint(object sender, PaintEventArgs e)
        {
            int redSize = this.Width / 3;
            int yellowSize = redSize;
            int greenSize = redSize;

            // Draw BG
            e.Graphics.FillRectangle(bgRed, 0, 0, redSize, this.Height);
            e.Graphics.FillRectangle(bgYellow, redSize, 0, yellowSize, this.Height);
            e.Graphics.FillRectangle(bgGreen, redSize + yellowSize, 0, greenSize, this.Height);

            // and overwrite with FG
            if (maxValue == 0 || value == 0)
                return;

            int valueScaled = (int)((Double)this.Width * ((Double)value / (Double)maxValue));

            int redFGSize = valueScaled;
            int yellowFGSize = valueScaled - redSize;
            int greenFGSize = valueScaled - (yellowSize + redSize);

            if (redFGSize < 0)
                redFGSize = 0;
            if (yellowFGSize < 0)
                yellowFGSize = 0;
            if (greenFGSize < 0)
                greenFGSize = 0;

            if (redFGSize > redSize)
                redFGSize = redSize;
            if (yellowFGSize > yellowSize)
                yellowFGSize = yellowSize;
            if (greenFGSize > greenSize)
                greenFGSize = greenSize;

            e.Graphics.FillRectangle(fgRed, 0, 0, redFGSize, this.Height);
            if (redFGSize == redSize)
            {
                e.Graphics.FillRectangle(fgYellow, redFGSize, 0, yellowFGSize, this.Height);
                if (yellowFGSize == yellowSize)
                    e.Graphics.FillRectangle(fgGreen, redSize + yellowFGSize, 0, greenFGSize, this.Height);
            }
        }
    }
}
