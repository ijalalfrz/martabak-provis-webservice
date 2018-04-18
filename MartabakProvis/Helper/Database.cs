﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
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
            server = "127.0.0.1";
            database = "db_martabak";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

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