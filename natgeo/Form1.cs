using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using LabJack.LabJackUD;

namespace natgeo
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The things the people are on
        /// </summary>
        private readonly bicycle[] bicycles;

        /// <summary>
        /// The controls displaying individual statistics
        /// </summary>
        private readonly List<cycler> bicycleControls = new List<cycler>();

        readonly frmUI powerMeterForm = new frmUI();

        public Form1()
        {
            InitializeComponent();

            // Load our bicycles from our application config (user.config), and then init them, which will configure the LJ ready for use.
            bicycles = new bikeSettings().bikes.ToArray();
            if (bicycles.Length == 0)
            {
                int bikeCount = 20;
                bicycles = new bicycle[bikeCount];
                for (int index = 0; index < bikeCount; index++)
                {
                    bicycles[index] = new bicycle(index + 1, "Test", 0);
                }
            }

            int n = 0;
            foreach (bicycle bike in bicycles)
            {
                bike.bikeIndex = n++;     // FIXMEEEE
                bike.postXMLDeserialisation();
            }

            // Wire up events
            foreach (bicycle bike in bicycles)
                bike.onNewPowerReading = updateBikeView;

            foreach (bicycle bike in bicycles)
            {
                powerMeterForm.addBicycle(bike);
                ctlBargraph1.addBicycle(bike);
            }

            // Now the bicycles are configured, we can start the timer, which will poll and update controls.
            // Comment this out if you have no LabJack
            //tmrPollLJ.Enabled = true;
        }

        private void resizeCyclistControls()
        {
            // Make a new cyclist control for each bicycle
            int topOfCyclistArea = dougScrollingTextCtrl1.Height + dougScrollingTextCtrl1.Top; //powerMeter1.Top + powerMeter1.Height;
            int controlCountX = 4;
            int controlCountY = (int) Math.Ceiling((double)bicycleControls.Count / (double)controlCountX);
            int gridPosX = 0;
            int gridPosY = 0;

            int cyclistCount = 0;
            foreach (cycler thisCtl in bicycleControls)
            {
                // Size the new control to fill available grid space
                thisCtl.Width = this.ClientSize.Width / controlCountX;
                thisCtl.Height = (this.ClientSize.Height - topOfCyclistArea) / controlCountY;
                // Position it on the grid. First check if this row is going to have some cells free - and if so, adjust so that the
                // leftover controls are centered.
                if (bicycleControls.Count / controlCountY != 0 && // going to have leftover cells
                    bicycleControls.Count - (gridPosY * controlCountY) <= cyclistCount + 1) // Currently placing the last row
                {
                    // Add a border either side to pad the cells into the middle.
                    int emptyCells = controlCountX - (bicycleControls.Count % controlCountX);
                    thisCtl.Left = ((this.ClientSize.Width / controlCountX) * gridPosX) + ((thisCtl.Width * emptyCells) / 2);
                }
                else
                {
                    // Just put on grid.
                    thisCtl.Left = (this.ClientSize.Width / controlCountX) * gridPosX;
                }
                // And position on grid Y-wise.
                thisCtl.Top = (((this.ClientSize.Height - topOfCyclistArea) / controlCountY) * gridPosY) + topOfCyclistArea;

                gridPosX++;
                cyclistCount++;

                if (gridPosX == controlCountX )
                {
                    gridPosX = 0;
                    gridPosY = gridPosY + 1;
                }
            }
        }

        private void updateBikeView(bicycle sender, DateTime timestamp)
        {
            // Update total power
            double totalPower = bicycles.Sum(x => x.lastPowerReadingW);
            lblTotalCurrent.Text = (int)totalPower +" W";
            //powerMeter1.value = (int)totalPower;

            // update the fastest bicycle
            double highest = bicycles.Max(x => x.lastPowerReadingA);
            foreach (cycler thisBike in bicycleControls)
            {
                if (thisBike.cyclistPowerSource.lastPowerReadingA == highest && !thisBike.isFastest)
                    thisBike.isFastest = true;
                if (thisBike.cyclistPowerSource.lastPowerReadingA != highest &&  thisBike.isFastest)
                    thisBike.isFastest = false;
            }
        }

        private void tmrPollLJ_Tick(object sender, EventArgs e)
        {
            // Read from each bicycle. Note that we want to do this in a single "GoOne" call for each labjack, otherwise things will
            // be much slower, since there'll be more USB requests. Because of this, we operate over each labjack individually, grouping
            // by handle.
            foreach (int thisLJHnd in bicycles.Select(x => x.labjackHandle))
            {
                // Get bikes on this labjack. Note that we .ToArray because we must ensure ordering does not change before we .GetResult
                // later on.
                bicycle[] bikesToPoll = bicycles.Where(x => x.labjackHandle == thisLJHnd).ToArray();

                // and add a request for each
                foreach (bicycle thisBike in bikesToPoll)
                {
                    // Specify negative channel as 32, which (on the U3) will select the special 0-3.6v range
                    LJUD.AddRequest(thisBike.labjackHandle, LJUD.IO.GET_AIN_DIFF, thisBike.FIOChannel, 0, 32, 0);
                }

                // Now we can poll this LJ
                LJUD.GoOne(thisLJHnd);

                // and get our results, which are in the same order as the bikesToPoll array.
                foreach (bicycle thisBike in bikesToPoll)
                {
                    double newVal = 0;
                    LJUD.GetResult(thisBike.labjackHandle, LJUD.IO.GET_AIN_DIFF, thisBike.FIOChannel, ref newVal);
                    thisBike.onRawData(newVal);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctlBargraph1.Parent = pbBg;
            ctlBargraph1.Font = dougScrollingTextCtrl1.Font;
            pboxTopLeftLogo.Parent = this;
            powerMeterForm.onNewScrollText += (x) => dougScrollingTextCtrl1.SetText(x);
            powerMeterForm.Show();
            pbBg.Width = this.ClientRectangle.Width;
            pbBg.Height = this.ClientRectangle.Height;
            pbBg.SendToBack();
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pbBg.Width = this.ClientRectangle.Width;
            pbBg.Height = this.ClientRectangle.Height;
            //resizeCyclistControls();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pboxTopLeftLogo_Paint(object sender, PaintEventArgs e)
        {
            //Bitmap logo = Properties.Resources.NAT_Geo_Logo_EarthDayRunSolid;
            //logo.MakeTransparent(Color.Transparent);
            //e.Graphics.DrawImage(logo, ClientRectangle);
        }

        private void tmrUpdateGraph_Tick(object sender, EventArgs e)
        {
            // FIXME OMG
            ctlBargraph1.Top = label1.Height + label1.Top;
            ctlBargraph1.Left = 10;
            ctlBargraph1.Width = ClientRectangle.Width - (ctlBargraph1.Left * 2);
            ctlBargraph1.Height = (ClientRectangle.Height - ctlBargraph1.Top - 10) - (this.Height - pwrMeterOverall.Top);

            pwrMeterOverall.value = (int) bicycles.Sum(x => x.lastPowerReadingW);
            pwrMeterOverall.maxValue = 1000;

            ctlBargraph1.redrawTimer();
        }
    }
}
