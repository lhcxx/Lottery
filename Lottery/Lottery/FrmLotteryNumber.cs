using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Lottery
{
    public partial class FrmLotteryNumber : Form{

        private List<LotteryStageInfo> _lotteryStageInfoList = new List<LotteryStageInfo>(); 
        public FrmLotteryNumber(List<LotteryStageInfo> list){
            _lotteryStageInfoList = list;
            InitializeComponent();
            dgvLotteryStageInfo.DataSource = createDataTable(_lotteryStageInfoList);
        }

        private DataTable createDataTable(List<LotteryStageInfo> list){
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Red");
            dt.Columns.Add("Blue");
            foreach (LotteryStageInfo info in list){
                DataRow dr = dt.NewRow();
                dr[0] = info.Id;
                dr[1] = "            "+ info.Red1 + "  " + info.Red2 + "  " + info.Red3 + "  " + info.Red4 + "  " + info.Red5 + "  " +
                        info.Red6;
                dr[2] = "            " + info.Blue;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
