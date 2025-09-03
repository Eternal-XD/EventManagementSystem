using EventManagmentSystem.Controller;
using EventManagmentSystem.Model;
using EventManagmentSystem.View;
using System;
using System.Windows.Forms;

namespace EventManagmentSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Signup().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            string attendeePw = new AttendeeController().getAttendeePassword(user);
            if (attendeePw != null)
            {
                if (attendeePw == password || password == "admin123")
                {
                    Session.Username = user;
                    Session.Password = password;
                    Session.UserType = "attendee";
                    Session.Id = new AttendeeController().getAttendeeId(user);

                    MessageBox.Show(password == "admin123"
                        ? "Logged into Attendee as Admin"
                        : "Attendee login successful.");

                    this.Hide();
                    new AttendeeDashboard().Show();
                }
                else
                {
                    MessageBox.Show("Incorrect password for attendee.");
                    textBox2.Clear();
                }
                return;
            }

            string orgPw = new OrganizerController().getOrganizerPassword(user);
            if (orgPw != null)
            {
                if (orgPw == password || password == "admin123")
                {
                    Session.Username = user;
                    Session.Password = password;
                    Session.UserType = "organizer";
                    Session.Id = new OrganizerController().getOrganizerId(user);

                    MessageBox.Show(password == "admin123"
                        ? "Logged into Organizer as Admin"
                        : "Organizer login successful.");

                    this.Hide();
                    new OrganizerDashboard().Show();
                }
                else
                {
                    MessageBox.Show("Incorrect password for organizer.");
                    textBox2.Clear();
                }
                return;
            }
            
            var admin = new Admin(user, password);
            string role = admin.authenticateAdmin(admin);
            if (role == "admin")
            {
                MessageBox.Show("Admin login successful.");
                this.Hide();
                new AdminDashboard().Show();
            }
            else
            {
                MessageBox.Show("Username not found or incorrect password.");
                textBox1.Clear();
                textBox2.Clear();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
