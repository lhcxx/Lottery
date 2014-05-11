using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Count();
        }

        private void Count(){
            string s = null;
            for (int i = 21 ; i < 184; i++){
                s += i+"\n";
            }
            textBox1.Text = s;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }


    }
}
