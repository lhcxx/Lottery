namespace test
{
    partial class FrmRegister
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
            this.tbxPCinfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxPCinfo
            // 
            this.tbxPCinfo.Location = new System.Drawing.Point(35, 31);
            this.tbxPCinfo.Multiline = true;
            this.tbxPCinfo.Name = "tbxPCinfo";
            this.tbxPCinfo.Size = new System.Drawing.Size(278, 164);
            this.tbxPCinfo.TabIndex = 0;
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 216);
            this.Controls.Add(this.tbxPCinfo);
            this.Name = "FrmRegister";
            this.Text = "FrmRegister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxPCinfo;
    }
}