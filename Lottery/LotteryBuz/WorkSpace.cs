using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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

        public List<LotteryStageInfo> GetTotalBetItemsByRedBlueBrave(List<int> red, List<int> blue, List<string> brave)
        {   
            List<LotteryStageInfo> list = new List<LotteryStageInfo>();
            List<LotteryStageInfo> mutiList = new List<LotteryStageInfo>();
            List<LotteryStageInfo> braveList = new List<LotteryStageInfo>();
            List<int> b = new List<int>(6);
            b.Add(-1);
            b.Add(-1);
            b.Add(-1);
            b.Add(-1);
            b.Add(-1);
            b.Add(-1);
            if (red == null || blue == null || brave == null)
                return null;
            CombineAlgorithm(red, red.Count, b, 6, list);
            if (blue.Count == 1)
            {
                foreach (LotteryStageInfo ls in list)
                {
                    ls.Blue = blue[0].ToString();
                }
            }
            else
            {
                for (int i = 0; i < blue.Count; i++)
                {
                    foreach (LotteryStageInfo ls in list)
                    {
                        ls.Blue = blue[i].ToString();
                        mutiList.Add(Clone<LotteryStageInfo>(list[i]));
                    }
                }

            }
            if (brave.Count == 0)
            {
                if (list.Count == 0 && mutiList.Count != 0)
                    return mutiList;
                else
                    return list;
            }
            else // 胆码不为0的情况有点复杂，后续更新
            {
                if (list.Count == 0 && mutiList.Count != 0)
                {
                    foreach (LotteryStageInfo ls in mutiList)
                    {
                        if (brave.Contains(ls.Red1) || brave.Contains(ls.Red2) || brave.Contains(ls.Red3) || brave.Contains(ls.Red4) || brave.Contains(ls.Red5))
                            mutiList.Remove(ls);
                    }
                    return mutiList;
                }
                else
                {
                    foreach (LotteryStageInfo ls in list)
                    {
                        if (brave.Contains(ls.Red1) || brave.Contains(ls.Red2) || brave.Contains(ls.Red3) || brave.Contains(ls.Red4) || brave.Contains(ls.Red5))
                            list.Remove(ls);
                    }
                    return list;
                }
            }

        }

        public static T Clone<T>(T RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
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
