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
    public partial class AttendeeDashboard: Form
    {
        public AttendeeDashboard()
        {
            InitializeComponent();
        }

        public void changePanel(object Form)
        {
            if (this.panel2.Controls.Count > 0)
            {
                this.panel2.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(f);
            this.panel2.Tag = f;
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changePanel(new ViewPurchasedTicket());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changePanel(new PurchaseTickets(this));
        }

        public void paymentGateway(int ticket_id, int quantity)
        {
           changePanel(new PaymentGateWay(ticket_id, quantity));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changePanel(new EditProfile());
        }
    }
}
