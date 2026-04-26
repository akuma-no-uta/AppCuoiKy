using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
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
        private DAO_Product dao_product;
        private Dictionary<string, string> link;

        private const int LOW_STOCK_THRESHOLD = 10;

        static UCHomePage _obj;
        public static UCHomePage Instance
        {
            get { if (_obj == null) _obj = new UCHomePage(); return _obj; }
        }

        public UCHomePage()
        {
            InitializeComponent();

            string fontPath = "C:/Users/LENOVO/BasicGroceryStore/BasicGroceryStore/Futura/SVN-Futura Book.ttf";
            try
            {
                if (File.Exists(fontPath))
                {
                    pfc.AddFontFile(fontPath);
                    customFont = pfc.Families.Length > 0 ? new Font(pfc.Families[0], 11F) : this.Font;
                }
                else customFont = this.Font;
            }
            catch { customFont = this.Font; }

            this.Font = customFont;
            ApplyFont(this, customFont);

            bus_customer = new BUS_Customer();
            bus_imported = new BUS_Imported();
            bus_ordered = new BUS_Ordered();
            dao_product = new DAO_Product();
            link = new Dictionary<string, string>();

            this.Load += UCHomePage_Load;
        }

        private void UCHomePage_Load(object sender, EventArgs e)
        {
            Thread threadInfo = new Thread(LoadStoreInformation);
            threadInfo.IsBackground = true;
            threadInfo.Start();

            RefreshDashboard();
        }

        public void RefreshDashboard()
        {
            LoadIncomeData();
            LoadProfitChart();
            LoadCustomerData();
            LoadLowStockAlerts();
        }

        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control c in parent.Controls)
            {
                c.Font = font;
                if (c.HasChildren) ApplyFont(c, font);
            }
        }

        // ─── Helper: lấy giá trị an toàn, trả -1 nếu thực sự không có dữ liệu ────
        // Quy ước: null / DBNull / exception → trả về -1  (phân biệt với 0 VNĐ thật)
        private double SafeGet(Func<double?> fn)
        {
            try
            {
                double? v = fn();
                // DAO đã xử lý null → 0, nhưng ta cần biết "0 thật" hay "không có"
                // Vì DAO trả về 0 cho cả hai trường hợp, ta chấp nhận 0 là giá trị hợp lệ
                return v ?? 0;
            }
            catch { return 0; }
        }

        // ════════════════════════════════════════════════════════
        #region KPI Cards – Doanh thu & Xu hướng

        public void LoadIncomeData()
        {
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);

            double incomeToday = SafeGet(() => bus_ordered.GetValueOfAllBills_Day(today));
            double incomeYesterday = SafeGet(() => bus_ordered.GetValueOfAllBills_Day(yesterday));
            double spendingToday = SafeGet(() => bus_imported.GetValueOfAllBills_Day(today));
            double spendingYesterday = SafeGet(() => bus_imported.GetValueOfAllBills_Day(yesterday));
            double incomeTotal = SafeGet(() => bus_ordered.GetValueOfAllBills());
            double spendingTotal = SafeGet(() => bus_imported.GetValueOfAllBills());
            double incomeThisMonth = SafeGet(() => bus_ordered.GetValueOfAllBills_Month(today));
            double incomePrevMonth = SafeGet(() => bus_ordered.GetValueOfAllBills_Month(today.AddMonths(-1)));
            double spendThisMonth = SafeGet(() => bus_imported.GetValueOfAllBills_Month(today));
            double spendPrevMonth = SafeGet(() => bus_imported.GetValueOfAllBills_Month(today.AddMonths(-1)));

            // ── Giá trị chính ──
            txtIncomeDay.Text = incomeToday.ToString("N0") + " VNĐ";
            txtSpendingDay.Text = spendingToday.ToString("N0") + " VNĐ";
            txtTotalIncome.Text = incomeTotal.ToString("N0") + " VNĐ";
            txtTotalSpending.Text = spendingTotal.ToString("N0") + " VNĐ";

            // ── Lợi nhuận tổng ──
            if (spendingTotal > 0)
            {
                double profitPct = ((incomeTotal - spendingTotal) / spendingTotal) * 100;
                txtProfit.Text = profitPct.ToString("N2") + " %";
                txtProfit.ForeColor = incomeTotal >= spendingTotal ? Color.LightGreen : Color.Coral;
            }
            else if (incomeTotal > 0)
            {
                txtProfit.Text = "100.00 %";
                txtProfit.ForeColor = Color.LightGreen;
            }
            else
            {
                txtProfit.Text = "— Chưa có dữ liệu";
                txtProfit.ForeColor = Color.Gray;
            }

            // ── Trend badges ──
            SetTrendBadge(lblIncomeDayTrend, incomeToday, incomeYesterday, "hôm qua", incomeToday > 0 || incomeYesterday > 0);
            SetTrendBadge(lblSpendingDayTrend, spendingToday, spendingYesterday, "hôm qua", spendingToday > 0 || spendingYesterday > 0);
            SetTrendBadge(lblIncomeMonthTrend, incomeThisMonth, incomePrevMonth, "tháng trước", incomeThisMonth > 0 || incomePrevMonth > 0);
            SetTrendBadge(lblSpendMonthTrend, spendThisMonth, spendPrevMonth, "tháng trước", spendThisMonth > 0 || spendPrevMonth > 0);

            // ── Auto-report ──
            SetAutoReport(lblIncomeDayReport, incomeToday, incomeYesterday, "Doanh thu hôm nay", "hôm qua");
            SetAutoReport(lblSpendingDayReport, spendingToday, spendingYesterday, "Chi phí hôm nay", "hôm qua");
            SetAutoReport(lblIncomeMonthReport, incomeThisMonth, incomePrevMonth, "Doanh thu tháng", "tháng trước");
            SetAutoReport(lblSpendMonthReport, spendThisMonth, spendPrevMonth, "Chi phí tháng", "tháng trước");
        }

        /// <param name="hasAnyData">true nếu ít nhất một trong hai kỳ có giao dịch</param>
        private void SetTrendBadge(Label lbl, double current, double previous,
                                   string compLabel, bool hasAnyData)
        {
            if (lbl == null) return;

            // Không có dữ liệu gì cả
            if (!hasAnyData)
            {
                lbl.Text = "— Chưa có giao dịch";
                lbl.ForeColor = Color.Gray;
                return;
            }

            // Kỳ trước = 0 nhưng kỳ này có: mới phát sinh
            if (previous == 0 && current > 0)
            {
                lbl.Text = $"🆕 Mới phát sinh ({current:N0} VNĐ)";
                lbl.ForeColor = Color.FromArgb(80, 220, 130);
                return;
            }

            // Kỳ này = 0, kỳ trước có: giảm 100%
            if (current == 0 && previous > 0)
            {
                lbl.Text = $"▼ -100% so với {compLabel}";
                lbl.ForeColor = Color.FromArgb(255, 100, 80);
                return;
            }

            // Cả hai bằng 0
            if (current == 0 && previous == 0)
            {
                lbl.Text = $"— Không có giao dịch {compLabel}";
                lbl.ForeColor = Color.Gray;
                return;
            }

            double pct = ((current - previous) / previous) * 100;
            bool isUp = pct >= 0;
            lbl.Text = $"{(isUp ? "▲" : "▼")} {(isUp ? "+" : "")}{pct:N1}% so với {compLabel}";
            lbl.ForeColor = isUp ? Color.FromArgb(80, 220, 130) : Color.FromArgb(255, 100, 80);
        }

        private void SetAutoReport(Label lbl, double current, double previous,
                                   string subject, string compLabel)
        {
            if (lbl == null) return;

            if (current == 0 && previous == 0)
            {
                lbl.Text = $"— {subject}: chưa có giao dịch.";
                lbl.ForeColor = Color.Gray;
                return;
            }

            if (previous == 0 && current > 0)
            {
                lbl.Text = $"📊 {subject}: {current:N0} VNĐ (lần đầu có dữ liệu).";
                lbl.ForeColor = Color.FromArgb(140, 210, 140);
                return;
            }

            if (current == 0 && previous > 0)
            {
                lbl.Text = $"📉 {subject} giảm 100% so với {compLabel} ({previous:N0} VNĐ).";
                lbl.ForeColor = Color.FromArgb(255, 150, 110);
                return;
            }

            double diff = current - previous;
            double pct = (diff / previous) * 100;
            string trend = diff >= 0 ? "tăng" : "giảm";
            string emoji = diff >= 0 ? "📈" : "📉";

            lbl.Text = Math.Abs(pct) < 1
                ? $"— {subject} gần như không đổi so với {compLabel} ({current:N0} VNĐ)."
                : $"{emoji} {subject} {trend} {Math.Abs(pct):N1}% ({Math.Abs(diff):N0} VNĐ) so với {compLabel}.";

            lbl.ForeColor = diff >= 0
                ? Color.FromArgb(140, 210, 140)
                : Color.FromArgb(255, 150, 110);
        }

        #endregion

        // ════════════════════════════════════════════════════════
        #region Biểu đồ lợi nhuận 7 ngày

        private void LoadProfitChart()
        {
            try
            {
                chartProfit.Series.Clear();
                chartProfit.ChartAreas.Clear();
                chartProfit.Titles.Clear();

                ChartArea area = new ChartArea("MainArea") { BackColor = Color.Transparent };
                area.AxisX.MajorGrid.LineColor = Color.FromArgb(45, 45, 45);
                area.AxisY.MajorGrid.LineColor = Color.FromArgb(45, 45, 45);
                area.AxisX.LabelStyle.ForeColor = Color.Gray;
                area.AxisY.LabelStyle.ForeColor = Color.Gray;
                area.AxisX.LineColor = Color.DimGray;
                area.AxisY.LineColor = Color.DimGray;
                chartProfit.ChartAreas.Add(area);

                Series series = new Series("Lợi nhuận")
                {
                    ChartType = SeriesChartType.SplineArea,
                    BorderWidth = 3,
                    Color = Color.FromArgb(0, 162, 232),
                    BackGradientStyle = GradientStyle.TopBottom,
                    BackSecondaryColor = Color.FromArgb(20, 60, 40),
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 6,
                    MarkerColor = Color.White
                };

                DateTime today = DateTime.Today;
                for (int i = 6; i >= 0; i--)
                {
                    DateTime d = today.AddDays(-i);
                    double income = SafeGet(() => bus_ordered.GetValueOfAllBills_Day(d));
                    double spending = SafeGet(() => bus_imported.GetValueOfAllBills_Day(d));
                    series.Points.AddXY(d.ToString("dd/MM"), income - spending);
                }

                chartProfit.Series.Add(series);
                chartProfit.BackColor = Color.FromArgb(20, 60, 40);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[LoadProfitChart] " + ex.Message);
            }
        }

        #endregion

        // ════════════════════════════════════════════════════════
        #region Cảnh báo hàng tồn kho thấp

        public void LoadLowStockAlerts()
        {
            try
            {
                DataTable dt = dao_product.GetAllProduct();

                if (dt == null || dt.Rows.Count == 0)
                {
                    SetLowStockBadge("— Không lấy được dữ liệu sản phẩm", Color.Gray);
                    return;
                }

                // Kiểm tra cột Quantity tồn tại
                if (!dt.Columns.Contains("Quantity"))
                {
                    SetLowStockBadge("⚠ Dữ liệu sản phẩm không có cột Quantity", Color.OrangeRed);
                    return;
                }

                var lowStock = dt.AsEnumerable()
                    .Where(r =>
                    {
                        int q = 0;
                        int.TryParse(r["Quantity"]?.ToString(), out q);
                        return q <= LOW_STOCK_THRESHOLD;
                    })
                    .OrderBy(r =>
                    {
                        int q = 0;
                        int.TryParse(r["Quantity"]?.ToString(), out q);
                        return q;
                    })
                    .ToList();

                // ── Badge đếm ──
                int outCount = lowStock.Count(r =>
                {
                    int q = 0;
                    int.TryParse(r["Quantity"]?.ToString(), out q);
                    return q == 0;
                });

                if (lowStock.Count > 0)
                    SetLowStockBadge($"⚠  {lowStock.Count} sản phẩm cần nhập  |  🔴 {outCount} hết hàng",
                                     Color.FromArgb(255, 190, 60));
                else
                    SetLowStockBadge("✅  Tất cả hàng hoá đủ tồn kho",
                                     Color.FromArgb(80, 200, 120));

                // ── Xây DataTable hiển thị ──
                DataTable alertTable = new DataTable();
                alertTable.Columns.Add("Tên sản phẩm");
                alertTable.Columns.Add("Loại");
                alertTable.Columns.Add("Đơn vị");
                alertTable.Columns.Add("Tồn kho", typeof(int));
                alertTable.Columns.Add("Trạng thái");
                alertTable.Columns.Add("Gợi ý");

                // Helper lấy cột an toàn
                Func<DataRow, string, string> cell = (r, col) =>
                    dt.Columns.Contains(col) ? (r[col]?.ToString() ?? "") : "";

                foreach (DataRow r in lowStock.Select(x => x))
                {
                    int qty = 0;
                    int.TryParse(r["Quantity"]?.ToString(), out qty);

                    string status, suggest, icon;
                    if (qty == 0) { icon = "🔴"; status = "Hết hàng"; suggest = "Nhập ngay hôm nay"; }
                    else if (qty <= 3) { icon = "🟠"; status = "Cực kỳ ít"; suggest = "Ưu tiên nhập gấp"; }
                    else if (qty <= 6) { icon = "🟡"; status = "Sắp hết"; suggest = "Nên nhập trong tuần"; }
                    else { icon = "🔵"; status = "Cần nhập thêm"; suggest = "Lên kế hoạch nhập"; }

                    alertTable.Rows.Add(
                        cell(r, "Name"),
                        cell(r, "TypeProduct"),
                        cell(r, "Unit"),
                        qty,
                        $"{icon}  {status}",
                        suggest);
                }

                dgvLowStock.DataSource = alertTable;
                StyleLowStockGrid();
            }
            catch (Exception ex)
            {
                SetLowStockBadge("⚠ Lỗi tải dữ liệu tồn kho: " + ex.Message, Color.OrangeRed);
                Debug.WriteLine("[LoadLowStockAlerts] " + ex.Message);
            }
        }

        private void SetLowStockBadge(string text, Color color)
        {
            if (lblLowStockCount != null)
            {
                lblLowStockCount.Text = text;
                lblLowStockCount.ForeColor = color;
            }
        }

        private void StyleLowStockGrid()
        {
            if (dgvLowStock == null) return;
            dgvLowStock.EnableHeadersVisualStyles = false;
            dgvLowStock.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 40);
            dgvLowStock.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(180, 200, 220);
            dgvLowStock.ColumnHeadersDefaultCellStyle.Font = new Font(customFont.FontFamily, 10F, FontStyle.Bold);
            dgvLowStock.BackgroundColor = Color.FromArgb(22, 28, 36);
            dgvLowStock.GridColor = Color.FromArgb(40, 50, 60);
            dgvLowStock.RowHeadersVisible = false;

            if (!dgvLowStock.Columns.Contains("Trạng thái")) return;

            foreach (DataGridViewRow row in dgvLowStock.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                Color bg;
                if (status.Contains("Hết hàng")) bg = Color.FromArgb(90, 30, 30);
                else if (status.Contains("Cực kỳ ít")) bg = Color.FromArgb(90, 55, 20);
                else if (status.Contains("Sắp hết")) bg = Color.FromArgb(70, 65, 20);
                else bg = Color.FromArgb(25, 50, 75);

                row.DefaultCellStyle.BackColor = bg;
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.SelectionBackColor =
                    Color.FromArgb(Math.Min(bg.R + 30, 255),
                                   Math.Min(bg.G + 30, 255),
                                   Math.Min(bg.B + 30, 255));
            }
        }

        #endregion

        // ════════════════════════════════════════════════════════
        #region Thông tin cửa hàng & Khách hàng

        public void LoadStoreInformation()
        {
            try
            {
                DAO_Information dao = new DAO_Information("StoreInformation.xml");
                Dictionary<string, string> data = dao.LoadStoreInformation();

                if (this.IsHandleCreated)
                    this.Invoke(new MethodInvoker(() => UpdateStoreUI(data)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[LoadStoreInformation] " + ex.Message);
            }
        }

        private void UpdateStoreUI(Dictionary<string, string> data)
        {
            lblAddress.Text = "Địa chỉ: " + data["address"];
            lblEmail.Text = "Email: " + data["email"];
            lblPhone.Text = "Hotline: " + data["phone"];

            link["map"] = data["link_map"];
            link["facebook"] = data["link_fb"];
            link["instagram"] = data["link_ig"];
            link["linkedin"] = data["link_linkedin"];
            link["youtube"] = data["link_ut"];
        }

        public void LoadCustomerData()
        {
            try
            {
                dgvCustomer.DataSource = bus_customer.GetAllCustomer();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[LoadCustomerData] " + ex.Message);
            }
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvCustomer.RowCount) return;
                var row = dgvCustomer.CurrentRow;
                if (row == null) return;

                txtCustomerName.Text = row.Cells[0].Value?.ToString() ?? "";
                txtCustomerPhone.Text = row.Cells[1].Value?.ToString() ?? "";

                if (row.Cells[2].Value != null && row.Cells[2].Value != DBNull.Value)
                    dtCustomerDateJoin.Value = System.Convert.ToDateTime(row.Cells[2].Value);

                txtCustomerValue.Text = row.Cells[3].Value?.ToString() ?? "";

                string level = row.Cells[4].Value?.ToString() ?? "";
                picCustomerLevel.BackgroundImage = LoadLevelCustomer(level);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[dgvCustomer_CellContentClick] " + ex.Message);
            }
        }

        private Image LoadLevelCustomer(string level)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(level)) return null;
                string path = Path.Combine(Application.StartupPath, "Resources", level.Trim() + ".png");
                if (File.Exists(path)) return Image.FromFile(path);
            }
            catch { }
            return null;
        }

        #endregion

        // ════════════════════════════════════════════════════════
        #region Button Events

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            DataTable dt = bus_customer.GetAllCustomer();

            if (string.IsNullOrEmpty(keyword)) { dgvCustomer.DataSource = dt; return; }

            try
            {
                var rows = dt.AsEnumerable().Where(r =>
                    (r.Field<string>("Name") ?? "").ToLower().Contains(keyword) ||
                    (r.Field<string>("Phone") ?? "").Contains(keyword));
                dgvCustomer.DataSource = rows.Any() ? rows.CopyToDataTable() : dt.Clone();
            }
            catch { dgvCustomer.DataSource = dt; }
        }

        private void btnReloadValue_Click(object sender, EventArgs e) => RefreshDashboard();
        private void btnReloadCustomer_Click(object sender, EventArgs e) => LoadCustomerData();
        private void btnReloadLowStock_Click(object sender, EventArgs e) => LoadLowStockAlerts();

        private void btnChangeCustomerInfor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerName.Text)) return;
            try
            {
                new FormCustomer(new Customer(
                    txtCustomerName.Text,
                    txtCustomerPhone.Text,
                    dtCustomerDateJoin.Value,
                    float.Parse(txtCustomerValue.Text),
                    dgvCustomer.CurrentRow?.Cells[4].Value?.ToString() ?? "")).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }

        private void btnChangeStoreInfor_Click(object sender, EventArgs e) =>
            new FormStoreInfomation().ShowDialog();

        #endregion

        // ════════════════════════════════════════════════════════
        #region Social Links

        private void OpenBrowser(string key)
        {
            try
            {
                if (link.ContainsKey(key) && !string.IsNullOrEmpty(link[key]))
                    Process.Start(link[key]);
                else
                    MessageBox.Show("Link chưa được cấu hình!", "Thông báo");
            }
            catch { MessageBox.Show("Không thể mở link!", "Thông báo"); }
        }

        private void picYoutube_Click(object sender, EventArgs e) => OpenBrowser("youtube");
        private void picFace_Click(object sender, EventArgs e) => OpenBrowser("facebook");
        private void picInsta_Click(object sender, EventArgs e) => OpenBrowser("instagram");
        private void picLinkedIn_Click(object sender, EventArgs e) => OpenBrowser("linkedin");
        private void picStoreLocation_Click(object sender, EventArgs e) => OpenBrowser("map");

        #endregion

        private void txtIncomeDay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}