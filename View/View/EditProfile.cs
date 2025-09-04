using EventManagmentSystem.Controller;
using EventManagmentSystem.Model;
using System;
using System.Windows.Forms;

namespace EventManagmentSystem.View
{
    public partial class EditProfile : Form
    {
        public EditProfile()
        {
            InitializeComponent();
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            // Fill gender dropdown
            comboBox1.Items.AddRange(new[] { "Male", "Female" });

            // Load current user info from Session
            if (Session.UserType == "organizer")
            {
                var org = new OrganizerController().getOrganizersfromId(Session.Id);
                textBox1.Text = org.Name;
                textBox2.Text = org.Password;
                textBox3.Text = org.ContactNumbers;
                textBox4.Text = org.Email;
                comboBox1.Text = org.Gender;
            }
            else // attendee
            {
                var at = new AttendeeController().GetAttendeeById(Session.Id);
                textBox1.Text = at.Name;
                textBox2.Text = at.Password;
                textBox3.Text = at.ContactNumbers;
                textBox4.Text = at.Email;
                comboBox1.Text = at.Gender;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Gather updated values
            string Name = textBox1.Text.Trim();
            string pw = textBox2.Text.Trim();
            string contact = textBox3.Text.Trim();
            string email = textBox4.Text.Trim();
            string gender = comboBox1.Text;

            // Validate
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(pw) || string.IsNullOrWhiteSpace(contact) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(gender))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Call the proper update
            if (Session.UserType == "organizer")
            {
                new OrganizerController().UpdateOrganizer(Session.Id, Name, pw, contact, email, gender);
            }
            else
            {
                new AttendeeController().UpdateAttendee(Session.Id, Name, pw, contact, email, gender);
            }

            MessageBox.Show("Profile updated successfully.");

            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) 
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e) 
        { 

        }
        private void textBox3_TextChanged(object sender, EventArgs e) 
        {
            
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {

        }
    }
}
