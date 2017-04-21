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
    public partial class bikeDetail : UserControl
    {
        public Action<float> onOverrideValueChange;
        public Action<float> onOffsetChange;

        public bikeDetail()
        {
            InitializeComponent();
        }

        public void setBike(bicycle bikeIn)
        {
            groupBox1.Text = String.Format("Bicycle {0}", bikeIn.bikeIndex);
            txtVoltageOffset.Text = bikeIn.voltageOffset.ToString();
            txtVAndP.Text = bikeIn.lastPowerReadingA + " A , " + bikeIn.lastPowerReadingW + " W";
            txtRawValue.Text = bikeIn.lastRawValue.ToString();
        }

        private void barValOverride_Scroll(object sender, EventArgs e)
        {
            onOverrideValueChange.Invoke(barValOverride.Value / 5.0f);
        }

        private void txtVoltageOffset_TextChanged(object sender, EventArgs e)
        {
            float res;
            if (!float.TryParse(txtVoltageOffset.Text, out res))
                return;
            onOffsetChange.Invoke(res);
        }
    }
}
