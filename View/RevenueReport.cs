using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManagmentSystem.View
{
    public partial class RevenueReport: Form
    {
        public RevenueReport()
        {
            InitializeComponent();
        }

        private void RevenueReport_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new Controller.ReportController().generateRevenuereport();

            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
