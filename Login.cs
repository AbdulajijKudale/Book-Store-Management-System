using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Book_Store_Management_System
{
    public partial class Login : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Login()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random ran = new Random();
            int col1 = ran.Next(0, 255);
            int col2 = ran.Next(0, 255);
            int col3 = ran.Next(0, 255);

            label1.ForeColor = Color.FromArgb(col1,col2,col3);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer1.Enabled = true;
            button1.Enabled = button2.Enabled = button3.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = false;
            pictureBox2.Hide();

            if(File.Exists("Remember Password.txt"))
            {
                using (StreamReader streamReader = new StreamReader("Remember Password.txt"))
                {
                    textBox1.Text = streamReader.ReadLine();
                    textBox2.Text = streamReader.ReadLine();
                }


            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBook newForm = new AddBook();
            newForm.Show();
            this.Hide();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            scrolltxt.Location = new Point(scrolltxt.Location.X + 5, scrolltxt.Location.Y);
            if (scrolltxt.Location.X > this.Width)
            {

                scrolltxt.Location = new Point(0 - scrolltxt.Width, scrolltxt.Location.Y);

            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void scrolltxt_Click(object sender, EventArgs e)
        {

        }

        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from Login_TB where USERNAME = @user and PASSWORD = @pass";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows == true)
            {
                MessageBox.Show("Login Successfull","Book Store Management System",MessageBoxButtons.OK,MessageBoxIcon.Information);

                using (StreamWriter streamwriter = new StreamWriter("Remember Password.txt"))
                {

                    streamwriter.WriteLine(textBox1.Text);
                    streamwriter.WriteLine(textBox2.Text);

                }
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button8.Enabled = true;
                button7.Enabled = true;
                button6.Enabled = true;
                button5.Enabled = true;
                pictureBox2.Show();
            }
            else
            {
                MessageBox.Show("Please Enter Valid Login Details", "Book Store Management System",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            con.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;

            switch (check)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;


            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            button10.BackColor = Color.Red;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = Color.FloralWhite;
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            button9.BackColor = Color.LawnGreen;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.FloralWhite;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Honeydew;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button8.Enabled = false;
            button7.Enabled = false;
            button6.Enabled = false;
            button5.Enabled = false;
            pictureBox2.Hide();
            textBox1.Clear();
            textBox2.Clear();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            Add_Book form = new Add_Book();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            Check_Stock form = new Check_Stock();
            form.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
           
            Orders_Record form = new Orders_Record();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Show_Reports form = new Show_Reports();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            

            SMS form = new SMS();
            form.Show();

           
        }
    }
}
