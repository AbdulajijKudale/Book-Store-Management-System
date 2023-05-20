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



namespace Book_Store_Management_System
{
    public partial class Add_Book : Form
    {


        string cs = ConfigurationManager.ConnectionStrings["dbcs_1"].ConnectionString;

        public Add_Book()
        {
            InitializeComponent();
            populate();
           
        }
       
        public void populate()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "select *from Book";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }
        public void filter()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string query = "select *from Book where Category='" + comboBox2.SelectedItem.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }
        
    

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            if (key==0)
            {

                MessageBox.Show("Please Fiil All Feilds", "Add New Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else
            {


                con.Open();

                string query = "delete from Book where BookId=" + key + ";";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Deleted Successfully", "Add New Book", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();


            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            timer1.Start();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random ran = new Random();
            int col1 = ran.Next(0, 255);
            int col2 = ran.Next(0, 255);
            int col3 = ran.Next(0, 255);

            label11.ForeColor = Color.FromArgb(col1, col2, col3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

            Login form = new Login();
            form.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.SelectedIndex == -1 || textBox7.Text == "" || textBox8.Text == "")
            {

                MessageBox.Show("Please Fiil All Feilds", "Add New Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else
            {


                con.Open();

                string query = "insert into Book values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox7.Text + "','" + textBox8.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Saved Successfully", "Add New Book", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();


            }
        }

        private void bookBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

           
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            comboBox1.ResetText();
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox2.Focus();
        }

     
      
        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();

            Login form = new Login();
            form.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }


        int key = 0;
        private void dataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            if(textBox2.Text=="")
            { 
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            populate();
            comboBox2.SelectedIndex = -1;
           
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.SelectedIndex == -1 || textBox7.Text == "" || textBox8.Text == "")
            {

                MessageBox.Show("Please Fiil All Feilds", "Add New Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else
            {


                con.Open();

                string query = "update Book set BookName='" + textBox2.Text + "',ISBN='" + textBox3.Text + "',Author='" + textBox4.Text + "',Category='" + comboBox1.SelectedItem.ToString() + "',Stock='" + textBox7.Text + "',Price=" + textBox8.Text + " where BookId="+key+";";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Updated Successfully", "Add New Book", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();


            }
        }

        private void addNewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            AddBook form = new AddBook();
            form.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Check_Stock form = new Check_Stock();
            form.Show();
        }
    }

}

