using EventManagmentSystem.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManagmentSystem.Controller
{
    class AttendeeController
    {
        DbConnection dbConnection = new DbConnection();
        public void addAttendee(Attendee attendee)
        {
            try
            {
                using (var connection = new MySqlConnection(dbConnection.connectionString))
                {
                    connection.Open();

                    var fetchCmd = new MySqlCommand("SELECT name FROM attendee", connection);
                    var reader = fetchCmd.ExecuteReader();
                    var allNames = new List<string>();
                    while (reader.Read())
                        allNames.Add(reader.GetString(0));
                    reader.Close();

                    
                    foreach (var existing in allNames)
                    {
                        if (string.Equals(existing, attendee.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("That username is already taken. Please choose another.");
                            return;
                        }
                    }

                    
                    var insertQuery =
                        "INSERT INTO attendee (name, password, contactnumber, email, gender) " +
                        "VALUES (@name, @password, @contactnumber, @email, @gender)";
                    var insertCmd = new MySqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@name", attendee.Name);
                    insertCmd.Parameters.AddWithValue("@password", attendee.Password);
                    insertCmd.Parameters.AddWithValue("@contactnumber", attendee.ContactNumbers);
                    insertCmd.Parameters.AddWithValue("@email", attendee.Email);
                    insertCmd.Parameters.AddWithValue("@gender", attendee.Gender);

                    int result = insertCmd.ExecuteNonQuery();
                    if (result > 0)
                        MessageBox.Show("Attendee added successfully.");
                    else
                        MessageBox.Show("Failed to add attendee.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public string getAttendeePassword(string name)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "SELECT password FROM attendee WHERE name = @name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                string password = command.ExecuteScalar()?.ToString();
                connection.Close();
                return password;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        public int getAttendeeId(string name)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = "SELECT id FROM attendee WHERE name = @name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                int id = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return -1; // Return -1 to indicate an error
            }
        }

        public List<string> GetAllAttendeeUsernames()
        {
            var usernames = new List<string>();

            try
            {   //checking 'using' instead of connection.open and .close
                using (var connection = new MySqlConnection(dbConnection.connectionString))
                {
                    connection.Open();
                    var command = new MySqlCommand("SELECT name FROM attendee", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        usernames.Add(reader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return usernames;
        }

        public void DeleteAttendee(string name)
        {
            using (var connection = new MySqlConnection(dbConnection.connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand("DELETE FROM attendee WHERE name = @name", connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable getAlltheTicketsByAttendee(int attendeeId)
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();
                string query = @"SELECT 
                                    e.name AS EventName,
                                    e.date AS EventDate,
                                    p.quantity AS QuantityBought,
                                    t.tickettype AS TicketType,
                                    p.total AS Total
                                FROM 
                                    purchase p
                                JOIN 
                                    ticket t ON p.ticket_id = t.id
                                JOIN 
                                    events e ON t.event_id = e.id
                                WHERE 
                                    p.attendee_id = @id;
                            ";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", attendeeId);
                MySqlDataReader reader = command.ExecuteReader();

                DataTable tickettable = new DataTable();
                tickettable.Columns.Add("EventName", typeof(string));
                tickettable.Columns.Add("EventDate", typeof(DateTime));
                tickettable.Columns.Add("QuantityBought", typeof(int));
                tickettable.Columns.Add("TicketType", typeof(string));
                tickettable.Columns.Add("Total", typeof(decimal));
                while (reader.Read())
                {
                    DataRow row = tickettable.NewRow();
                    row["EventName"] = reader["EventName"];
                    row["EventDate"] = reader["EventDate"];
                    row["QuantityBought"] = reader["QuantityBought"];
                    row["TicketType"] = reader["TicketType"];
                    row["Total"] = reader["Total"];
                    tickettable.Rows.Add(row);
                }
                if (tickettable.Rows.Count == 0)
                {
                    MessageBox.Show("No tickets found for this attendee.");
                }
                 connection.Close();
                return tickettable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null; // Return null to indicate an error
            }
            
        }

        public Attendee GetAttendeeById(int id)
        {
            try
            {
                using (var conn = new MySqlConnection(dbConnection.connectionString))
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "SELECT * FROM attendee WHERE id = @id",
                        conn
                    );
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var at = new Attendee(
                                reader["name"].ToString(),
                                reader["password"].ToString(),
                                reader["contactnumber"].ToString(),
                                reader["email"].ToString(),
                                reader["gender"].ToString()
                            );
                            at.Id = Convert.ToInt32(reader["id"]);
                            return at;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching attendee: " + ex.Message);
            }
            return null;
        }

        public void UpdateAttendee(int id, string name, string password, string contact, string email, string gender)
        {
            try
            {
                using (var conn = new MySqlConnection(dbConnection.connectionString))
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "UPDATE attendee SET name=@nm, password=@pw, contactnumber=@ct, email=@em, gender=@gn WHERE id=@id",
                        conn
                    );
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nm", name);
                    cmd.Parameters.AddWithValue("@pw", password);
                    cmd.Parameters.AddWithValue("@ct", contact);
                    cmd.Parameters.AddWithValue("@em", email);
                    cmd.Parameters.AddWithValue("@gn", gender);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

    }
}
