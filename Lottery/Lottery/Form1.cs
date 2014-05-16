using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Lottery
{
    public partial class Form1 : Form
    {

        private List<Button> _redButtonList = new List<Button>();
        private List<int> _redSelectedButtonNumber = new List<int>();
        private List<int> _blueSelectedButtonNumber = new List<int>();
        private List<LotteryStageInfo> _lotteryStageInfosList = new List<LotteryStageInfo>(); 
        public Form1()
        {
            InitializeComponent();
            initRedButtonList();
           // Thread t = new Thread(() => DownLoadThread("http://www.17500.cn/getData/ssq.TXT", "file.txt"));
          //  t.Start();
            initCurrentBetStage();
        }

        private void initCurrentBetStage(){       
            if (Program.workspace.LotteryList.Last() != null){
                lblCurrentBetStage.Text = (Int32.Parse(Program.workspace.LotteryList.Last().Id)+1).ToString();
            }
        }

        private void DownLoadThread(string url, string fileName){
            try{
                HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                string line = null;
                LotteryStageInfo lotteryInfo = new LotteryStageInfo();

                while ((line = streamReader.ReadLine()) != null){
                    string[] arr = line.Split();
                    lotteryInfo = new LotteryStageInfo();
                    lotteryInfo.Id = arr[0];
                    lotteryInfo.Red1 = arr[2];
                    lotteryInfo.Red2 = arr[3];
                    lotteryInfo.Red3 = arr[4];
                    lotteryInfo.Red4 = arr[5];
                    lotteryInfo.Red5 = arr[6];
                    lotteryInfo.Red6 = arr[7];
                    lotteryInfo.Blue = arr[8];
                    _lotteryStageInfosList.Add(lotteryInfo);
                }

                FileStream fileStream = new FileStream(fileName,FileMode.Create,FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream,_lotteryStageInfosList);
                
                fileStream.Close();
                streamReader.Close();
                stream.Close();

            }
            catch (Exception){
                
                throw;
            }
        }

        private void btnLotteryNumber_Click(object sender, EventArgs e)
        {
            List<LotteryStageInfo> lotteryList = new List<LotteryStageInfo>();
            if (File.Exists("file.txt")){
                FileStream readStream = new FileStream("file.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                lotteryList = (List<LotteryStageInfo>) formatter.Deserialize(readStream);
                readStream.Close();
            }
            FrmLotteryNumber formLotteryNumber = new FrmLotteryNumber(lotteryList);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e){
            if (checkBox1.Checked){
                _cbx1.Enabled = true;
                _cbx2.Enabled = true;
            }
            else{
                _cbx1.Enabled = false;
                _cbx2.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                _cbx3.Enabled = true;
                _cbx4.Enabled = true;
            }
            else
            {
                _cbx3.Enabled = false;
                _cbx4.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                _cbx5.Enabled = true;
                _cbx6.Enabled = true;
            }
            else
            {
                _cbx5.Enabled = false;
                _cbx6.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                _cbx7.Enabled = true;
                _cbx8.Enabled = true;
            }
            else
            {
                _cbx7.Enabled = false;
                _cbx8.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                _cbx9.Enabled = true;
                _cbx10.Enabled = true;
            }
            else
            {
                _cbx9.Enabled = false;
                _cbx10.Enabled = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                _cbx11.Enabled = true;
                _cbx12.Enabled = true;
            }
            else
            {
                _cbx11.Enabled = false;
                _cbx12.Enabled = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                _cbx13.Enabled = true;
                _cbx14.Enabled = true;
            }
            else
            {
                _cbx13.Enabled = false;
                _cbx14.Enabled = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                _cbx15.Enabled = true;
                _cbx16.Enabled = true;
            }
            else
            {
                _cbx15.Enabled = false;
                _cbx16.Enabled = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                _cbx17.Enabled = true;
                _cbx18.Enabled = true;
            }
            else
            {
                _cbx17.Enabled = false;
                _cbx18.Enabled = false;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                _cbx19.Enabled = true;
                _cbx20.Enabled = true;
            }
            else
            {
                _cbx19.Enabled = false;
                _cbx20.Enabled = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                _cbx21.Enabled = true;
                _cbx22.Enabled = true;
            }
            else
            {
                _cbx21.Enabled = false;
                _cbx22.Enabled = false;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                _cbx23.Enabled = true;
                _cbx24.Enabled = true;
            }
            else
            {
                _cbx23.Enabled = false;
                _cbx24.Enabled = false;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
            {
                _cbx25.Enabled = true;
                _cbx26.Enabled = true;
            }
            else
            {
                _cbx25.Enabled = false;
                _cbx26.Enabled = false;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
                _cbx27.Enabled = true;
                _cbx28.Enabled = true;
            }
            else
            {
                _cbx27.Enabled = false;
                _cbx28.Enabled = false;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked)
            {
                _cbx29.Enabled = true;
                _cbx30.Enabled = true;
            }
            else
            {
                _cbx29.Enabled = false;
                _cbx30.Enabled = false;
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked)
            {
                _cbx31.Enabled = true;
                _cbx32.Enabled = true;
            }
            else
            {
                _cbx31.Enabled = false;
                _cbx32.Enabled = false;
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
            {
                _cbx33.Enabled = true;
                _cbx34.Enabled = true;
            }
            else
            {
                _cbx33.Enabled = false;
                _cbx34.Enabled = false;
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
            {
                _cbx35.Enabled = true;
                _cbx36.Enabled = true;
            }
            else
            {
                _cbx35.Enabled = false;
                _cbx36.Enabled = false;
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
            {
                _cbx37.Enabled = true;
                _cbx38.Enabled = true;
            }
            else
            {
                _cbx37.Enabled = false;
                _cbx38.Enabled = false;
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked)
            {
                _cbx39.Enabled = true;
                _cbx40.Enabled = true;
            }
            else
            {
                _cbx39.Enabled = false;
                _cbx40.Enabled = false;
            }
        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox21.Checked)
            {
                _cbx41.Enabled = true;
                _cbx42.Enabled = true;
            }
            else
            {
                _cbx41.Enabled = false;
                _cbx42.Enabled = false;
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked)
            {
                _cbx43.Enabled = true;
                _cbx44.Enabled = true;
            }
            else
            {
                _cbx43.Enabled = false;
                _cbx44.Enabled = false;
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked)
            {
                _cbx45.Enabled = true;
                _cbx46.Enabled = true;
            }
            else
            {
                _cbx45.Enabled = false;
                _cbx46.Enabled = false;
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox24.Checked)
            {
                _cbx47.Enabled = true;
                _cbx48.Enabled = true;
            }
            else
            {
                _cbx47.Enabled = false;
                _cbx48.Enabled = false;
            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked)
            {
                _cbx49.Enabled = true;
                _cbx50.Enabled = true;
            }
            else
            {
                _cbx49.Enabled = false;
                _cbx50.Enabled = false;
            }

        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox26.Checked)
            {
                _cbx51.Enabled = true;
                _cbx52.Enabled = true;
            }
            else
            {
                _cbx51.Enabled = false;
                _cbx52.Enabled = false;
            }
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked)
            {
                _cbx53.Enabled = true;
                _cbx54.Enabled = true;
            }
            else
            {
                _cbx53.Enabled = false;
                _cbx54.Enabled = false;
            }
        }

        private void _btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.Controls){
                if ((ctr as CheckBox) != null){
                    CheckBox tmp = ctr as CheckBox;
                    tmp.Checked = true;
                }
            }
        }

 
  






        
















  







   

    }
}
