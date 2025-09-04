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
    public partial class AddTicket: Form
    {
        public AddTicket()
        {
            InitializeComponent();
        }

        private void AddTicket_Load(object sender, EventArgs e)
        {
            List<Events> events = new Controller.EventController().getEventsbyOrganizer(Session.Id);

            if (events.Count > 0)
            {
                comboBox1.DataSource = events;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No events found for the organizer.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int eventId = (int)comboBox1.SelectedValue;
            Events selectedEvent = new Controller.EventController().getEventById(eventId);
            string ticketType = comboBox2.Text;

            // TryParse price
            if (!double.TryParse(textBox2.Text, out double price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price");
                return;
            }

            // TryParse quantity
            if (!int.TryParse(textBox1.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity");
                return;
            }

            Ticket ticket = new Ticket(selectedEvent, ticketType, price, quantity);
            new Controller.TicketController().CreateTicket(ticket);

            AddTicket_Load(sender, e); // refresh


            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();

            this.Hide();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
