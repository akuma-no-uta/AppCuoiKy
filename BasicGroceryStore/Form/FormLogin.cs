using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace BasicGroceryStore
{
    public partial class FormLogin : Form
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private Font customFont;
        public static int current_role = 0; // 1 = admin, 0 = staff

        private BUS_Account bus_account;
        private BUS_Staff bus_staff;

        public FormLogin()
        {
            InitializeComponent();
            string fontPath = "C:/Users/LENOVO/BasicGroceryStore/BasicGroceryStore/Futura/SVN-Futura Book.ttf";
    pfc.AddFontFile(fontPath);

    customFont = new Font(pfc.Families[0], 11F);

    // ===== APPLY TOÀN BỘ =====
    this.Font = customFont;
    ApplyFont(this, customFont);
            bus_account = new BUS_Account();
            bus_staff = new BUS_Staff();
            LoadAccount();
        }

        private void LoadAccount()
        {
            DAO_Information dao = new DAO_Information("Account.xml");
            List<object> data = dao.LoadSaveAccount();
            txtUsername.Text = data[1].ToString();
            txtPassword.Text = data[2].ToString();
            chbRemember.Checked = Boolean.Parse(data[3].ToString());
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control c in parent.Controls)
            {
                c.Font = font;

                if (c.HasChildren)
                    ApplyFont(c, font);
            }
        }

        #region MoveForm
        private Point firstPoint;
        private bool mouseIsDown = false;

        private void pnlMove_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            mouseIsDown = true;
        }
        private void pnlMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;

                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }
        private void pnlMove_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }
        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            Account loginResult = bus_account.CheckLoginWithRole(username, password);

            if (loginResult == null)
            {
                MessageBox.Show(
                    "Sai tài khoản hoặc mật khẩu!",
                    "LỖI",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Staff staff = bus_staff.GetStaff(loginResult.Staff_id);

            // ❗ Check enable (đúng chỗ)
            if (staff.Enable == 0)
            {
                MessageBox.Show(
                    "Tài khoản đã bị khóa!",
                    "THÔNG BÁO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // 🔥 Lưu account nếu remember
            bus_account.SaveAccount(loginResult, chbRemember.Checked);

            // 🔥 Truyền dữ liệu sang MainForm
            MainForm.staff_using = staff;
            MainForm.current_role = loginResult.Role; // 🔥 QUAN TRỌNG

            // 🔥 Mở MainForm
            MainForm main = new MainForm();
            main.Show();

            this.Hide();
        }
        private void btnSupport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ Admin để được hỗ trợ thêm", "THÔNG BÁO HỖ TRỢ", MessageBoxButtons.OK);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            Application.Exit();


        }
        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    
        public void ApplyRole(int role)
        {
            if (role != 1)
            {
                this.Enabled = false;
            }
        }

        private void lblTabShow_Click(object sender, EventArgs e)
        {

        }
    }
}
