using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.Data.SqlClient;

namespace CuoiKy
{
    public partial class AddUser : Form
    {
        SqliteConnection connect = new SqliteConnection("Data Source=C:\\Users\\LENOVO\\source\\repos\\DuAnCuoiKy\\DuAnCuoiKy\\SQL\\Management.db");

        public AddUser()
        {
            InitializeComponent();
            displayUserData();
        }
        public void displayUserData()
        {
            AddUserData user = new AddUserData();
            List<AddUserData> listdata = user.userListData();
            dataGridView1.DataSource = listdata;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        public bool emptyFields()
        {
            if ((username.Text == "" || password.Text == ""||role.Text==""||status.Text==""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (emptyFields())
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
        }
    }
}
