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

namespace Book_Store_Management_System
{
    public partial class Orders_Record : Form
    {

        string cb = ConfigurationManager.ConnectionStrings["dbcs_3"].ConnectionString;

        public Orders_Record()
        {
            InitializeComponent();
            populate();
            fillcombobox();
        }
        public void fillcombobox()
        {
            SqlConnection con = new SqlConnection(cb);
            string sql = "select *from Order_Info";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader myreader;
            con.Open();
            myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                string CustomerName = myreader.GetInt32(0).ToString();
                comboBox1.Items.Add(CustomerName);

            }

            con.Close();
        }
        public void populate()
        {
            SqlConnection con = new SqlConnection(cb);
            con.Open();
            string query = "select *from Order_Info";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            con.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cb);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Order_Info where OrderNumber ='" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["CustomerName"].ToString();
                textBox2.Text = dr["TransactionDate"].ToString();
                textBox3.Text = dr["TotalAmount"].ToString();
                textBox3.Text = dr["TotalAmount"].ToString();
                textBox4.Text = dr["Discount"].ToString();
                textBox5.Text = dr["TotaltoPay"].ToString();
                textBox6.Text = dr["PaymentType"].ToString();

            }
            con.Close();
        }
    }
}
