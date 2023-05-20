using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing.Printing;


namespace Book_Store_Management_System
{
    public partial class AddBook : Form
    {

        string cs = ConfigurationManager.ConnectionStrings["dbcs_1"].ConnectionString;

        string cm = ConfigurationManager.ConnectionStrings["dbcs_3"].ConnectionString;

        public AddBook()
        {
            InitializeComponent();
            fillcombobox();


        }
       
        public int numberOfItemsPerPage = 0;
        public int numberOfItemsPrintedSoFar = 0;


        public void fillcombobox()
        {
            SqlConnection con = new SqlConnection(cs);
            string sql = "select *from Book";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            con.Open();
            myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                string BookName = myreader.GetString(1);
                comboBox1.Items.Add(BookName);

            }

            con.Close();
        }
        private string GenerateOrderNumber()
        {
            string orderNumber;

            // AK-XXXXXXXXX-XXXX
            Random rnd = new Random();
            long orderpart1 = rnd.Next(10000, 99999);
            int orderpart2 = rnd.Next(1000, 9999);

            orderNumber = orderpart1.ToString() + orderpart2;

            return orderNumber;
        }
        private bool CheckIfOrderNumberExists(string orderNumber)
        {
            bool doesOrderNumberExist = false;

            SqlConnection con = new SqlConnection(cm);
            
           
            return doesOrderNumberExist;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();

            Login form = new Login();
            form.Show();


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();

            Add_Book form = new Add_Book();
            form.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Random ran = new Random();
            int col1 = ran.Next(0, 255);
            int col2 = ran.Next(0, 255);
            int col3 = ran.Next(0, 255);

            label1.ForeColor = Color.FromArgb(col1, col2, col3);
        }
        DataTable transactionDT = new DataTable();
        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
            button2.Enabled = false;
            button3.Enabled = false;
            groupBox1.Enabled = false;

            dataGridView1.Enabled = false;

            transactionDT.Columns.Add("BookId");
            transactionDT.Columns.Add("Book Name");
            transactionDT.Columns.Add("Quantity");
            transactionDT.Columns.Add("Price");
            transactionDT.Columns.Add("Total");


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateOrderNumber();
            string orderNumber;
            bool isOrderNumAlreadyExist = true;

            while (isOrderNumAlreadyExist)
            {
                orderNumber = GenerateOrderNumber();

                isOrderNumAlreadyExist = CheckIfOrderNumberExists(orderNumber);

                textBox1.Text = orderNumber;
            }

            groupBox1.Enabled = true;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button7.Enabled = false;
            dataGridView1.Enabled = true;

            textBox2.Focus();
        }

        public void Reset()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            



        }
        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
            groupBox1.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
           
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            comboBox2.SelectedItem = "";

            
            MessageBox.Show("Order Cancelled Successfully", "New Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Book where BookName='" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {
                textBox3.Text = dr["Author"].ToString();
                textBox4.Text = dr["Price"].ToString();
                textBox6.Text = dr["Stock"].ToString();


            }
            con.Close();
            //textBox7.Text = "";
            button7.Enabled = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

           

            int BookId = Convert.ToInt32(textBox11.Text);
            string BookName = comboBox1.SelectedItem.ToString();
            decimal Quantity = decimal.Parse(textBox7.Text);
            decimal Price = decimal.Parse(textBox4.Text);
            decimal Total = Price * Quantity;

            decimal subtotal = decimal.Parse(textBox8.Text);


            subtotal = subtotal + Total;

            if (BookName == "")
            {

                MessageBox.Show("Please Select Book", "Add New Book", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                textBox8.Text = subtotal.ToString();
                transactionDT.Rows.Add(BookId, BookName, Quantity, Price, Total);
                dataGridView1.DataSource = transactionDT;

            }


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string value = textBox9.Text;

            if (value == "")
            {
                MessageBox.Show("Add Discount First");
            }
            else
            {
                decimal total = decimal.Parse(textBox8.Text);
                decimal discount = decimal.Parse(textBox9.Text);

                decimal totaltopay = ((100 - discount) / 100) * total;
                textBox10.Text = totaltopay.ToString();


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cm);
            if (textBox1.Text == "" || dateTimePicker1.Value.Date.ToString() == "" || textBox2.Text == "" || comboBox2.SelectedIndex == -1 || textBox5.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
            {

                MessageBox.Show("Please Fiil All Feilds", "Add New Book", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else
            {


                con.Open();

                string query = "insert into Order_Info values('" + textBox1.Text + "','" + dateTimePicker1.Value.Date + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + comboBox2.SelectedItem.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Order Placed Successfully", "Add New Book", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();


            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
           
        }
       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawString("Abdulajij Book Store", new Font("Arial", 30, FontStyle.Bold), Brushes.Red, new Point(215, 5));
            e.Graphics.DrawString("45A,Lucky Chowk Solapur-413001", new Font("Arial", 16, FontStyle.Bold), Brushes.Chocolate, new Point(245, 55));
            e.Graphics.DrawString("Mobile:8485075796", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(310, 83));
            e.Graphics.DrawString(" Email:abdulajijkudale84@gmail.com", new Font("Arial", 16, FontStyle.Bold), Brushes.Blue, new Point(239, 110));

            e.Graphics.DrawString("Date : " + DateTime.Now.ToShortDateString(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(25, 150));
            e.Graphics.DrawString("Order Number : " + textBox1.Text.Trim(), new Font("Arial", 15, FontStyle.Bold), Brushes.Red, new Point(25, 185));

            e.Graphics.DrawString("Customer Name : " + textBox2.Text.Trim(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(25, 220));
            e.Graphics.DrawString("Mobile No : " + textBox5.Text.Trim(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(440, 220));


            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 250));

            e.Graphics.DrawString("Book Id", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(30, 270));
            e.Graphics.DrawString("Book Name", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(150, 270));
            e.Graphics.DrawString("Quantity", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(380, 270));
            e.Graphics.DrawString("Price", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(530, 270));
            e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(670, 270));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 280));

            int height = 295;
            for (int l = numberOfItemsPrintedSoFar; l < dataGridView1.Rows.Count; l++)
            {
                numberOfItemsPerPage = numberOfItemsPerPage + 1;
                if (numberOfItemsPerPage <= 50)
                {
                    numberOfItemsPrintedSoFar++;

                    if (numberOfItemsPrintedSoFar <= dataGridView1.Rows.Count)
                    {
                       
                        height += dataGridView1.Rows[0].Height;
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[0].FormattedValue.ToString(), dataGridView1.Font = new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(50, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[3].FormattedValue.ToString(), dataGridView1.Font = new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(530, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[1].FormattedValue.ToString(), dataGridView1.Font = new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(150, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[2].FormattedValue.ToString(), dataGridView1.Font = new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(400, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                        e.Graphics.DrawString(dataGridView1.Rows[l].Cells[4].FormattedValue.ToString(), dataGridView1.Font = new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(670, height, dataGridView1.Columns[0].Width, dataGridView1.Rows[0].Height));
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }

                }
                else
                {
                    numberOfItemsPerPage = 0;
                    e.HasMorePages = true;
                    return;

                }


            }
            numberOfItemsPerPage = 0;
            numberOfItemsPrintedSoFar = 0;

            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, height));

            e.Graphics.DrawString("Total Amount Rs :           " + textBox8.Text.Trim(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, height + 30));
            e.Graphics.DrawString("Discount (%) :                  " + textBox9.Text.Trim(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, height + 70));
            e.Graphics.DrawString("Total To Pay Rs :             " + textBox10.Text.Trim(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, height + 110));
             //e.Graphics.DrawString("GST (3%) Rs :                       " + textBox12.Text.Trim(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new Point(500, height + 90));



        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}



