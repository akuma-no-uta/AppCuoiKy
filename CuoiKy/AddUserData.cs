using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuoiKy
{
    internal class AddUserData
    {
        SqliteConnection connect = new SqliteConnection("Data Source=C:\\Users\\LENOVO\\source\\repos\\DuAnCuoiKy\\DuAnCuoiKy\\SQL\\Management.db");
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string status { get; set; }
        public string DateRegistered { get; set; }
         
        public List<AddUserData> userListData() { 
        List<AddUserData> userList = new List<AddUserData>();
            if(connect.State != ConnectionState.Open)
            {
                try { 
                connect.Open();
                    string selectData = "SELECT * FROM Users";
                    using (SqliteCommand command = new SqliteCommand(selectData, connect))
                    {
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AddUserData user = new AddUserData();
                                user.ID = (int)reader["id"];
                                user.username = reader["username"].ToString();
                                user.password = reader["password"].ToString();
                                user.role = reader["role"].ToString();
                                user.status = reader["status"].ToString();
                                user.DateRegistered = reader["date_registered"].ToString(); 
                                userList.Add(user);
                            }
                        }
                    }
                }
                catch(Exception e) {

                    Console.WriteLine(e.Message);
                }
                finally
                    {connect.Close();

                }
            }
            return userList;
                }
    }
}
