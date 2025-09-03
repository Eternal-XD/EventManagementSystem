using EventManagmentSystem.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManagmentSystem.Controller
{
    class PurchaseController
    {
        DbConnection dbConnection = new DbConnection();
        public void CreatePurchase(Purchase purchase, Payment payment)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();

                string query = "INSERT INTO purchase (ticket_id, attendee_id, quantity, total) VALUES (@ticketid, @attendeeID, @quantity, @total)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ticketid", purchase.Ticket_id);
                command.Parameters.AddWithValue("@attendeeID", purchase.Attendee_id);
                command.Parameters.AddWithValue("@quantity", purchase.Quantity);
                command.Parameters.AddWithValue("@total", purchase.Total);
                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    // Get the last inserted ID
                    command.CommandText = "SELECT LAST_INSERT_ID()";
                    purchase.Id = Convert.ToInt32(command.ExecuteScalar());
                    // insert into payment table
                    query = "INSERT INTO payment (purchase_id, type, number, name, expiry, ccv) VALUES (@purchaseId, @type, @number, @name, @expiry, @ccv)";
                    command.CommandText = query;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@purchaseId", purchase.Id);
                    command.Parameters.AddWithValue("@type", payment.CardType);
                    command.Parameters.AddWithValue("@number", payment.CardNumber);
                    command.Parameters.AddWithValue("@name", payment.NameOnCard);
                    command.Parameters.AddWithValue("@expiry", payment.ExpiryDate);
                    command.Parameters.AddWithValue("@ccv", payment.Ccv);

                    result = command.ExecuteNonQuery();
                    if (result > 0)
                    {

                        new TicketController().reduceTicketQuantity(purchase.Ticket_id, purchase.Quantity);

                        MessageBox.Show("Purchase Completed successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to create payment.");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to create purchase.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void DeletePurchasesByAttendee(int attendeeId)
        {
            using (var connection = new MySqlConnection(dbConnection.connectionString))
            {
                connection.Open();
                var cmd1 = new MySqlCommand("DELETE FROM payment WHERE purchase_id IN (SELECT id FROM purchase WHERE attendee_id = @id)", connection);
                cmd1.Parameters.AddWithValue("@id", attendeeId);
                cmd1.ExecuteNonQuery();

                var cmd2 = new MySqlCommand("DELETE FROM purchase WHERE attendee_id = @id", connection);
                cmd2.Parameters.AddWithValue("@id", attendeeId);
                cmd2.ExecuteNonQuery();
            }
        }


    }
}
