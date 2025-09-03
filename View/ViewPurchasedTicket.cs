using EventManagmentSystem.Model;
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
    public partial class ViewPurchasedTicket: Form
    {
        public ViewPurchasedTicket()
        {
            InitializeComponent();
        }

        private void ViewPurchasedTicket_Load(object sender, EventArgs e)
        {
            DataTable purchasedTickets = new Controller.AttendeeController().getAlltheTicketsByAttendee(Session.Id);

            if (purchasedTickets.Rows.Count > 0)
            {
                dataGridView1.DataSource = purchasedTickets;
            }
            else
            {
                MessageBox.Show("No tickets purchased yet.");
            }
        }
    }
}
