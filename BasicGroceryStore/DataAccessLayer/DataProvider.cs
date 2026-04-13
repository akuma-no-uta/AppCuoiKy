using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BasicGroceryStore
{
    public class DataProvider
    {
        private string connectionString =
            @"Data Source=LAPTOP-8GV5S1F6\SQLEXPRESS01;Initial Catalog=GroceryStore;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection connection;
        private SqlCommand cmd;

        // Singleton
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
        }

        public DataProvider()
        {
            connection = new SqlConnection(connectionString);

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();

            // Đường dẫn file SQL
            string sqlFilePath = "Data Source=LAPTOP-8GV5S1F6\\SQLEXPRESS01;Initial Catalog=GroceryStore;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

            // Chạy script SQL nếu file tồn tại
            if (File.Exists(sqlFilePath))
            {
                try
                {
                    string sqlScript = File.ReadAllText(sqlFilePath);

                    // Tách các lệnh bằng GO
                    string[] commands = sqlScript.Split(
                        new[] { "GO" },
                        StringSplitOptions.RemoveEmptyEntries
                    );

                    foreach (string command in commands)
                    {
                        string sqlCommandText = command.Trim();

                        if (!string.IsNullOrWhiteSpace(sqlCommandText))
                        {
                            SqlCommand initCmd = new SqlCommand(sqlCommandText, connection);
                            initCmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SQL Script Error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("SQL file not found: " + sqlFilePath);
            }

            cmd = connection.CreateCommand();
        }

        // INSERT / UPDATE / DELETE
        public int ExecuteNonQuery(string sqlExpess, CommandType type, params SqlParameter[] param)
        {
            cmd.CommandType = type;
            cmd.CommandText = sqlExpess;
            cmd.Parameters.Clear();

            if (param != null)
            {
                foreach (SqlParameter a in param)
                {
                    cmd.Parameters.Add(a);
                }
            }

            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return 0;
            }
        }

        // SELECT
        public DataTable ExecuteQuery(string sqlExpess, CommandType type, params SqlParameter[] param)
        {
            cmd.CommandType = type;
            cmd.CommandText = sqlExpess;
            cmd.Parameters.Clear();

            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    cmd.Parameters.Add(p);
                }
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            return dt;
        }

        // COUNT / VALUE / FUNCTION
        public object ExecuteScalar(string sqlExpess, CommandType type, params SqlParameter[] param)
        {
            cmd.CommandType = type;
            cmd.CommandText = sqlExpess;
            cmd.Parameters.Clear();

            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    cmd.Parameters.Add(p);
                }
            }

            try
            {
                return cmd.ExecuteScalar();
            }
            catch (SqlException)
            {
                return null;
            }
        }
    }
}