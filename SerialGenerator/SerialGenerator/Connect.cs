using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialGenerator
{
    internal class Connect
    {
        public MySqlConnection connection;
        string db;
        string srv;
        string usr;
        string pass;

        string connectionString;

        public Connect()
        {
            srv = "localhost";
            db = "serials";
            usr = "root";
            pass = "";

            connectionString = $"SERVER={srv};DATABASE={db};UID={usr};PASSWORD={pass};SslMode=None";

            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Sikeres kapcsolódás!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
