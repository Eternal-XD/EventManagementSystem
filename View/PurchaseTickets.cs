using EventManagmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace EventManagmentSystem.View
{
    public partial class PurchaseTickets : Form
    {
        private AttendeeDashboard attendeeDashboard;
        private int ticketId;

        public PurchaseTickets(AttendeeDashboard attendeeDashboard)
        {
            InitializeComponent();
            this.attendeeDashboard = attendeeDashboard;
        }

        private void PurchaseTickets_Load(object sender, EventArgs e)
        {
            List<Events> events = new Controller.EventController().getAllEvents();

            if (events != null && events.Count > 0)
            {
                comboBox1.DataSource = events;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
            else
            {
                MessageBox.Show("No events at the moment.");
            }

            // default ticket type
            if (comboBox2.Items.Count > 0 && comboBox2.SelectedIndex < 0)
                comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null) return;

            int eventId = (int)comboBox1.SelectedValue;
            string ticketType = comboBox2.Text;

            Ticket selectedTicket = new Controller.TicketController()
                .getTickeybyEventandType(eventId, ticketType);

            if (selectedTicket == null)
            {
                MessageBox.Show("Ticket not available for the selected type.");
                textBox1.Clear(); // Available Qty
                textBox2.Clear(); // Price
                ticketId = 0;
                return;
            }

            if (!selectedTicket.Available)
            {
                MessageBox.Show("Ticket is not available for purchase.");
                textBox1.Clear();
                textBox2.Clear();
                ticketId = 0;
                return;
            }

           
            // label3 -> "Price"          -> textBox2 (read-only)
            // label4 -> "Available Qty"  -> textBox1 (read-only)
            textBox2.Text = selectedTicket.Price.ToString("0.00", CultureInfo.InvariantCulture); // Price
            textBox1.Text = selectedTicket.Quantity.ToString();                                   // Available Quantity
            ticketId = selectedTicket.Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select an event.");
                return;
            }

            int eventId = (int)comboBox1.SelectedValue;
            string ticketType = comboBox2.Text;

            // Robust quantity parsing
            if (!int.TryParse(textBox3.Text?.Trim(), out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity (> 0).");
                textBox3.Focus();
                return;
            }

            Ticket selectedTicket = new Controller.TicketController()
                .getTickeybyEventandType(eventId, ticketType);

            if (selectedTicket == null)
            {
                MessageBox.Show("Ticket not available for the selected type.");
                return;
            }

            if (!selectedTicket.Available)
            {
                MessageBox.Show("This ticket is currently not available.");
                return;
            }

            if (quantity > selectedTicket.Quantity)
            {
                MessageBox.Show($"Only {selectedTicket.Quantity} tickets are left.");
                textBox3.Clear();
                return;
            }

         
            var currentUser = UserFactory.FromSession();                 // Attendee / Organizer / Admin
            double price = selectedTicket.Price;
            double subtotal = price * quantity;
            double finalTotal = currentUser.ApplyDiscount(subtotal);     // override for role-based rules

            // calculation 
            MessageBox.Show(
                $"Role: {currentUser.Role}\n" +
                $"Unit Price: {price:0.00}\n" +
                $"Quantity: {quantity}\n" +
                $"Subtotal: {subtotal:0.00}\n" +
                $"Final Total (after polymorphism): {finalTotal:0.00}",
                "Purchase Summary",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
         
            attendeeDashboard.paymentGateway(ticketId, quantity);
        }
    }
}

