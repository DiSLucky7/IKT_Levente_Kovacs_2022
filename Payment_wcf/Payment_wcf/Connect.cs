using MySql.Data.MySqlClient;

namespace Payment_wcf
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
            db = "payment";
            usr = "root";
            pass = "";

            connectionstring = "SERVER=" + srv + ";" + "DATABASE=" + db + ";" + "UID=" + usr + ";"
                + "PASSWORD=" + pass + ";" + "SslMode=None;";

            connection = new MySqlConnection(connectionstring);

            connection.Open();

        }
    }
}