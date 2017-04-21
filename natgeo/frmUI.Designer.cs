namespace natgeo
{
    partial class frmUI
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
            this.txtScrollText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSetText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtScrollText
            // 
            this.txtScrollText.Location = new System.Drawing.Point(89, 6);
            this.txtScrollText.Name = "txtScrollText";
            this.txtScrollText.Size = new System.Drawing.Size(455, 20);
            this.txtScrollText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scrollbar text:";
            // 
            // cmdSetText
            // 
            this.cmdSetText.Location = new System.Drawing.Point(268, 32);
            this.cmdSetText.Name = "cmdSetText";
            this.cmdSetText.Size = new System.Drawing.Size(46, 27);
            this.cmdSetText.TabIndex = 2;
            this.cmdSetText.Text = "Set";
            this.cmdSetText.UseVisualStyleBackColor = true;
            this.cmdSetText.Click += new System.EventHandler(this.cmdSetText_Click);
            // 
            // frmUI
            // 
            this.AcceptButton = this.cmdSetText;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 273);
            this.Controls.Add(this.cmdSetText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScrollText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmUI";
            this.Text = "Natgeo bike controller";
            this.Load += new System.EventHandler(this.frmUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtScrollText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSetText;
    }
}