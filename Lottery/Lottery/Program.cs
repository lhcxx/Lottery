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
        private static WorkSpace workspace;
        public static Icon AppIcon;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            try
            {
                AppInitAction action = new AppInitAction();
                action.RunInProgress();
//                LoginForm loginForm = new LoginForm();
//                if (loginForm.ShowDialog() == DialogResult.OK)
//                {
//                    MainForm form = new MainForm();
//                    MainForm = form;
//                    Application.Run(form);
//                }
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
