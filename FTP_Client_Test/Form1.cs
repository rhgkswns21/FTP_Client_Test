using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace FTP_Client_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void connect_bt_Click(object sender, EventArgs e)
        {
            String str = DateTime.Now.ToString() + "    " + "Connect Start...";
            this.label1.Text = str;

            FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/mtesNN/IMEI/");
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            ftpWebRequest.Credentials = new NetworkCredential("test","");

            FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();


            StreamReader streamReader = new StreamReader(ftpWebResponse.GetResponseStream());
            str = DateTime.Now.ToString() + "   " + streamReader.ReadToEnd();
            this.label1.Text = str;
            Console.WriteLine(str);

            //StreamReader strReader = new StreamReader(fwResponse.GetResponseStream());
            //Console.WriteLine(strReader.ReadToEnd());
            //strReader.Close();

            //FtpWebRequest fwRequest = (FtpWebRequest)WebRequest.Create("ftp://192.168.10.105/test01.txt");
            //fwRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            //fwRequest.Credentials = new NetworkCredential("aaa", "1111");
            //FtpWebResponse fwResponse = (FtpWebResponse)fwRequest.GetResponse();
        }
    }
}
