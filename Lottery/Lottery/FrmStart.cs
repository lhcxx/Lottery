using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    public partial class FrmStart : Form
    {
        public FrmStart()
        {
            InitializeComponent();

            CheckNetWorkConnect();

        }

        private void CheckNetWorkConnect(){
            
            Ping p = new Ping();
            PingReply pr = p.Send("www.baidu.com");
            if (pr.Status != IPStatus.Success)
            {
                MessageBox.Show("请检查网络连接是否正常!");
            }
            else
            {
                
                Form1 mainForm = new Form1();
                mainForm.ShowDialog();
            }
            
        }
    }
}
