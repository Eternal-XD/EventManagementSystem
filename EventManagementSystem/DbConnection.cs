using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EventManagementSystem   // make sure spelling matches your project
{
    public class DbConnection
    {
        // connection string to your database
        private readonly string connectionString = "server=localhost;uid=root;pwd=;port=3306;database=ems;";

        // THIS method is what your controller is trying to call
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
