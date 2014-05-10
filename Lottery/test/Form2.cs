using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string childrenFormText = "Form4";
            if (!ShowChildrenForm(childrenFormText))
            {
                Form4 frm = new Form4();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        //check children form exist or not. if exists, active
        //maybe we can check the form type, instead of text
        private bool ShowChildrenForm(string childrenFormText)
        {
            int i;

            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                //MessageBox.Show(this.MdiChildren[i].Text);
                if (this.MdiChildren[i].Text == childrenFormText)
                {
                    this.MdiChildren[i].Activate();
                    this.MdiChildren[i].WindowState = FormWindowState.Maximized;
                    return true;
                }
                //else {
                //    this.MdiChildren[i].Hide();
                //}
            }
            return false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string childrenFormText = "Form3";
            if (!ShowChildrenForm(childrenFormText))
            {
                Form3 frm = new Form3();
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}
