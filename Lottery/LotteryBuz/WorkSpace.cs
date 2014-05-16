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
        private  List<LotteryStageInfo> _lotteryList = new List<LotteryStageInfo>();

        public WorkSpace(){}

        public WorkSpace(string fileName){
            GetLotteryList(fileName);
        }

        public  List<LotteryStageInfo> LotteryList{
            get { return _lotteryList; }
            set { _lotteryList = value; }
        }

        public void GetLotteryList(string fileName){
            FileStream readStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            _lotteryList = (List<LotteryStageInfo>)formatter.Deserialize(readStream);
            readStream.Close();
        }

        public List<LotteryStageInfo> GetTotalBetItemsByRedBlueBrave(List<int> red, List<int> blue, List<int> brave)
        {   
            List<LotteryStageInfo> list = new List<LotteryStageInfo>();
            if (red == null || blue == null || brave == null)
                return list;
            if (brave.Count == 0){
                
            }
            else{
                
            }
            
            CombineAlgorithm(red,red.Count,blue,6, list);
            return list;
        }

        private void CombineAlgorithm(List<int> a, int n, List<int> b, int m,  List<LotteryStageInfo> list)
        {
            for (int i = n; i >= m; i--)
            {
                b[m - 1] = i - 1;
                if (m > 1)
                    CombineAlgorithm(a, i - 1, b, m - 1,  list);
                else
                {
                    LotteryStageInfo info = new LotteryStageInfo();
                    info.Red1 = a[b[5]].ToString();
                    info.Red2 = a[b[4]].ToString();
                    info.Red3 = a[b[3]].ToString();
                    info.Red4 = a[b[2]].ToString();
                    info.Red5 = a[b[1]].ToString();
                    info.Red6 = a[b[0]].ToString();
                   
                    list.Add(info);
                }
            }
        }


    }
}
