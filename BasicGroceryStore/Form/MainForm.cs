using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace BasicGroceryStore
{
    public partial class MainForm : Form
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private Font customFont;
        public static int current_role = 0; // 1 = admin, 0 = staff
        public static Action LoadData;
        public static Staff staff_using;

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;



            // ===================== FONT =====================
            string fontPath = "C:/Users/LENOVO/BasicGroceryStore/BasicGroceryStore/Futura/SVN-Futura Book.ttf";
            pfc.AddFontFile(fontPath);

            if (pfc.Families.Length > 0)
                customFont = new Font(pfc.Families[0], 11F);
            else
                customFont = this.Font;

            this.Font = customFont;
            ApplyFont(this, customFont);

            // ===================== UI INIT =====================

            AddTabToControl();
            SettingCallForLoadData();

            LoadData?.Invoke();

            timer.Start();
            ApplyRolePermissions();
            // ===================== KEY FIX =====================
            pnlMain.Dock = DockStyle.Fill;
        }

        #region MOVE FORM
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

                this.Location = new Point(
                    this.Location.X - xDiff,
                    this.Location.Y - yDiff
                );
            }
        }

        private void pnlMove_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }
        #endregion

        #region FONT APPLY
        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control c in parent.Controls)
            {
                c.Font = font;
                if (c.HasChildren)
                    ApplyFont(c, font);
            }
        }
        #endregion

        public void ApplyRolePermissions()
        {
            if (current_role == 1) return; // admin → full quyền

            // staff → hạn chế
            btnStaff.Visible = false;
            btnStatistic.Visible = false;
            btnImport.Visible = false;
            btnProduct.Visible = false;
        }

        #region ADD TAB (RESPONSIVE FIX)
        private void AddTabToControl()
        {
            AddUC(UCImported.Instance);
            AddUC(UCOrdered.Instance);
            AddUC(UCProduct.Instance);
            AddUC(UCStatistic.Instance);
            AddUC(UCCalendar.Instance);
            AddUC(UCStaff.Instance);

            AddUC(UCHomePage.Instance);

        }

        private void AddUC(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;   // 🔥 IMPORTANT FIX
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }
        #endregion

        #region LOAD DATA
        private static void SettingCallForLoadData()
        {
            LoadData = UCProduct.Instance.LoadData;
            LoadData += UCImported.Instance.LoadData;
            LoadData += UCOrdered.Instance.LoadData;
        }
        #endregion

        #region TAB CONTROL
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            UCStaff.Instance.BringToFront();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            UCProduct.Instance.BringToFront();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            UCOrdered.Instance.BringToFront();
        }
        
        private void btnImport_Click(object sender, EventArgs e)
        {
            UCImported.Instance.BringToFront();
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            UCStatistic.Instance.BringToFront();
        }

        private void btnHomePage_Click(object sender, EventArgs e)
        {
            UCHomePage.Instance.BringToFront();
        }

        #endregion

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }


        #region SETTING

        #endregion

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            UCCalendar.Instance.BringToFront();
        }
    }
}