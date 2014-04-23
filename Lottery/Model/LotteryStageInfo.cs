using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class LotteryStageInfo{
        private string _id;
        private string _red_1;
        private string _red_2;
        private string _red_3;
        private string _red_4;
        private string _red_5;
        private string _red_6;
        private string _blue;

        public LotteryStageInfo(){}
        public LotteryStageInfo(string id, string red1, string red2, string red3, string red4, string red5, string red6, string blue){
            _id = id;
            _red_1 = red1;
            _red_2 = red2;
            _red_3 = red3;
            _red_4 = red4;
            _red_5 = red5;
            _red_6 = red6;
            _blue = blue;
        }

        public string Id{
            get { return _id; }
            set { _id = value; }
        }

        public string Red1{
            get { return _red_1; }
            set { _red_1 = value; }
        }

        public string Red2{
            get { return _red_2; }
            set { _red_2 = value; }
        }

        public string Red3{
            get { return _red_3; }
            set { _red_3 = value; }
        }

        public string Red4{
            get { return _red_4; }
            set { _red_4 = value; }
        }

        public string Red5{
            get { return _red_5; }
            set { _red_5 = value; }
        }

        public string Red6{
            get { return _red_6; }
            set { _red_6 = value; }
        }

        public string Blue{
            get { return _blue; }
            set { _blue = value; }
        }
    }
}
