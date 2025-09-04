using EventManagmentSystem.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace EventManagmentSystem.Controller
{
    class OrganizerController
    {
        DbConnection dbConnection = new DbConnection();

        // existence check (blocks duplicates)
        private bool OrganizerExists(string name, string email, MySqlConnection conn)
        {
            const string sql = "SELECT COUNT(1) FROM organizer WHERE name=@name OR email=@email";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", name ?? string.Empty);
                cmd.Parameters.AddWithValue("@email", email ?? string.Empty);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        public void addOrganizer(Organizers organizer)
        {
            try
            {
                using (var connection = new MySqlConnection(dbConnection.connectionString))
                {
                    connection.Open();

                    //block duplicates by name/email 
                    if (OrganizerExists(organizer.Name, organizer.Email, connection))
                    {
                        MessageBox.Show("An organizer with the same name or email already exists.");
                        return;
                    }

                    string query = "INSERT INTO organizer (name, password, contactnumber, email, gender) VALUES " +
                                   "(@username, @password, @contact, @email, @Gender)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", organizer.Name);
                        command.Parameters.AddWithValue("@password", organizer.Password);
                        command.Parameters.AddWithValue("@contact", organizer.ContactNumbers);
                        command.Parameters.AddWithValue("@email", organizer.Email ?? string.Empty);
                        command.Parameters.AddWithValue("@gender", organizer.Gender);

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Organizer added successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add organizer.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // safe delete by ID 
        public void DeleteOrganizerById(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(dbConnection.connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand("DELETE FROM organizer WHERE id=@id LIMIT 1", connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Organizer deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete organizer.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // delete by name, only remove ONE matching row (not all)
        public void DeleteOrganizer(string name)
        {
            try
            {
                using (var connection = new MySqlConnection(dbConnection.connectionString))
                {
                    connection.Open();

                    // get a single matching id (oldest/lowest id)
                    int id = -1;
                    using (var get = new MySqlCommand("SELECT id FROM organizer WHERE name=@name ORDER BY id LIMIT 1", connection))
                    {
                        get.Parameters.AddWithValue("@name", name);
                        var obj = get.ExecuteScalar();
                        if (obj == null)
                        {
                            MessageBox.Show("Organizer not found.");
                            return;
                        }
                        id = Convert.ToInt32(obj);
                    }

                    // delete exactly that one row
                    using (var del = new MySqlCommand("DELETE FROM organizer WHERE id=@id LIMIT 1", connection))
                    {
                        del.Parameters.AddWithValue("@id", id);
                        int result = del.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Organizer deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete organizer.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void DeleteTicketsByOrganizerId(int organizerId)
        {
            try
            {
                using (var connection = new MySqlConnection(dbConnection.connectionString))
                {
                    connection.Open();

                    string query = @"DELETE t FROM ticket t
                         JOIN events e ON t.event_id = e.id
                         WHERE e.organizer_id = @orgId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@orgId", organizerId);
                        int result = command.ExecuteNonQuery();
                        MessageBox.Show($"{result} ticket(s) deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting tickets: " + ex.Message);
            }
        }

        public string getOrganizerPassword(string name)
        {
            try
            {
                using (var connection = new MySqlConnection(dbConnection.connectionString))
                {
                    connection.Open();
                    string query = "SELECT password FROM organizer WHERE name = @name";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        string password = command.ExecuteScalar()?.ToString();
                        return password;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        public List<string> GetAllOrganizerUsernames()
        {
            List<string> usernames = new List<string>();

            try
            {
                using (var connection = new MySqlConnection(dbConnection.connectionString))
                {
                    connection.Open();
                    string query = "SELECT name FROM organizer";
                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usernames.Add(reader["name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return usernames;
        }

        public int getOrganizerId(string name)
        {
            try
            {
                using (var connection = new MySqlConnection(dbConnection.connectionString))
                {
                    connection.Open();
                    string query = "SELECT id FROM organizer WHERE name = @name";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        var obj = command.ExecuteScalar();
                        if (obj == null) return -1;
                        return Convert.ToInt32(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return -1; // Return -1 to indicate an error
            }
        }

        public Organizers getOrganizersfromId(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(dbConnection.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM organizer WHERE id = @id";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Organizers organizer = new Organizers(
                                    reader["name"].ToString(),
                                    reader["password"].ToString(),
                                    reader["contactnumber"].ToString(),
                                    reader["email"].ToString(),
                                    reader["gender"].ToString()
                                );
                                organizer.Id = Convert.ToInt32(reader["id"]);
                                return organizer;
                            }
                            else
                            {
                                return null; // No organizer found with the given ID
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        public void UpdateOrganizer(int id, string name, string password, string contact, string email, string gender)
        {
            try
            {
                using (var conn = new MySqlConnection(dbConnection.connectionString))
                {
                    conn.Open();
                    var cmd = new MySqlCommand(
                        "UPDATE organizer SET name=@nm, password=@pw, contactnumber=@ct, email=@em, gender=@gn WHERE id=@id",
                        conn
                    );
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nm", name);
                    cmd.Parameters.AddWithValue("@pw", password);
                    cmd.Parameters.AddWithValue("@ct", contact);
                    cmd.Parameters.AddWithValue("@em", email ?? string.Empty);
                    cmd.Parameters.AddWithValue("@gn", gender);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating organizer: " + ex.Message);
            }
        }

        public DataTable getEventDetails(int event_id)
        {
            try
            {
                using (var connection = new MySqlConnection(dbConnection.connectionString))
                {
                    connection.Open();

                    string query = @"SELECT 
                                    a.name AS 'Attendee Name',
                                    a.contactnumber AS 'Attendee Contact',
                                    p.quantity AS 'Tickets Bought',
                                    p.total AS Total,
                                    t.tickettype AS 'Ticket Type'
                                FROM 
                                    purchase p
                                JOIN 
                                    attendee a ON p.attendee_id = a.id
                                JOIN 
                                    ticket t ON p.ticket_id = t.id
                                WHERE 
                                    t.event_id = @event_id;
                                ";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@event_id", event_id);
                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable; // Return the DataTable containing event details
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null; // Return null in case of an error
            }
        }
    }
}

