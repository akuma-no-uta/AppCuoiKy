using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKy
{
    public partial class AdminStorage : Form
    {
        public AdminStorage()
        {
            InitializeComponent();
            MessageBox.Show("AdminStorage opened");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {


        }
        private void button2_click(object sender, EventArgs e)
        {
            this.Hide();
            AddUser user = new AddUser();
            user.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AddUser user = new AddUser();
            user.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void button5_Click(object sender, EventArgs e){
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      
            if (result == DialogResult.Yes)
            {
                Form1 login = new Form1(); // Close the current form (AdminStorage)
                login.Show();
                this.Hide();
            }
        }
    }
}
