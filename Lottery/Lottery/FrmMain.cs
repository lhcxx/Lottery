using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Lottery
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            InitialFirstWindow();
        }

        private void InitialFirstWindow(){
            string childrenFormText = "过滤";
            if (!ShowChildrenForm(childrenFormText))
            {
                Form1 frm = new Form1();
                frm.MdiParent = this;
                frm.Activate();
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }


        private void btnLotteryNumber_Click(object sender, EventArgs e)
        {
            List<LotteryStageInfo> lotteryList = new List<LotteryStageInfo>();
            if (File.Exists("file.txt"))
            {
                FileStream readStream = new FileStream("file.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                lotteryList = (List<LotteryStageInfo>)formatter.Deserialize(readStream);
                readStream.Close();
            }
            FrmLotteryNumber formLotteryNumber = new FrmLotteryNumber(lotteryList);
            formLotteryNumber.ShowDialog();
        }

        //check children form exist or not. if exists, active
        //maybe we can check the form type, instead of text
        private bool ShowChildrenForm(string childrenFormText)
        {
            int i;

            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                //MessageBox.Show(this.MdiChildren[i].Text);
                if (this.MdiChildren[i].Text == childrenFormText)
                {
                    this.MdiChildren[i].Activate();
                    this.MdiChildren[i].WindowState = FormWindowState.Maximized;
                    return true;
                }
                //else {
                //    this.MdiChildren[i].Hide();
                //}
            }
            return false;
        }

    }
}
