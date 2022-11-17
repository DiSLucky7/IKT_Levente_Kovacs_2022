using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Payment_wcf
{
    public class Service1 : IService1
    {
        Connect c = new Connect();
        List<Customer> cust = new List<Customer>();
        public List<Customer> getCustomers()
        {
            string qry = "SELECT * FROM customer";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = c.connection;
            cmd.CommandText = qry;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Customer customer = new Customer();

                customer.Id = dr.GetInt32(0);
                customer.Name = dr.GetString(1);
                customer.City = dr.GetString(2);
                customer.Age = dr.GetInt32(3);

                cust.Add(customer);
            }

            return cust;

        }
        public Customer getCustomer(string id)
        {

            try
            {
                string qry = "SELECT * FROM `customer` WHERE id=@id";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.connection;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = qry;

                MySqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                Customer customer = new Customer();

                customer.Id = dr.GetInt32(0);
                customer.Name = dr.GetString(1);
                customer.City = dr.GetString(2);
                customer.Age = dr.GetInt32(3);


                dr.Close();
                return customer;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string deleteCustomer(string id)//*Ok
        {
            try
            {
                string qry = "DELETE FROM customer WHERE id=" + id;
                MySqlCommand cmd = new MySqlCommand(qry, c.connection);

                cmd.ExecuteNonQuery();

                return "Felhasználó törölve!";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public string postCustomer(string id, string name, string age, string city)//*Ok
        {
            try
            {
                string qry = "UPDATE `customer` SET `Name`=@name,`Age`=@age,`City`=@city WHERE Id=@id;";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.connection;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.CommandText = qry;

                cmd.ExecuteNonQuery();

                return "Módosítás elvégezve!";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public string putCustomer(Customer customer)//*Ok
        {
            try
            {
                string qry = "INSERT INTO `customer`(`name`, `city`, `age`) " +
                    "VALUE (@name, @city,@age);";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.connection;
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@age", customer.Age);
                cmd.Parameters.AddWithValue("@city", customer.City);
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();

                return "Felhasználó sikeresen hozzáadva!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string patchCustomer(Customer customer)//*Ok
        {
            try
            {
                string qry = "UPDATE `customer` SET `name`=@name,`age`=@age,`city`=@city WHERE `id`=@id;";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.connection;
                cmd.Parameters.AddWithValue("@id", customer.Id);
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@age", customer.Age);
                cmd.Parameters.AddWithValue("@city", customer.City);
                cmd.CommandText = qry;

                cmd.ExecuteNonQuery();

                return "Módosítás elvégezve!";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

    }
}
