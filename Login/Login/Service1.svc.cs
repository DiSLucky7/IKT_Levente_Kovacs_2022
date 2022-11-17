using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;


namespace Login
{
    public class Service1 : IService1
    {
        Connect c = new Connect();
        List<User> userList = new List<User>();

        public List<User> getAll()
        {
            try
            {
                string qry = "SELECT * FROM users";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.connection;
                cmd.CommandText = qry;

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    User user = new User();

                    user.Id = dr.GetInt32(0);
                    user.UName = dr.GetString(1);
                    user.Email = dr.GetString(2);
                    user.Pwd = dr.GetString(3);
                    user.Fullname = dr.GetString(4);
                    user.Active = dr.GetBoolean(5);
                    user.Rank = dr.GetInt32(6);
                    user.Ban = dr.GetBoolean(7);
                    user.RegTime = dr.GetDateTime(8);
                    user.LogTime = dr.GetDateTime(9);

                    userList.Add(user);
                }

                return userList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User getOne(string id)
        {
            try
            {
                string qry = "SELECT * FROM `users` WHERE id=@id";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.connection;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.CommandText = qry;

                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                User user = new User();

                user.Id = dr.GetInt32(0);
                user.UName = dr.GetString(1);
                user.Email = dr.GetString(2);
                user.Pwd = dr.GetString(3);
                user.Fullname = dr.GetString(4);
                user.Active = dr.GetBoolean(5);
                user.Rank = dr.GetInt32(6);
                user.Ban = dr.GetBoolean(7);
                user.RegTime = dr.GetDateTime(8);
                user.LogTime = dr.GetDateTime(9);

                dr.Close();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string post(User user)//*Ok
        {
            try
            {
                string qry = "INSERT INTO `users`(`uname`, `email`, `pwd`, `fullname`, `active`, `rank`, `ban`, `reg_time`, `log_time`) VALUE (@uname, @email, @pwd, @fullname, @active, @rank, @ban, @reg_time, @log_time);";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.connection;
                cmd.Parameters.AddWithValue("@uname", user.UName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@pwd", user.Pwd);
                cmd.Parameters.AddWithValue("@fullname", user.Fullname);
                cmd.Parameters.AddWithValue("@active", user.Active);
                cmd.Parameters.AddWithValue("@rank", user.Rank);
                cmd.Parameters.AddWithValue("@ban", user.Ban);
                cmd.Parameters.AddWithValue("@reg_time", DateTime.Now);
                cmd.Parameters.AddWithValue("@log_time", DateTime.Now);
                cmd.CommandText = qry;
                cmd.ExecuteNonQuery();

                return "Felhasználó sikeresen hozzáadva!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string patch(User user)//*Ok
        {
            try
            {
                //"`uname`, `email`, `pwd`, `fullname`, `active`, `rank`, `ban`";
                //"@uname, @email, @pwd, @fullname, @active, @rank, @ban";
                string qry = "UPDATE `users` SET `uname`=@uname,`email`=@email,`pwd`=@pwd," +
                    "`fullname`=@fullname,`active`=@active,`rank`=@rank,`ban`=@ban WHERE `id`=@id;";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = c.connection;
                cmd.Parameters.AddWithValue("@id", user.Id);
                cmd.Parameters.AddWithValue("@uname", user.UName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@pwd", user.Pwd);
                cmd.Parameters.AddWithValue("@fullname", user.Fullname);
                cmd.Parameters.AddWithValue("@active", user.Active);
                cmd.Parameters.AddWithValue("@rank", user.Rank);
                cmd.Parameters.AddWithValue("@ban", user.Ban);
                cmd.CommandText = qry;

                cmd.ExecuteNonQuery();

                return "Módosítás sikeresen elvégezve!";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }

        public string delete(string id)//*Ok
        {
            try
            {
                string qry = "DELETE FROM users WHERE id=" + id;
                MySqlCommand cmd = new MySqlCommand(qry, c.connection);

                cmd.ExecuteNonQuery();

                return "Felhasználó törölve!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }



        //public string postUser(string id, string name, string age, string city)//*Ok
        //{
        //    try
        //    {
        //        string qry = "UPDATE `user` SET `Name`=@name,`Age`=@age,`City`=@city WHERE Id=@id;";

        //        MySqlCommand cmd = new MySqlCommand();
        //        cmd.Connection = c.connection;
        //        cmd.Parameters.AddWithValue("@id", id);
        //        cmd.Parameters.AddWithValue("@name", name);
        //        cmd.Parameters.AddWithValue("@age", age);
        //        cmd.Parameters.AddWithValue("@city", city);
        //        cmd.CommandText = qry;

        //        cmd.ExecuteNonQuery();

        //        return "Módosítás elvégezve!";
        //    }
        //    catch (Exception e)
        //    {

        //        return e.Message;
        //    }
        //}

    }
}
