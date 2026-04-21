using System;
using System.Collections.Generic;
using System.Data; // Add this using directive
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq; // Add this using directive
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace BasicGroceryStore
{
    public partial class UCHomePage : UserControl
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private Font customFont;
        private BUS_Customer bus_customer;
        private BUS_Imported bus_imported;
        private BUS_Ordered bus_ordered;

        private Dictionary<string, string> link;

        static UCHomePage _obj;
        public static UCHomePage Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new UCHomePage();
                }
                return _obj;
            }
        }
        public UCHomePage()
        {
            InitializeComponent();
            string fontPath = "C:/Users/LENOVO/BasicGroceryStore/BasicGroceryStore/Futura/SVN-Futura Book.ttf";
            pfc.AddFontFile(fontPath);

            if (pfc.Families.Length > 0)
                customFont = new Font(pfc.Families[0], 11F);
            else
                customFont = this.Font;

            this.Font = customFont;
            ApplyFont(this, customFont);
            link = new Dictionary<string, string>();

            bus_customer = new BUS_Customer();
            bus_imported = new BUS_Imported();
            bus_ordered = new BUS_Ordered();

            new Thread(LoadStoreInformation).Start();
            LoadCustomerData();
        }

        #region ButtonControl
        private void btnChangeCustomerInfor_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text == "")
                return;

            new FormCustomer(new Customer(
                name: txtCustomerName.Text,
                phone: txtCustomerPhone.Text,
                dateJoin: dtCustomerDateJoin.Value,
                value: float.Parse(txtCustomerValue.Text),
                e_level: dgvCustomer.CurrentRow.Cells[4].Value.ToString())).ShowDialog();
        }

        private void btnChangeStoreInfor_Click(object sender, EventArgs e)
        {
            new FormStoreInfomation().ShowDialog();
        }

        private void btnChangeYourInfor_Click(object sender, EventArgs e)
        {

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
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            new FormCustomer().ShowDialog();
        }

        private void btnReloadValue_Click(object sender, EventArgs e)
        {
            LoadIncomeData();
            LoadProfitChart(); // 🔥 thêm dòng này

        }
        #endregion

        #region PictureBox_Link

        private void picYoutube_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(link["youtube"]);
            }
            catch (Exception)
            {
                MessageBox.Show("Địa chỉ được lưu không hợp lệ, vui lòng kiểm tra!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picFace_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(link["facebook"]);
            }
            catch (Exception)
            {
                MessageBox.Show("Địa chỉ được lưu không hợp lệ, vui lòng kiểm tra!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picInsta_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(link["instagram"]);
            }
            catch (Exception)
            {
                MessageBox.Show("Địa chỉ được lưu không hợp lệ, vui lòng kiểm tra!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picLinkedIn_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(link["linkedin"]);
            }
            catch (Exception)
            {
                MessageBox.Show("Địa chỉ được lưu không hợp lệ, vui lòng kiểm tra!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picStoreLocation_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(link["map"]);
            }
            catch (Exception)
            {
                MessageBox.Show("Địa chỉ được lưu không hợp lệ, vui lòng kiểm tra!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictContact_Click(object sender, EventArgs e)
        {

        }
        #endregion


        public void LoadStoreInformation()
        {
            DAO_Information dao = new DAO_Information("StoreInformation.xml");
            Dictionary<string, string> data = dao.LoadStoreInformation();

            lblAddress.Text = "Địa chỉ: " + data["address"];
            lblAddress.MaximumSize = new Size(560, 0);
            lblAddress.AutoSize = true;

            lblEmail.Text = "Email: " + data["email"];
            lblPhone.Text = "Số điện thoại: " + data["phone"];

            link.Clear();
            link.Add("map", data["link_map"]);
            link.Add("facebook", data["link_fb"]);
            link.Add("instagram", data["link_ig"]);
            link.Add("linkedin", data["link_linkedin"]);
            link.Add("youtube", data["link_ut"]);
        }

        public void LoadCustomerData()
        {
            dgvCustomer.DataSource = bus_customer.GetAllCustomer();
        }

        /// <summary>
        /// Setting staff data to form
        /// </summary>
        /// <param name="staff"></param>
      

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.CurrentCell.RowIndex == dgvCustomer.RowCount - 1)
                return;

            txtCustomerName.Text = dgvCustomer.CurrentRow.Cells[0].Value.ToString();
            txtCustomerPhone.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
            dtCustomerDateJoin.Value = (DateTime)dgvCustomer.CurrentRow.Cells[2].Value;
            txtCustomerValue.Text = dgvCustomer.CurrentRow.Cells[3].Value.ToString();
            picCustomerLevel.BackgroundImage = LoadLevelCustomer(dgvCustomer.CurrentRow.Cells[4].Value.ToString());
        }

        public void LoadIncomeData()
        {
            double income_day = bus_ordered.GetValueOfAllBills_Day(DateTime.Today).Value;
            txtIncomeDay.Text = GetFormatString.GetCurrencyString(income_day);
            double income = bus_ordered.GetValueOfAllBills().Value; // Thu nhap
            txtTotalIncome.Text = GetFormatString.GetCurrencyString(income);

            double spending_day = bus_imported.GetValueOfAllBills_Day(DateTime.Today).Value;
            txtSpendingDay.Text = GetFormatString.GetCurrencyString(spending_day);
            double spending = bus_imported.GetValueOfAllBills().Value; // Chi tra
            txtTotalSpending.Text = GetFormatString.GetCurrencyString(spending);


            if (spending == 0)
                txtProfit.Text = "0 %";
            else
                txtProfit.Text = ((income - spending) / spending * 100).ToString("N3") + " %";

            // 🔥 THÊM DÒNG NÀY
        }

        /// <summary>
        /// Show image of customer's level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private Image LoadLevelCustomer(string level)
        {
            string path = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            path = path.Replace("bin", "Resources/") + level.Trim() + ".png";
            return Image.FromFile(path);
        }

        private void btnReloadCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void txtIncomeDay_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pnlCustomer_Enter(object sender, EventArgs e)
        {

        }

        private void txtProfit_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlValue_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblYourEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtProfit_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtSpendingDay_TextChanged(object sender, EventArgs e)
        {

        }
    
        private void LoadProfitChart()
        {
            chartProfit.Series.Clear();
            chartProfit.ChartAreas.Clear();
            chartProfit.Titles.Clear();

            ChartArea area = new ChartArea();
            chartProfit.ChartAreas.Add(area);

            Series series = new Series("Profit");
            series.ChartType = SeriesChartType.Column;

            // 🔥 làm cột gọn lại
            series["PointWidth"] = "0.5";

            // ❌ tắt label để tránh chồng
            series.IsValueShownAsLabel = false;

            // tooltip khi hover
            series.ToolTip = "#VALY";

            // màu đẹp hơn (gradient)
            series.Color = Color.FromArgb(100, 220, 150);
            series.BackGradientStyle = GradientStyle.TopBottom;

            DateTime today = DateTime.Today;

            // 🔥 lấy 7 ngày gần nhất
            for (int i = 6; i >= 0; i--)
            {
                DateTime date = today.AddDays(-i);

                double income = bus_ordered.GetValueOfAllBills_Day(date).Value;
                double spending = bus_imported.GetValueOfAllBills_Day(date).Value;

                double profit = income - spending;

                // hiển thị thứ (Mon, Tue...)
                string label = date.ToString("ddd");

                series.Points.AddXY(label, profit);
            }

            chartProfit.Series.Add(series);

            // 🎨 STYLE (QUAN TRỌNG)
            chartProfit.BackColor = Color.FromArgb(20, 60, 40);
            area.BackColor = Color.Transparent;

            // trục X
            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisX.MajorGrid.Enabled = false;

            // trục Y
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(80, 80, 80);

            // bỏ viền
            chartProfit.BorderlineWidth = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                dgvCustomer.DataSource = bus_customer.GetAllCustomer();
                return;
            }

            var dt = bus_customer.GetAllCustomer();
            var result = dt.AsEnumerable()
                .Where(row =>
                    (row["Name"] != null && row["Name"].ToString().ToLower().Contains(keyword)) ||
                    (row["Phone"] != null && row["Phone"].ToString().Contains(keyword))
                ).CopyToDataTable();

            dgvCustomer.DataSource = result;
        }
    }
}