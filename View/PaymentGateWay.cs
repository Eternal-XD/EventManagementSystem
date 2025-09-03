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
    public partial class PaymentGateWay: Form
    {
        private int ticketId;
        private int quantity;
        public PaymentGateWay(int ticketId, int quantity)
        {
            InitializeComponent();
            this.ticketId = ticketId;
            this.quantity = quantity;
        }

        private void PaymentGateWay_Load(object sender, EventArgs e)
        {
            //datetimepick should be empty
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.CustomFormat = "MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //set the default value of the card type to visa
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get the card type
            string cardType = "";
            if (radioButton1.Checked)
            {
                cardType = "Visa";
            }
            else if (radioButton2.Checked)
            {
                cardType = "MasterCard";
            }

            //Validate the card number
            string cardNumber = textBox1.Text;
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length != 16 )
            {
                MessageBox.Show("Please enter a valid card number.");
                return;
            }

            string nameOnCard = textBox2.Text;
            if (string.IsNullOrEmpty(nameOnCard))
            {
                MessageBox.Show("Please enter the name on the card.");
                return;
            }

            DateTime expiryDate = dateTimePicker1.Value;
            if (expiryDate < DateTime.Now)
            {
                MessageBox.Show("Please enter a valid expiry date.");
                return;
            }
            string cvv = textBox4.Text;
            if (string.IsNullOrEmpty(cvv) || cvv.Length != 3 || !cvv.All(char.IsDigit))
            {
                MessageBox.Show("Please enter a valid CVV.");
                return;
            }

            Ticket ticket = new Controller.TicketController().getTicketbyId(ticketId);

            double totalAmount = ticket.Price * quantity;

            Purchase purchase = new Purchase(ticketId, quantity);
            purchase.Total = totalAmount;

            Payment payment = new Payment(0, cardType, cardNumber, nameOnCard, expiryDate, cvv);

            new PurchaseController().CreatePurchase(purchase, payment);

            this.Close();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
