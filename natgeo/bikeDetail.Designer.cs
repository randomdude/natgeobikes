namespace natgeo
{
    partial class bikeDetail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.barValOverride = new System.Windows.Forms.TrackBar();
            this.txtVAndP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVoltageOffset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRawValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barValOverride)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.barValOverride);
            this.groupBox1.Controls.Add(this.txtVAndP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtVoltageOffset);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRawValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // barValOverride
            // 
            this.barValOverride.Location = new System.Drawing.Point(175, 39);
            this.barValOverride.Maximum = 150;
            this.barValOverride.Name = "barValOverride";
            this.barValOverride.Size = new System.Drawing.Size(205, 42);
            this.barValOverride.TabIndex = 6;
            this.barValOverride.TickFrequency = 10;
            this.barValOverride.Scroll += new System.EventHandler(this.barValOverride_Scroll);
            // 
            // txtVAndP
            // 
            this.txtVAndP.Location = new System.Drawing.Point(276, 13);
            this.txtVAndP.Name = "txtVAndP";
            this.txtVAndP.ReadOnly = true;
            this.txtVAndP.Size = new System.Drawing.Size(100, 20);
            this.txtVAndP.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Calculated V and P";
            // 
            // txtVoltageOffset
            // 
            this.txtVoltageOffset.Location = new System.Drawing.Point(67, 39);
            this.txtVoltageOffset.Name = "txtVoltageOffset";
            this.txtVoltageOffset.Size = new System.Drawing.Size(100, 20);
            this.txtVoltageOffset.TabIndex = 3;
            this.txtVoltageOffset.TextChanged += new System.EventHandler(this.txtVoltageOffset_TextChanged);
            this.txtVoltageOffset.Enter += new System.EventHandler(this.txtVoltageOffset_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "DC offset";
            // 
            // txtRawValue
            // 
            this.txtRawValue.Location = new System.Drawing.Point(67, 13);
            this.txtRawValue.Name = "txtRawValue";
            this.txtRawValue.ReadOnly = true;
            this.txtRawValue.Size = new System.Drawing.Size(100, 20);
            this.txtRawValue.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Raw value";
            // 
            // bikeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "bikeDetail";
            this.Size = new System.Drawing.Size(397, 89);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barValOverride)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar barValOverride;
        private System.Windows.Forms.TextBox txtVAndP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVoltageOffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRawValue;
        private System.Windows.Forms.Label label1;
    }
}
