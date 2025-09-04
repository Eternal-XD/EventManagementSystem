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
    public partial class AddOrganizer: Form
    {
        public AddOrganizer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string contact = textBox3.Text;
            string email = textBox4.Text;
            string gender = comboBox1.Text;

            Organizers organizer = new Organizers(username, password, contact, email, gender);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                new Controller.OrganizerController().addOrganizer(organizer);
                
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            this.Hide();
        }

        private void AddOrganizer_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
