namespace natgeo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTotalCurrent = new System.Windows.Forms.Label();
            this.tmrPollLJ = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pboxTopLeftLogo = new System.Windows.Forms.PictureBox();
            this.tmrUpdateGraph = new System.Windows.Forms.Timer(this.components);
            this.pbBg = new System.Windows.Forms.PictureBox();
            this.pwrMeterOverall = new natgeo.powerMeter();
            this.dougScrollingTextCtrl1 = new DougScrollingText.DougScrollingTextCtrl();
            this.ctlBargraph1 = new natgeo.ctlBargraph();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTopLeftLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlBargraph1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotalCurrent
            // 
            this.lblTotalCurrent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTotalCurrent.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCurrent.Font = new System.Drawing.Font("Verlag Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCurrent.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCurrent.Location = new System.Drawing.Point(334, 59);
            this.lblTotalCurrent.Name = "lblTotalCurrent";
            this.lblTotalCurrent.Size = new System.Drawing.Size(317, 61);
            this.lblTotalCurrent.TabIndex = 0;
            this.lblTotalCurrent.Text = "0";
            this.lblTotalCurrent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tmrPollLJ
            // 
            this.tmrPollLJ.Tick += new System.EventHandler(this.tmrPollLJ_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verlag Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(344, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 72);
            this.label1.TabIndex = 3;
            this.label1.Text = "This event needs 400W\r\nLet\'s start pedalling!\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::natgeo.Properties.Resources.NAT_Geo_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(657, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pboxTopLeftLogo
            // 
            this.pboxTopLeftLogo.BackColor = System.Drawing.Color.Transparent;
            this.pboxTopLeftLogo.Image = global::natgeo.Properties.Resources.NAT_Geo_Logo_EarthDayRunSolid;
            this.pboxTopLeftLogo.Location = new System.Drawing.Point(-112, -13);
            this.pboxTopLeftLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pboxTopLeftLogo.Name = "pboxTopLeftLogo";
            this.pboxTopLeftLogo.Size = new System.Drawing.Size(508, 190);
            this.pboxTopLeftLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxTopLeftLogo.TabIndex = 6;
            this.pboxTopLeftLogo.TabStop = false;
            this.pboxTopLeftLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.pboxTopLeftLogo_Paint);
            // 
            // tmrUpdateGraph
            // 
            this.tmrUpdateGraph.Enabled = true;
            this.tmrUpdateGraph.Interval = 1000;
            this.tmrUpdateGraph.Tick += new System.EventHandler(this.tmrUpdateGraph_Tick);
            // 
            // pbBg
            // 
            this.pbBg.BackColor = System.Drawing.Color.Transparent;
            this.pbBg.BackgroundImage = global::natgeo.Properties.Resources.NAT_Geo_LogoEarthDayRunTransparent;
            this.pbBg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBg.Location = new System.Drawing.Point(0, 0);
            this.pbBg.Name = "pbBg";
            this.pbBg.Size = new System.Drawing.Size(196, 120);
            this.pbBg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBg.TabIndex = 7;
            this.pbBg.TabStop = false;
            // 
            // pwrMeterOverall
            // 
            this.pwrMeterOverall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pwrMeterOverall.Location = new System.Drawing.Point(12, 594);
            this.pwrMeterOverall.maxValue = 0;
            this.pwrMeterOverall.Name = "pwrMeterOverall";
            this.pwrMeterOverall.Size = new System.Drawing.Size(935, 20);
            this.pwrMeterOverall.TabIndex = 8;
            this.pwrMeterOverall.value = 0;
            // 
            // dougScrollingTextCtrl1
            // 
            this.dougScrollingTextCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dougScrollingTextCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.dougScrollingTextCtrl1.Font = new System.Drawing.Font("Verlag Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dougScrollingTextCtrl1.ForeColor = System.Drawing.Color.Black;
            this.dougScrollingTextCtrl1.Location = new System.Drawing.Point(399, 12);
            this.dougScrollingTextCtrl1.Name = "dougScrollingTextCtrl1";
            this.dougScrollingTextCtrl1.Size = new System.Drawing.Size(252, 44);
            this.dougScrollingTextCtrl1.TabIndex = 2;
            this.dougScrollingTextCtrl1.Text = "National Geographic Channel Earth day Run 2017";
            // 
            // ctlBargraph1
            // 
            this.ctlBargraph1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ctlBargraph1.BackColor = System.Drawing.Color.Transparent;
            this.ctlBargraph1.Font = new System.Drawing.Font("Verlag Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlBargraph1.Location = new System.Drawing.Point(12, 195);
            this.ctlBargraph1.Name = "ctlBargraph1";
            this.ctlBargraph1.Size = new System.Drawing.Size(779, 381);
            this.ctlBargraph1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ctlBargraph1.TabIndex = 4;
            this.ctlBargraph1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(959, 626);
            this.Controls.Add(this.pwrMeterOverall);
            this.Controls.Add(this.pbBg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pboxTopLeftLogo);
            this.Controls.Add(this.dougScrollingTextCtrl1);
            this.Controls.Add(this.lblTotalCurrent);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctlBargraph1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxTopLeftLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctlBargraph1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTotalCurrent;
        private System.Windows.Forms.Timer tmrPollLJ;
        private DougScrollingText.DougScrollingTextCtrl dougScrollingTextCtrl1;
        private System.Windows.Forms.Label label1;
        private ctlBargraph ctlBargraph1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pboxTopLeftLogo;
        private System.Windows.Forms.Timer tmrUpdateGraph;
        private System.Windows.Forms.PictureBox pbBg;
        private powerMeter pwrMeterOverall;
    }
}

