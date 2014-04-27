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
            Thread t = new Thread(() => DownLoadThread("http://www.17500.cn/getData/ssq.TXT", "file.txt"));
            t.Start();
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



  







   

    }
}
