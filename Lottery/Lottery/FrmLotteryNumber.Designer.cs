namespace Lottery
{
    partial class FrmLotteryNumber
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLotteryStageInfo = new System.Windows.Forms.DataGridView();
            this.phase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.red = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotteryStageInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.46561F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.53439F));
            this.tableLayoutPanel1.Controls.Add(this.dgvLotteryStageInfo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 599);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvLotteryStageInfo
            // 
            this.dgvLotteryStageInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotteryStageInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.phase,
            this.red,
            this.blue});
            this.dgvLotteryStageInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLotteryStageInfo.Location = new System.Drawing.Point(3, 3);
            this.dgvLotteryStageInfo.Name = "dgvLotteryStageInfo";
            this.dgvLotteryStageInfo.Size = new System.Drawing.Size(436, 593);
            this.dgvLotteryStageInfo.TabIndex = 0;
            // 
            // phase
            // 
            this.phase.DataPropertyName = "ID";
            this.phase.HeaderText = "期号";
            this.phase.Name = "phase";
            this.phase.ReadOnly = true;
            this.phase.Width = 90;
            // 
            // red
            // 
            this.red.DataPropertyName = "Red";
            this.red.HeaderText = "红球常规号码";
            this.red.Name = "red";
            this.red.ReadOnly = true;
            this.red.Width = 200;
            // 
            // blue
            // 
            this.blue.DataPropertyName = "Blue";
            this.blue.HeaderText = "蓝球号码";
            this.blue.Name = "blue";
            this.blue.ReadOnly = true;
            // 
            // FrmLotteryNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 599);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmLotteryNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "历史数据维护";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotteryStageInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvLotteryStageInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn phase;
        private System.Windows.Forms.DataGridViewTextBoxColumn red;
        private System.Windows.Forms.DataGridViewTextBoxColumn blue;
    }
}