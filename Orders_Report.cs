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
    public partial class Orders_Report : Form
    {
        public Orders_Report()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'OrdersDataSet.Order_Info' table. You can move, or remove it, as needed.
            this.Order_InfoTableAdapter.Fill(this.OrdersDataSet.Order_Info);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
