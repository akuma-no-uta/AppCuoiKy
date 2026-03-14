using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data;
namespace CuoiKy
{
    internal class AdminAddUser
    {SqliteConnection connection = new SqliteConnection("Data Source=C:\\Users\\LENOVO\\source\\repos\\DuAnCuoiKy\\DuAnCuoiKy\\SQL\\Management.db");
        public int ID { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string status { set; get; }  

        public string role { set; get; }
        public string dateRegister { set; get; }
        public List<AdminAddUser> listUser()
        {
            List<AdminAddUser> list = new List<AdminAddUser>();

            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                    string selectData = "SELECT * FROM users";
                    using (SqliteCommand cmd = new SqliteCommand(selectData, connection))
                    {
                        SqliteDataReader reader = cmd.ExecuteReader();
                        DataTable table = new DataTable();
                        while (reader.Read())
                        {
                            AdminAddUser user = new AdminAddUser();
                            user.ID = reader.GetInt32(0);
                            user.username = reader.GetString(0);
                            user.password = reader.GetString(1);
                            user.status = reader.GetString(2);
                            user.role = reader.GetString(3);
                            user.dateRegister = reader.GetString(4);
                            list.Add(user);
                        }
                    }
                }
                catch (Exception ex) { }
                finally { }
            }

            return list;
        }
    }
}
