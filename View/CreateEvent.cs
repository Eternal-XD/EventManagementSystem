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
    public partial class CreateEvent: Form
    {
        public CreateEvent()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CreateEvent_Load(object sender, EventArgs e)
        {
            //show date and time in datetime picker
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now; // Prevent past dates
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(1); // Allow up to one year in the future
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm"; // Custom format for date and time
            dateTimePicker1.Format = DateTimePickerFormat.Custom; // Set the format to custom
            dateTimePicker1.ShowUpDown = true; // Show only time selection

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string eventName = textBox1.Text;
            string eventDescription = textBox2.Text;
            DateTime eventDate = dateTimePicker1.Value;
            string eventLocation = textBox3.Text;
            Organizers organizers = new OrganizerController().getOrganizersfromId(Session.Id);

            if (string.IsNullOrEmpty(eventName) || string.IsNullOrEmpty(eventDescription) ||
                string.IsNullOrEmpty(eventLocation))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

             Events newEvent = new Events(eventName,  eventDate, eventDescription, eventLocation, organizers);



            new EventController().CreateEvent(newEvent);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            this.Hide();
        }
    }
}
