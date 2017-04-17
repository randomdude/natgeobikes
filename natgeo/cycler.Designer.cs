namespace natgeo
{
    partial class cycler
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.powerMeter1 = new natgeo.powerMeter();
            this.lblPower = new System.Windows.Forms.Label();
            this.lblCyclePic = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // powerMeter1
            // 
            this.powerMeter1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.powerMeter1.Location = new System.Drawing.Point(21, 239);
            this.powerMeter1.maxValue = 0;
            this.powerMeter1.Name = "powerMeter1";
            this.powerMeter1.Size = new System.Drawing.Size(288, 14);
            this.powerMeter1.TabIndex = 0;
            this.powerMeter1.value = 0;
            // 
            // lblPower
            // 
            this.lblPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPower.Font = new System.Drawing.Font("Open 24 Display St", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower.Location = new System.Drawing.Point(21, 214);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(288, 22);
            this.lblPower.TabIndex = 1;
            this.lblPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCyclePic
            // 
            this.lblCyclePic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCyclePic.Location = new System.Drawing.Point(18, 0);
            this.lblCyclePic.Name = "lblCyclePic";
            this.lblCyclePic.Size = new System.Drawing.Size(291, 214);
            this.lblCyclePic.TabIndex = 4;
            this.lblCyclePic.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
            // 
            // cycler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblCyclePic);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.powerMeter1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "cycler";
            this.Size = new System.Drawing.Size(334, 268);
            this.ResumeLayout(false);

        }

        #endregion

        private powerMeter powerMeter1;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.Label lblCyclePic;
    }
}
