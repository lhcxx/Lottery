using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace LotteryBuz
{
    public class WorkSpace{
        private List<LotteryStageInfo> _lotteryList = new List<LotteryStageInfo>();

        public WorkSpace(){}

        public WorkSpace(string fileName){
            GetLotteryList(fileName);
        }

        public void GetLotteryList(string fileName){
            FileStream readStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            _lotteryList = (List<LotteryStageInfo>)formatter.Deserialize(readStream);
            readStream.Close();
        }
    }
}
