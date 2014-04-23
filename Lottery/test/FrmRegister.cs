using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace test
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
            ShowPCInfo();
        }

        private void ShowPCInfo()
        {
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            string strId = null;
            foreach(ManagementObject mo in moc){
                strId = mo.Properties["ProcessorId"].Value.ToString();
                break;
            }
        //    tbxPCinfo.Text += "CPU ID:" + strId + "\n";
            mc = new ManagementClass("Win32_BaseBoard");
            moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                strId = mo.Properties["SerialNumber"].Value.ToString();
                break;
            }
          //  tbxPCinfo.Text += "Board ID:" + strId + "\n";
            mc = new ManagementClass("Win32_PhysicalMedia");
            moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                strId = mo.Properties["SerialNumber"].Value.ToString();
                break;
            }
         //   tbxPCinfo.Text += "Disk ID:" + strId + "\n";
            tbxPCinfo.Text += System.Guid.NewGuid().ToString();

        }
    }
}
