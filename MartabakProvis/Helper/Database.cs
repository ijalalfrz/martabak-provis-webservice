using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MartabakProvis.Helper
{
    public class Database
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Database()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "85.10.205.173";
            database = "martabakprovis";
            uid = "mamenkece";
            password = "rahasiaku123";
            string connectionString = String.Format(
            "server={0};Port={1}; database={2};UID={3};password={4}",
            server, "3307", database, uid, password);

            connection = new MySqlConnection(connectionString);
        }

        public bool Open()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return true;
        }
        public bool Close()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return true;
        }
    }
}
