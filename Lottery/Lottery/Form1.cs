using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    public partial class Form1 : Form
    {

        private List<Button> _redButtonList = new List<Button>();
        private List<int> _redSelectedButtonNumber = new List<int>();
        private List<int> _blueSelectedButtonNumber = new List<int>();

        public Form1()
        {
            InitializeComponent();
            initRedButtonList();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLotteryNumber_Click(object sender, EventArgs e)
        {
            FrmLotteryNumber formLotteryNumber = new FrmLotteryNumber();
            formLotteryNumber.ShowDialog();
        }

        private void changeRedButtonColor(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
                return;
            int number = Int32.Parse(btn.Text);
            if (!btn.BackColor.Equals(Color.Red)){
                btn.BackColor = Color.Red;
                _redSelectedButtonNumber.Add(number);
            }
            else
            {
                btn.BackColor = Color.Empty;
                _redSelectedButtonNumber.Remove(number);
            }

            lblRedTotalNumber.Text = _redSelectedButtonNumber.Count.ToString();
        }

        private void changeBlueButtonColor(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
                return;
            int number = Int32.Parse(btn.Text);
            if (!btn.BackColor.Equals(Color.DeepSkyBlue))
            {
                btn.BackColor = Color.DeepSkyBlue;
                _blueSelectedButtonNumber.Add(number);
            }
            else
            {
                btn.BackColor = Color.Empty; 
                _blueSelectedButtonNumber.Remove(number);
            }
            lblBlueNumber.Text = _blueSelectedButtonNumber.Count.ToString();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {   

            foreach (Button btn in _redButtonList)
                btn.BackColor = Color.Red;
            _redSelectedButtonNumber.Clear();
            for (int i = 1; i <= _redButtonList.Count; i++)
                _redSelectedButtonNumber.Add(i);
            lblRedTotalNumber.Text = _redSelectedButtonNumber.Count.ToString();
        }

        private void initRedButtonList()
        {
            _redButtonList.Add(btn1);
            _redButtonList.Add(btn2);
            _redButtonList.Add(btn3);
            _redButtonList.Add(btn4);
            _redButtonList.Add(btn5);
            _redButtonList.Add(btn6);
            _redButtonList.Add(btn7);
            _redButtonList.Add(btn8);
            _redButtonList.Add(btn9);
            _redButtonList.Add(btn10);
            _redButtonList.Add(btn11);
            _redButtonList.Add(btn12);
            _redButtonList.Add(btn13);
            _redButtonList.Add(btn14);
            _redButtonList.Add(btn15);
            _redButtonList.Add(btn16);
            _redButtonList.Add(btn17);
            _redButtonList.Add(btn18);
            _redButtonList.Add(btn19);
            _redButtonList.Add(btn20);
            _redButtonList.Add(btn21);
            _redButtonList.Add(btn22);
            _redButtonList.Add(btn23);
            _redButtonList.Add(btn24);
            _redButtonList.Add(btn25);
            _redButtonList.Add(btn26);
            _redButtonList.Add(btn27);
            _redButtonList.Add(btn28);
            _redButtonList.Add(btn29);
            _redButtonList.Add(btn30);
            _redButtonList.Add(btn31);
            _redButtonList.Add(btn32);
            _redButtonList.Add(btn33);
        }

        private void btnCounterSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Button btn in _redButtonList)
            {   
                int number = Int32.Parse(btn.Text);
                if (btn.BackColor.Equals(Color.Red)){
                    btn.BackColor = Color.Empty;
                    _redSelectedButtonNumber.Remove(number);
                }
                else
                {
                    btn.BackColor = Color.Red;
                    _redSelectedButtonNumber.Add(number);
                }
                    
            }
            lblRedTotalNumber.Text = _redSelectedButtonNumber.Count.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Button btn in _redButtonList)
                btn.BackColor = Color.Empty;
            _redSelectedButtonNumber.Clear();
            lblRedTotalNumber.Text = _redSelectedButtonNumber.Count.ToString();
        }

        private void cbxIsBraveCode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxIsBraveCode.Checked == true)
                tbxBraveCode.Enabled = true;
            else
            {
                tbxBraveCode.Clear();
                tbxBraveCode.Enabled = false;
            }
               
        }

        private void cbxWhirlMatrix_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxWhirlMatrix.Checked == true)
                cbWhirlMatrix.Enabled = true;
            else
            {
                cbWhirlMatrix.Enabled = false;
            }
               
        }







   

    }
}
