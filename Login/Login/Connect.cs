using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Login
{
    public class Connect
    {
        public MySqlConnection connection;

        string db;
        string srv;
        string usr;
        string pass;

        string connectionstring;

        public Connect()
        {
            srv = "localhost";
            db = "login";
            usr = "root";
            pass = "";

            connectionstring = "SERVER=" + srv + ";" + "DATABASE=" + db + ";" + "UID=" + usr + ";"
                + "PASSWORD=" + pass + ";" + "SslMode=None;";

            connection = new MySqlConnection(connectionstring);

            connection.Open();
        }
    }
}