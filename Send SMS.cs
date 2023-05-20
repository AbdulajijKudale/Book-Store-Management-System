using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_Store_Management_System
{
    public partial class SMS : Form
    {
        public SMS()
        {
            InitializeComponent();

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.way2sms.com/");
        }
    }
}
