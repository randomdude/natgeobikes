using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace natgeo
{
    public partial class frmUI : Form
    {
        public Action<string> onNewScrollText;

        //public Dictionary<bicycle, bikeDetail>

        private int nextBikePosY;
        private int nextBikePosX;

        public frmUI()
        {
            InitializeComponent();
            nextBikePosY = cmdSetText.Top + cmdSetText.Height;
            nextBikePosX = 0;
        }

        public void addBicycle(bicycle toAdd)
        {
            bikeDetail detail = new bikeDetail();
            detail.Top = nextBikePosY;
            detail.Left = nextBikePosX;
            Controls.Add(detail);
            detail.Show();

            toAdd.onNewPowerReading += (bike, timestamp) => detail.setBike(bike);
            detail.onOverrideValueChange += (x) => toAdd.onRawData(x);
            detail.onOffsetChange += (x) => toAdd.voltageOffset = x;

            nextBikePosX += detail.Width;
            if (nextBikePosX > detail.Width * 2)
            {
                nextBikePosX = 0;
                nextBikePosY += detail.Height;
            }
            this.Width = (detail.Width *3) + 10; // FIXME: why +10?
            this.Height = nextBikePosY + detail.Height + 100;

            detail.setBike(toAdd);
        }
        
        private void frmUI_Load(object sender, EventArgs e)
        {
        }

        private void cmdSetText_Click(object sender, EventArgs e)
        {
            onNewScrollText.Invoke(txtScrollText.Text);
        }
    }
}
