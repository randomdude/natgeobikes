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
            this.powerMeter1 = new natgeo.powerMeter();
            this.dougScrollingTextCtrl1 = new DougScrollingText.DougScrollingTextCtrl();
            this.SuspendLayout();
            // 
            // lblTotalCurrent
            // 
            this.lblTotalCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCurrent.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCurrent.Font = new System.Drawing.Font("Open 24 Display St", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCurrent.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCurrent.Location = new System.Drawing.Point(142, 59);
            this.lblTotalCurrent.Name = "lblTotalCurrent";
            this.lblTotalCurrent.Size = new System.Drawing.Size(616, 61);
            this.lblTotalCurrent.TabIndex = 0;
            this.lblTotalCurrent.Text = "asdf";
            this.lblTotalCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrPollLJ
            // 
            this.tmrPollLJ.Tick += new System.EventHandler(this.tmrPollLJ_Tick);
            // 
            // powerMeter1
            // 
            this.powerMeter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.powerMeter1.Location = new System.Drawing.Point(152, 123);
            this.powerMeter1.maxValue = 0;
            this.powerMeter1.Name = "powerMeter1";
            this.powerMeter1.Size = new System.Drawing.Size(606, 18);
            this.powerMeter1.TabIndex = 1;
            this.powerMeter1.value = 10;
            // 
            // dougScrollingTextCtrl1
            // 
            this.dougScrollingTextCtrl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dougScrollingTextCtrl1.BackColor = System.Drawing.Color.Black;
            this.dougScrollingTextCtrl1.ForeColor = System.Drawing.Color.Gold;
            this.dougScrollingTextCtrl1.Location = new System.Drawing.Point(12, 12);
            this.dougScrollingTextCtrl1.Name = "dougScrollingTextCtrl1";
            this.dougScrollingTextCtrl1.Size = new System.Drawing.Size(935, 35);
            this.dougScrollingTextCtrl1.TabIndex = 2;
            this.dougScrollingTextCtrl1.Text = "National Geographic Channel Earth day Run 2017";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(959, 399);
            this.Controls.Add(this.dougScrollingTextCtrl1);
            this.Controls.Add(this.powerMeter1);
            this.Controls.Add(this.lblTotalCurrent);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTotalCurrent;
        private System.Windows.Forms.Timer tmrPollLJ;
        private powerMeter powerMeter1;
        private DougScrollingText.DougScrollingTextCtrl dougScrollingTextCtrl1;
    }
}

