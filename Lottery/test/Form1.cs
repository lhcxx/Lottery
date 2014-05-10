using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;


namespace test
{


    public class DownLoadThread
    {
        private string URL;
        private string fileName;

        public DownLoadThread(string url, string file)
        {
            URL = url;
            fileName = file;
        }

        public void runsOnWorkerThread(string URL, string fileName)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                long totalBytes = response.ContentLength;

                Stream st = response.GetResponseStream();
                Stream so = new FileStream(fileName, FileMode.Create);

                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    [Serializable]
    public class A
    {
        private string a;
        private string b;
        private string c;
        private string d;
        private string e;
        private string f;
        private string g;
        private string h;

        public A(){}

        public string A1{
            get { return a; }
            set { a = value; }
        }

        public string B{
            get { return b; }
            set { b = value; }
        }

        public string C{
            get { return c; }
            set { c = value; }
        }

        public string D{
            get { return d; }
            set { d = value; }
        }

        public string E{
            get { return e; }
            set { e = value; }
        }

        public string F{
            get { return f; }
            set { f = value; }
        }

        public string G{
            get { return g; }
            set { g = value; }
        }

        public string H{
            get { return h; }
            set { h = value; }
        }

        public A(string a, string b, string c, string d, string e, string f, string g, string h){
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
            this.h = h;
        }
    }

    public partial class Form1 : Form
    {

        private List<A> _list = new List<A>();
        public Form1()
        {
            InitializeComponent();

//            Ping p = new Ping();
//            PingReply pr = p.Send("192.168.0.121");
//            if (pr.Status != IPStatus.Success){
//                MessageBox.Show("网络连接异常");
//            }
//            else{
//                //Thread thread = new Thread(new ThreadStart(runsOnWorkerThread));
//                //thread.Start("http://www.17500.cn/getData/ssq.TXT", "file.txt");
//                DownLoadThread downLoadThread = new DownLoadThread("http://www.17500.cn/getData/ssq.TXT", "file.txt");
//                //Thread thread = new Thread(downLoadThread.runsOnWorkerThread);
//                Thread t = new Thread(() => runsOnWorkerThread("http://www.17500.cn/getData/ssq.TXT", "file.txt"));
//                t.Start();
//            }
            
//            SqlConnection conn = new SqlConnection("Data Source=192.168.0.121,User ID=sa,Password=8274591lhcxx!,Initial Catalog=test");
//            conn.Open();
//            if (conn.State == ConnectionState.Open){
//                MessageBox.Show("Successful");
//            }
//            else{
//                MessageBox.Show("Failed!");
//            }
//            conn.Close();


            //string conn = "Database='test';Data Source='192.168.0.121';User Id='root';Password='82740591';charset='utf8';pooling=true";
            

        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegister form = new FrmRegister();
            form.ShowDialog();
            
        }

     /*   private void downLoadFile()
        {
            if(this.InvokeRequired){
                BeginInvoke(new EventHandler(runsOnWorkerThread), null);
            }
        }*/
        private  void runsOnWorkerThread(string URL, string fileName)
        {
            try{
                
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream st = response.GetResponseStream();
                StreamReader sr = new StreamReader(st);
           //     Stream so = new FileStream(fileName,FileMode.Create);

              //  StreamWriter sw = new StreamWriter(so);
                
                
                string line = null;
                A a = new A();
                while((line = sr.ReadLine()) != null){
                    string[] arr = line.Split();
                    a = new A();
                    a.A1 = arr[0];
                    a.B = arr[2];
                    a.C = arr[3];
                    a.D = arr[4];
                    a.E = arr[5];
                    a.F = arr[6];
                    a.G = arr[7];
                    a.H = arr[8];
                    _list.Add(a);
                 //   sw.WriteLine(line);
                }
                FileStream fs = new FileStream(fileName,FileMode.Create,FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs,_list);
                fs.Close();
                FileStream readStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                List<A> tmp = (List<A>) bf.Deserialize(readStream);
                a = tmp.Last();
                readStream.Close();
                
          //      so.Close();
                st.Close();
                sr.Close();
            }
            catch(Exception){
                throw;
            }
        }
    }
}
