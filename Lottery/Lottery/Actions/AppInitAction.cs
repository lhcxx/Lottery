using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Model;

namespace Lottery.Actions
{
    public class AppInitAction:BaseAction
    {
        public override void Run()
        {
            _processController.Message = "Application initiating...";
            Stream iconStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("lottery.ico");
            if (iconStream != null)
            {
                Program.AppIcon = new Icon(iconStream);
            }
            DownLoadFile("http://www.17500.cn/getData/ssq.TXT", "file.txt");
        }

        private  void DownLoadFile(string url, string fileName)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                string line = null;
                LotteryStageInfo lotteryInfo = new LotteryStageInfo();
                List<LotteryStageInfo> lotteryStageInfosList = new List<LotteryStageInfo>(); 
                while ((line = streamReader.ReadLine()) != null)
                {
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
                    lotteryStageInfosList.Add(lotteryInfo);
                }

                FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, lotteryStageInfosList);
                Program.workspace.LotteryList = lotteryStageInfosList; 

                fileStream.Close();
                streamReader.Close();
                stream.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
