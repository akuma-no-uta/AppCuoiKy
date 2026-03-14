using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace CuoiKy
{
    public partial class Form1 : Form
    {
        SqliteConnection connect = new SqliteConnection("Data Source=C:\\Users\\LENOVO\\source\\repos\\DuAnCuoiKy\\DuAnCuoiKy\\SQL\\Management.db");

        public Form1()
        {
            InitializeComponent();
           
        }

        public bool emptyFields()
        {
            return username.Text == "" || password.Text == "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Please fill in");
                return;
            }

            try
            {
                connect.Open();

                string query = "SELECT * FROM users WHERE username=@username AND password=@password AND status='enabled'";

                using (SqliteCommand cmd = new SqliteCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@username", username.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", password.Text.Trim());

                    SqliteDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("Ok - before open form");

                        AdminStorage f = new AdminStorage();
                        f.Show();



                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connect.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // You can leave this empty or add custom painting code here if needed
        }
    }
}