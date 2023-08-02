using Microsoft.ReportingServices.DataProcessing;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Book_Store_Management_System
{
    public partial class Login : Form
    {
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
            lblBSMS.ForeColor = Color.FromArgb(col1, col2, col3);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            scrlOwner.Location = new Point(scrlOwner.Location.X + 5, scrlOwner.Location.Y);
            if (scrlOwner.Location.X > this.Width)
                scrlOwner.Location = new Point(0 - scrlOwner.Width, scrlOwner.Location.Y);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            SMS form = new SMS();
            form.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Show_Reports form = new Show_Reports();
            form.Show();
        }

        private void btnOrdersRecord_Click(object sender, EventArgs e)
        {
            Orders_Record form = new Orders_Record();
            form.Show();
        }

        private void btnCheckStock_Click(object sender, EventArgs e)
        {
            Check_Stock form = new Check_Stock();
            form.Show();
        }

        private void btnAddNewBook_Click(object sender, EventArgs e)
        {
            Close();
            Add_Book form = new Add_Book();
            form.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            btnAddNewCustomer.Enabled = btnAddNewBook.Enabled = btnLogOut.Enabled = btnSendSMS.Enabled = btnReports.Enabled = btnCheckStock.Enabled = btnOrdersRecord.Enabled = false;
            pictbxBook.Hide();
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Red;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Honeydew;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool check = chkShowPassword.Checked;
            switch (check)
            {
                case true:
                    txtPassword.UseSystemPasswordChar = false;
                    break;
                default:
                    txtPassword.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["BSMSCS"]);
           
            using (SqlCommand cmd = new SqlCommand("[dbo].[uspLogin]",con))
            {
                con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    MessageBox.Show("Login Successfull", "Book Store Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (StreamWriter streamwriter = new StreamWriter("Remember Password.txt"))
                    {
                        streamwriter.WriteLine(txtUserName.Text);
                        streamwriter.WriteLine(txtPassword.Text);
                    }

                    btnAddNewCustomer.Enabled = btnAddNewBook.Enabled = btnLogOut.Enabled = btnSendSMS.Enabled = btnReports.Enabled = btnCheckStock.Enabled = btnOrdersRecord.Enabled = true;
                    pictbxBook.Show();
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Login Details", "Book Store Management System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.LawnGreen;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FloralWhite;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        void ClearControls()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.FloralWhite;
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.Red;
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            NewCustomer newForm = new NewCustomer();
            newForm.Show();
            Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer1.Enabled = true;
            btnAddNewCustomer.Enabled = btnAddNewBook.Enabled = btnLogOut.Enabled = btnSendSMS.Enabled = btnReports.Enabled = btnCheckStock.Enabled = btnOrdersRecord.Enabled = false;
            pictbxBook.Hide();

            if (File.Exists("Remember Password.txt"))
            {
                using (StreamReader streamReader = new StreamReader("Remember Password.txt"))
                {
                    txtUserName.Text = streamReader.ReadLine();
                    txtPassword.Text = streamReader.ReadLine();
                }
            }
        }
    }
}
