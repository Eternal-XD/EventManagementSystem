using EventManagmentSystem.Controller;
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
    public partial class Signup: Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string contact = textBox3.Text;
            string email = textBox4.Text;
            string gender = comboBox1.Text;

            // Check if any field is empty
            if (username == null || password == null || contact == null || gender == null || email == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            Attendee attendee = new Attendee(username, password, contact, email, gender);

            new AttendeeController().addAttendee(attendee);

            this.Hide();
            new Form1().Show();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
