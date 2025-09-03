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
    class ReportController
    {
        DbConnection dbConnection = new DbConnection();
        public DataTable generateRevenuereport()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(dbConnection.connectionString);
                connection.Open();

                string query = "SELECT e.name AS EventName, e.date AS EventDate, SUM(p.quantity) AS TotalTicketsSold, SUM(p.total) AS TotalRevenue FROM purchase p JOIN ticket t ON p.ticket_id = t.id JOIN events e ON t.event_id = e.id GROUP BY  e.id, e.name, e.date ORDER BY e.date;";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable revenueReport = new DataTable();
                adapter.Fill(revenueReport);
                connection.Close();
                return revenueReport;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating revenue report: " + ex.Message);
                return null;
            }
        }
    }
}
