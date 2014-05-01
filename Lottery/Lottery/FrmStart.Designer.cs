namespace Lottery
{
    partial class FrmStart
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._btnCancel = new System.Windows.Forms.Button();
            this._lbMessage = new System.Windows.Forms.Label();
            this._btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Lottery.Properties.Resources.ajax_loader;
            this.pictureBox1.Location = new System.Drawing.Point(221, 171);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 22);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(300, 269);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(78, 30);
            this._btnCancel.TabIndex = 90;
            this._btnCancel.Text = "取消";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _lbMessage
            // 
            this._lbMessage.AutoSize = true;
            this._lbMessage.Location = new System.Drawing.Point(255, 220);
            this._lbMessage.Name = "_lbMessage";
            this._lbMessage.Size = new System.Drawing.Size(151, 13);
            this._lbMessage.TabIndex = 91;
            this._lbMessage.Text = "胆码：两个以上用空格分开";
            // 
            // _btnOK
            // 
            this._btnOK.Location = new System.Drawing.Point(201, 269);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(78, 30);
            this._btnOK.TabIndex = 92;
            this._btnOK.Text = "取消";
            this._btnOK.UseVisualStyleBackColor = true;
            this._btnOK.Visible = false;
            // 
            // FrmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 405);
            this.Controls.Add(this._btnOK);
            this.Controls.Add(this._lbMessage);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎界面";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label _lbMessage;
        private System.Windows.Forms.Button _btnOK;
    }
}