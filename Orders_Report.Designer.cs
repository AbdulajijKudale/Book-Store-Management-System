
namespace Book_Store_Management_System
{
    partial class Orders_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Order_InfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrdersDataSet = new Book_Store_Management_System.OrdersDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Order_InfoTableAdapter = new Book_Store_Management_System.OrdersDataSetTableAdapters.Order_InfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Order_InfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // Order_InfoBindingSource
            // 
            this.Order_InfoBindingSource.DataMember = "Order_Info";
            this.Order_InfoBindingSource.DataSource = this.OrdersDataSet;
            // 
            // OrdersDataSet
            // 
            this.OrdersDataSet.DataSetName = "OrdersDataSet";
            this.OrdersDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Order_InfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Book_Store_Management_System.customer_report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1924, 1055);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // Order_InfoTableAdapter
            // 
            this.Order_InfoTableAdapter.ClearBeforeFill = true;
            // 
            // Orders_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Orders_Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orders Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Order_InfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Order_InfoBindingSource;
        private OrdersDataSet OrdersDataSet;
        private OrdersDataSetTableAdapters.Order_InfoTableAdapter Order_InfoTableAdapter;
    }
}