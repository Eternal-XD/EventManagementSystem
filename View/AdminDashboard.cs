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
    public partial class AdminDashboard: Form
    {
        public AdminDashboard()
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
            changePanel(new AddOrganizer());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changePanel(new RevenueReport());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changePanel(new RemoveOrganizer());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.Show();
        }
    }
}
