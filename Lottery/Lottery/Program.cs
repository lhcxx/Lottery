using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lottery.Actions;
using LotteryBuz;

namespace Lottery
{
    static class Program{
        public static WorkSpace workspace;
        public static Icon AppIcon;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            workspace = new WorkSpace();
            try
            {
                AppInitAction action = new AppInitAction();
                action.RunInProgress();
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }
    }
}
