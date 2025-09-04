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
    public partial class OrganizerDashboard: Form
    {
        public OrganizerDashboard()
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

        private void button1_Click(object sender, EventArgs e)
        {
            changePanel(new CreateEvent());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changePanel(new EditEvent());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changePanel(new DeleteEvent());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changePanel(new AddTicket());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            changePanel(new EditTicket());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            changePanel(new ViewEventDetails());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            changePanel(new EditProfile());
        }
    }
}
