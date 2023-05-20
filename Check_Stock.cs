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
    public partial class Check_Stock : Form
    {

        string cs = ConfigurationManager.ConnectionStrings["dbcs_1"].ConnectionString;

        public Check_Stock()
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
        private void Form6_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
    }

}