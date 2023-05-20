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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int startpos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {

            startpos += 1;
            myprogress.Value = startpos;
            Progresslbl.Text = startpos+"%";
            if(myprogress.Value == 100)
            {


                myprogress.Value = 100;
                timer1.Stop();
                Login newForm = new Login();
                newForm.Show();
                this.Hide();

            }

        }

        private void myprogress_Click(object sender, EventArgs e)
        {

        }

        private void Progresslbl_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            scrolltxt.Location = new Point(scrolltxt.Location.X + 5, scrolltxt.Location.Y);
            if(scrolltxt.Location.X > this.Width)
            {

                scrolltxt.Location = new Point(0 - scrolltxt.Width, scrolltxt.Location.Y);

            }
        }
    }
}
