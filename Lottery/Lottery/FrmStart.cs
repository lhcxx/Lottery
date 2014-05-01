using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    public partial class FrmStart : Form
    {
        public FrmStart()
        {
            InitializeComponent();

       //     CheckNetWorkConnect();

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
               
            }
            
        }

        public void ShowMessage(string msg, bool canCancel)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    _lbMessage.Text = msg;
                    _btnCancel.Visible = canCancel;
                }
                    ));
            }
            else
            {
                _lbMessage.Text = msg;
                _btnCancel.Visible = canCancel;
            }
        }

        public void CloseForm()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(Close));
            }
            else
            {
                Close();
            }
        }

        public void ShowError(Exception exception)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Exception>(DisplayError), exception);
            }
            else
            {
                DisplayError(exception);
            }
        }

        private void DisplayError(Exception e)
        {
            _lbMessage.Text = "Action runs in error! " + e.Message;
            _lbMessage.ForeColor = Color.Red;
            _btnOK.Visible = true;
            _btnCancel.Visible = false;
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelClick != null)
            {
                CancelClick();
            }
        }

        public event Action CancelClick;

    }
}
