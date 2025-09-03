using EventManagmentSystem.Model;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace EventManagmentSystem.Controller
{
    class TicketController
    {
        DbConnection dbConnection = new DbConnection();

        public void CreateTicket(Ticket ticket)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "INSERT INTO ticket (event_id, tickettype, price, quantity, availability) VALUES (@eventid, @tickettype, @price, @quantity, @available)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@eventid", ticket.Event.Id);
                command.Parameters.AddWithValue("@tickettype", ticket.TicketType);
                command.Parameters.AddWithValue("@price", ticket.Price);
                command.Parameters.AddWithValue("@quantity", ticket.Quantity);
                command.Parameters.AddWithValue("@available", ticket.Available);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Ticket created successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to create ticket.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        public Ticket getTickeybyEventandType(int eventId, string ticketType)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "SELECT * FROM ticket WHERE event_id = @eventid AND tickettype = @tickettype";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@eventid", eventId);
                command.Parameters.AddWithValue("@tickettype", ticketType);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Ticket ticket = new Ticket(
                        new EventController().getEventById(Convert.ToInt32(reader["event_id"])),
                        reader["tickettype"].ToString(),
                        Convert.ToDouble(reader["price"]),
                        Convert.ToInt32(reader["quantity"])
                    )
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Available = Convert.ToBoolean(reader["availability"])
                    };
                    return ticket;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return null;
        }

        public void UpdateTicket(Ticket ticket)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "UPDATE ticket SET price = @price, quantity = @quantity, availability = @available WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", ticket.Id);
                command.Parameters.AddWithValue("@price", ticket.Price);
                command.Parameters.AddWithValue("@quantity", ticket.Quantity);
                command.Parameters.AddWithValue("@available", ticket.Available);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Ticket updated successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to update ticket.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public Ticket getTicketbyId(int ticketId)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "SELECT * FROM ticket WHERE id = @ticketid";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ticketid", ticketId);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Ticket ticket = new Ticket(
                        new EventController().getEventById(Convert.ToInt32(reader["event_id"])),
                        reader["tickettype"].ToString(),
                        Convert.ToDouble(reader["price"]),
                        Convert.ToInt32(reader["quantity"])
                    )
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Available = Convert.ToBoolean(reader["availability"])
                    };
                    return ticket;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return null;
        }


        public void reduceTicketQuantity(int ticketId, int quantity)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "UPDATE ticket SET quantity = quantity - @quantity WHERE id = @ticketid";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ticketid", ticketId);
                command.Parameters.AddWithValue("@quantity", quantity);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Ticket quantity reduced successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to reduce ticket quantity.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

       
    }
}
