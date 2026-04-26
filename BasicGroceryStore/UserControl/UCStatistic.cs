using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicGroceryStore
{
    public partial class UCStatistic : UserControl
    {
        // ══════════════════════════════════════════
        //  FIELDS
        // ══════════════════════════════════════════
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private Font customFont;
        private BUS_Imported bus_imported;
        private BUS_Ordered bus_ordered;

        private DataTable _allImportBills;
        private DataTable _allOrderedBills;

        static UCStatistic _obj;
        public static UCStatistic Instance
        {
            get
            {
                if (_obj == null) _obj = new UCStatistic();
                return _obj;
            }
        }

        // ══════════════════════════════════════════
        //  CONSTRUCTOR
        // ══════════════════════════════════════════
        public UCStatistic()
        {
            InitializeComponent();

            string fontPath = "C:/Users/LENOVO/BasicGroceryStore/BasicGroceryStore/Futura/SVN-Futura Book.ttf";
            try { pfc.AddFontFile(fontPath); } catch { }
            customFont = (pfc.Families.Length > 0)
                ? new Font(pfc.Families[0], 11F)
                : this.Font;
            this.Font = customFont;
            ApplyFont(this, customFont);

            bus_imported = new BUS_Imported();
            bus_ordered = new BUS_Ordered();

            InitProductChartPanel();
            LoadData();
        }

        // ══════════════════════════════════════════
        //  INIT: cbTypeChartProduct + comboBox1
        // ══════════════════════════════════════════
        private void InitProductChartPanel()
        {
            label1.Text = "Lọc chi tiết:";
            label1.Visible = false;
            comboBox1.Visible = false;

            cbTypeChartProduct.SelectedIndexChanged += CbTypeChartProduct_SelectedIndexChanged;

            if (cbTypeChartProduct.Items.Count > 0)
                cbTypeChartProduct.SelectedIndex = 0;
        }

        // ══════════════════════════════════════════
        //  LOAD DATA
        // ══════════════════════════════════════════
        private void LoadData()
        {
            _allOrderedBills = bus_ordered.GetAllBill();
            _allImportBills = bus_imported.GetAllBill();

            dgvSellingHistory.DataSource = _allOrderedBills;
            if (dgvSellingHistory.Columns.Count > 0)
                dgvSellingHistory.Columns[0].Visible = false;

            dgvImportHistory.DataSource = _allImportBills;
            if (dgvImportHistory.Columns.Count > 0)
                dgvImportHistory.Columns[0].Visible = false;

            ResetProductChart("← Chọn loại biểu đồ và nhấn \"Tạo biểu đồ\"");
        }

        // ══════════════════════════════════════════
        //  RESET CHART
        // ══════════════════════════════════════════
        private void ResetProductChart(string hint = "")
        {
            cbInformationPlus.Series.Clear();
            cbInformationPlus.ChartAreas.Clear();
            cbInformationPlus.Titles.Clear();
            cbInformationPlus.Legends.Clear();
            cbInformationPlus.ChartAreas.Add(new ChartArea("Main"));

            if (!string.IsNullOrEmpty(hint))
                cbInformationPlus.Titles.Add(new Title
                {
                    Text = hint,
                    Font = new Font("Arial", 9f, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Docking = Docking.Top
                });
        }

        // ══════════════════════════════════════════
        //  Đổi loại chart → cập nhật comboBox lọc
        // ══════════════════════════════════════════
        private void CbTypeChartProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Visible = false;
            label1.Visible = false;

            // Option 4 "Doanh số bán ra tùy chọn": cho lọc thêm theo loại SP
            if (cbTypeChartProduct.SelectedIndex == 4)
            {
                label1.Text = "Lọc theo loại SP:";
                label1.Visible = true;
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox1.Visible = true;
                comboBox1.Items.Add("-- Tất cả --");
                try
                {
                    DataTable dtTypes = bus_imported.GetImportedItemsByDateRange(
                        DateTime.Today.AddYears(-5), DateTime.Today);
                    var seen = new HashSet<string>();
                    foreach (DataRow r in dtTypes.Rows)
                    {
                        string t = r["TypeProduct"].ToString();
                        if (seen.Add(t)) comboBox1.Items.Add(t);
                    }
                }
                catch { }
                comboBox1.SelectedIndex = 0;
            }
        }

        // ══════════════════════════════════════════
        //  NÚT TẠO BIỂU ĐỒ (groupBox2 bên phải)
        // ══════════════════════════════════════════
        private void btnMakeChartProduct_Click(object sender, EventArgs e)
        {
            if (cbTypeChartProduct.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại biểu đồ!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime endDate = DateTime.Today;
            DateTime startDate;
            string timeLabel;

            if (rad7daysProduct.Checked)
            {
                startDate = endDate.AddDays(-6);
                timeLabel = "7 ngày gần nhất";
            }
            else if (rad30daysProduct.Checked)
            {
                startDate = endDate.AddDays(-29);
                timeLabel = "30 ngày gần nhất";
            }
            else
            {
                startDate = endDate.AddMonths(-11);
                timeLabel = "12 tháng gần nhất";
            }

            switch (cbTypeChartProduct.SelectedIndex)
            {
                case 0: DrawImportByProductName(startDate, endDate, timeLabel); break;
                case 1: DrawImportByProductType(startDate, endDate, timeLabel); break;
                case 2: DrawSoldByProductName(startDate, endDate, timeLabel); break;
                case 3: DrawSoldByProductType(startDate, endDate, timeLabel); break;
                case 4:
                    string typeFilter = (comboBox1.SelectedIndex > 0)
                        ? comboBox1.SelectedItem.ToString() : "";
                    DrawSalesOverTime(startDate, endDate, timeLabel, typeFilter);
                    break;
            }
        }

        // ══════════════════════════════════════════
        //  CHART 0: SP NHẬP theo TÊN
        // ══════════════════════════════════════════
        private void DrawImportByProductName(DateTime start, DateTime end, string timeLabel)
        {
            // Dùng hàm mới của BUS_Imported — 1 query JOIN duy nhất
            DataTable dt = bus_imported.GetImportedItemsByDateRange(start, end);

            if (dt == null || dt.Rows.Count == 0)
            {
                ResetProductChart($"Không có dữ liệu nhập hàng\ntrong {timeLabel}.");
                return;
            }

            DrawPieAndBarChart(dt,
                nameCol: "ItemName",
                qtyCol: "TotalQty",
                priceCol: "TotalPrice",
                title: $"Sản phẩm đã nhập — {timeLabel}",
                unitLabel: "SL nhập");
        }

        // ══════════════════════════════════════════
        //  CHART 1: SP NHẬP theo LOẠI
        // ══════════════════════════════════════════
        private void DrawImportByProductType(DateTime start, DateTime end, string timeLabel)
        {
            // Dùng hàm mới của BUS_Imported — nhóm theo TypeProduct
            DataTable dt = bus_imported.GetImportedItemsByTypeAndDateRange(start, end);

            if (dt == null || dt.Rows.Count == 0)
            {
                ResetProductChart($"Không có dữ liệu nhập hàng\ntrong {timeLabel}.");
                return;
            }

            DrawPieAndBarChart(dt,
                nameCol: "TypeProduct",
                qtyCol: "TotalQty",
                priceCol: "TotalPrice",
                title: $"Nhập hàng theo loại SP — {timeLabel}",
                unitLabel: "SL nhập");
        }

        // ══════════════════════════════════════════
        //  CHART 2: SP BÁN theo TÊN
        // ══════════════════════════════════════════
        private void DrawSoldByProductName(DateTime start, DateTime end, string timeLabel)
        {
            DataTable dt = BuildSoldSummaryByProduct(start, end);

            if (dt == null || dt.Rows.Count == 0)
            {
                ResetProductChart($"Không có dữ liệu bán hàng\ntrong {timeLabel}.");
                return;
            }

            DrawPieAndBarChart(dt,
                nameCol: "ItemName",
                qtyCol: "TotalQty",
                priceCol: "TotalPrice",
                title: $"Sản phẩm đã bán — {timeLabel}",
                unitLabel: "SL bán");
        }

        // ══════════════════════════════════════════
        //  CHART 3: SP BÁN theo LOẠI
        // ══════════════════════════════════════════
        private void DrawSoldByProductType(DateTime start, DateTime end, string timeLabel)
        {
            DataTable dt = BuildSoldSummaryByType(start, end);

            if (dt == null || dt.Rows.Count == 0)
            {
                ResetProductChart($"Không có dữ liệu bán hàng\ntrong {timeLabel}.");
                return;
            }

            DrawPieAndBarChart(dt,
                nameCol: "TypeProduct",
                qtyCol: "TotalQty",
                priceCol: "TotalPrice",
                title: $"Bán hàng theo loại SP — {timeLabel}",
                unitLabel: "SL bán");
        }

        // ══════════════════════════════════════════
        //  CHART 4: Doanh thu theo THỜI GIAN
        // ══════════════════════════════════════════
        private void DrawSalesOverTime(DateTime start, DateTime end,
                                       string timeLabel, string typeFilter)
        {
            bool byDay = (end - start).TotalDays <= 31;

            var incomeMap = new Dictionary<string, double>();
            var spendMap = new Dictionary<string, double>();
            var labelOrder = new List<string>();

            if (byDay)
            {
                for (DateTime d = start; d <= end; d = d.AddDays(1))
                {
                    string lbl = d.ToString("dd/MM");
                    labelOrder.Add(lbl);
                    incomeMap[lbl] = (bus_ordered.GetValueOfAllBills_Day(d) ?? 0) / 1_000_000.0;
                    spendMap[lbl] = (bus_imported.GetValueOfAllBills_Day(d) ?? 0) / 1_000_000.0;
                }
            }
            else
            {
                DateTime cur = new DateTime(start.Year, start.Month, 1);
                DateTime endMonth = new DateTime(end.Year, end.Month, 1);
                while (cur <= endMonth)
                {
                    string lbl = cur.ToString("MM/yyyy");
                    labelOrder.Add(lbl);
                    incomeMap[lbl] = (bus_ordered.GetValueOfAllBills_Month(cur) ?? 0) / 1_000_000.0;
                    spendMap[lbl] = (bus_imported.GetValueOfAllBills_Month(cur) ?? 0) / 1_000_000.0;
                    cur = cur.AddMonths(1);
                }
            }

            cbInformationPlus.Series.Clear();
            cbInformationPlus.ChartAreas.Clear();
            cbInformationPlus.Titles.Clear();
            cbInformationPlus.Legends.Clear();

            string filterNote = string.IsNullOrEmpty(typeFilter) ? "" : $"  |  Lọc: {typeFilter}";
            cbInformationPlus.Titles.Add(new Title
            {
                Text = $"Doanh thu & Chi nhập ({timeLabel}){filterNote}",
                Font = new Font("Arial", 9f, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Docking = Docking.Top
            });

            var area = new ChartArea("Main");
            area.AxisX.LabelStyle.Angle = -35;
            area.AxisX.LabelStyle.Font = new Font("Arial", 8f);
            area.AxisX.Interval = 1;
            area.AxisY.Title = "Triệu VNĐ";
            area.AxisY.TitleFont = new Font("Arial", 8.5f, FontStyle.Bold);
            area.AxisY.LabelStyle.Format = "N1";
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.BackColor = Color.WhiteSmoke;
            cbInformationPlus.ChartAreas.Add(area);

            var legend = new Legend("L") { Font = new Font("Arial", 8.5f), Docking = Docking.Bottom };
            cbInformationPlus.Legends.Add(legend);

            var seriesIncome = new Series("Thu nhập")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "Main",
                Legend = "L",
                Color = Color.SteelBlue,
                IsValueShownAsLabel = true,
                LabelFormat = "N1",
                Font = new Font("Arial", 7f)
            };
            var seriesSpend = new Series("Chi nhập hàng")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "Main",
                Legend = "L",
                Color = Color.Coral,
                IsValueShownAsLabel = true,
                LabelFormat = "N1",
                Font = new Font("Arial", 7f)
            };
            var seriesProfit = new Series("Lợi nhuận")
            {
                ChartType = SeriesChartType.Line,
                ChartArea = "Main",
                Legend = "L",
                Color = Color.SeaGreen,
                BorderWidth = 2,
                MarkerStyle = MarkerStyle.Diamond,
                MarkerSize = 8
            };

            foreach (string lbl in labelOrder)
            {
                double inc = incomeMap.ContainsKey(lbl) ? incomeMap[lbl] : 0;
                double sp = spendMap.ContainsKey(lbl) ? spendMap[lbl] : 0;
                double profit = inc - sp;

                seriesIncome.Points.AddXY(lbl, inc);
                seriesSpend.Points.AddXY(lbl, sp);
                int ptP = seriesProfit.Points.AddXY(lbl, profit);
                seriesProfit.Points[ptP].Color = (profit >= 0) ? Color.SeaGreen : Color.OrangeRed;
            }

            cbInformationPlus.Series.Add(seriesIncome);
            cbInformationPlus.Series.Add(seriesSpend);
            cbInformationPlus.Series.Add(seriesProfit);
        }

        // ══════════════════════════════════════════
        //  HELPER: Tổng hợp bán hàng qua BUS_Ordered
        //  (tạm dùng vì BUS_Ordered chưa có ByDateRange)
        // ══════════════════════════════════════════
        private DataTable BuildSoldSummaryByProduct(DateTime start, DateTime end)
        {
            var qty = new Dictionary<string, double>();
            var price = new Dictionary<string, double>();

            DataTable bills = bus_ordered.GetAllBill();
            foreach (DataRow bill in bills.Rows)
            {
                if (!(bill[1] is DateTime d)) continue;
                if (d.Date < start.Date || d.Date > end.Date) continue;
                DataTable items = bus_ordered.GetAllItemInBill(bill[0].ToString());
                if (items == null) continue;
                foreach (DataRow item in items.Rows)
                {
                    string name = item["ItemName"].ToString();
                    double q = System.Convert.ToDouble(item["Quantity"]);
                    double tot = System.Convert.ToDouble(item["TotalPrice"]);
                    if (qty.ContainsKey(name)) { qty[name] += q; price[name] += tot; }
                    else { qty[name] = q; price[name] = tot; }
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("ItemName", typeof(string));
            dt.Columns.Add("TypeProduct", typeof(string));
            dt.Columns.Add("TotalQty", typeof(double));
            dt.Columns.Add("TotalPrice", typeof(double));
            foreach (var kv in qty)
                dt.Rows.Add(kv.Key, "", kv.Value, price[kv.Key]);
            dt.DefaultView.Sort = "TotalQty DESC";
            return dt.DefaultView.ToTable();
        }

        private DataTable BuildSoldSummaryByType(DateTime start, DateTime end)
        {
            var qty = new Dictionary<string, double>();
            var price = new Dictionary<string, double>();

            DataTable bills = bus_ordered.GetAllBill();
            foreach (DataRow bill in bills.Rows)
            {
                if (!(bill[1] is DateTime d)) continue;
                if (d.Date < start.Date || d.Date > end.Date) continue;
                DataTable items = bus_ordered.GetAllItemInBill(bill[0].ToString());
                if (items == null) continue;
                foreach (DataRow item in items.Rows)
                {
                    string type = item.Table.Columns.Contains("TypeProduct")
                        ? item["TypeProduct"].ToString() : "Khác";
                    double q = System.Convert.ToDouble(item["Quantity"]);
                    double tot = System.Convert.ToDouble(item["TotalPrice"]);
                    if (qty.ContainsKey(type)) { qty[type] += q; price[type] += tot; }
                    else { qty[type] = q; price[type] = tot; }
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("TypeProduct", typeof(string));
            dt.Columns.Add("TotalQty", typeof(double));
            dt.Columns.Add("TotalPrice", typeof(double));
            foreach (var kv in qty)
                dt.Rows.Add(kv.Key, kv.Value, price[kv.Key]);
            dt.DefaultView.Sort = "TotalQty DESC";
            return dt.DefaultView.ToTable();
        }

        // ══════════════════════════════════════════
        //  HELPER: Vẽ Pie (trái) + Bar ngang (phải)
        // ══════════════════════════════════════════
        private void DrawPieAndBarChart(DataTable dt, string nameCol, string qtyCol,
                                         string priceCol, string title, string unitLabel)
        {
            cbInformationPlus.Series.Clear();
            cbInformationPlus.ChartAreas.Clear();
            cbInformationPlus.Titles.Clear();
            cbInformationPlus.Legends.Clear();

            cbInformationPlus.Titles.Add(new Title
            {
                Text = title,
                Font = new Font("Arial", 9.5f, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                Docking = Docking.Top
            });

            // Pie bên trái
            var areaPie = new ChartArea("Pie");
            areaPie.Position = new ElementPosition(0, 10, 55, 85);
            areaPie.BackColor = Color.White;
            cbInformationPlus.ChartAreas.Add(areaPie);

            // Bar ngang bên phải
            var areaBar = new ChartArea("Bar");
            areaBar.Position = new ElementPosition(52, 10, 48, 85);
            areaBar.AxisY.LabelStyle.Format = "N0";
            areaBar.AxisY.MajorGrid.LineColor = Color.LightGray;
            areaBar.AxisX.LabelStyle.Font = new Font("Arial", 7.5f);
            areaBar.AxisY.LabelStyle.Font = new Font("Arial", 7.5f);
            areaBar.BackColor = Color.WhiteSmoke;
            cbInformationPlus.ChartAreas.Add(areaBar);

            var legend = new Legend("L")
            {
                DockedToChartArea = "Pie",
                IsDockedInsideChartArea = false,
                Docking = Docking.Bottom,
                Font = new Font("Arial", 7f),
                MaximumAutoSize = 50f
            };
            cbInformationPlus.Legends.Add(legend);

            Color[] palette = {
                Color.SteelBlue,    Color.MediumSeaGreen, Color.Coral,
                Color.MediumOrchid, Color.Goldenrod,      Color.LightSeaGreen,
                Color.IndianRed,    Color.CornflowerBlue, Color.DarkOrange,
                Color.MediumPurple, Color.Teal,           Color.Salmon
            };

            var seriesPie = new Series("Tỉ lệ " + unitLabel)
            {
                ChartType = SeriesChartType.Pie,
                ChartArea = "Pie",
                Legend = "L",
                IsValueShownAsLabel = true,
                LabelFormat = "#.#%",
                ["PieLabelStyle"] = "Disabled",
                ["PieDrawingStyle"] = "Concave"
            };

            var seriesBar = new Series(unitLabel)
            {
                ChartType = SeriesChartType.Bar,
                ChartArea = "Bar",
                IsValueShownAsLabel = true,
                LabelFormat = "N0",
                Font = new Font("Arial", 7f)
            };

            double total = 0;
            foreach (DataRow row in dt.Rows)
                total += System.Convert.ToDouble(row[qtyCol]);

            int maxRows = Math.Min(dt.Rows.Count, 12);
            for (int i = 0; i < maxRows; i++)
            {
                DataRow row = dt.Rows[i];
                string name = row[nameCol].ToString();
                double qty = System.Convert.ToDouble(row[qtyCol]);
                double pct = (total > 0) ? qty / total : 0;
                double price = System.Convert.ToDouble(row[priceCol]);
                Color col = palette[i % palette.Length];
                string shortName = name.Length > 16 ? name.Substring(0, 15) + "…" : name;

                int ptP = seriesPie.Points.AddXY(shortName, pct);
                seriesPie.Points[ptP].Color = col;
                seriesPie.Points[ptP].LegendText = $"{shortName}  ({qty:N0})";
                seriesPie.Points[ptP].ToolTip =
                    $"{name}\n{unitLabel}: {qty:N0}\nThành tiền: {price:N0} VNĐ\nTỉ lệ: {pct:P1}";
                seriesPie.Points[ptP]["Exploded"] = (i == 0) ? "true" : "false";

                int ptB = seriesBar.Points.AddXY(shortName, qty);
                seriesBar.Points[ptB].Color = col;
                seriesBar.Points[ptB].ToolTip = $"{name}: {qty:N0}";
            }

            cbInformationPlus.Series.Add(seriesPie);
            cbInformationPlus.Series.Add(seriesBar);
        }

        // ══════════════════════════════════════════
        //  SỰ KIỆN CÒN LẠI
        // ══════════════════════════════════════════
        private void btnReloadSellingHistory_Click(object sender, EventArgs e)
        {
            _allOrderedBills = bus_ordered.GetAllBill();
            dgvSellingHistory.DataSource = null;
            dgvSellingHistory.DataSource = _allOrderedBills;
            if (dgvSellingHistory.Columns.Count > 0)
                dgvSellingHistory.Columns[0].Visible = false;
        }

        private void btnReloadImportHistory_Click(object sender, EventArgs e)
        {
            _allImportBills = bus_imported.GetAllBill();
            dgvImportHistory.DataSource = null;
            dgvImportHistory.DataSource = _allImportBills;
            if (dgvImportHistory.Columns.Count > 0)
                dgvImportHistory.Columns[0].Visible = false;
        }

        private void dgvSellingHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvSellingHistory.CurrentRow == null) return;
            Ordered bill = new Ordered
            {
                ID = dgvSellingHistory.CurrentRow.Cells[0].Value.ToString(),
                DateCreate = (DateTime)dgvSellingHistory.CurrentRow.Cells[1].Value,
                Value = float.Parse(dgvSellingHistory.CurrentRow.Cells[2].Value.ToString()),
                StaffID = dgvSellingHistory.CurrentRow.Cells[4].Value.ToString(),
                CustomerName = dgvSellingHistory.CurrentRow.Cells[3].Value.ToString()
            };
            new FormBill(bill).Show();
        }

        private void dgvImportHistory_CellClick(object sender, DataGridViewCellEventArgs e) { }

        private void radReportToday_CheckedChanged(object sender, EventArgs e)
        {
            chbReportIncome.Enabled = chbReportIncome.Checked = !radReportToday.Checked;
            chbReportSpending.Enabled = chbReportSpending.Checked = !radReportToday.Checked;
        }

        private void btnCreateChart_Click(object sender, EventArgs e)
        {
            chartSales.Series["Thu nhập"].Points.Clear();
            chartSales.Series["Chi tiêu"].Points.Clear();

            if (rad7days.Checked)
            {
                DateTime now = DateTime.Today;
                for (DateTime d = now.AddDays(-6); d <= now; d = d.AddDays(1))
                {
                    chartSales.Series["Chi tiêu"].Points.AddXY(
                        d.Day + "-" + d.Month,
                        bus_imported.GetValueOfAllBills_Day(d).Value / 1000);
                    chartSales.Series["Thu nhập"].Points.AddXY(
                        d.Day + "-" + d.Month,
                        bus_ordered.GetValueOfAllBills_Day(d).Value / 1000);
                }
            }
            else if (rad6months.Checked)
            {
                DateTime now = DateTime.Today;
                for (DateTime d = now.AddMonths(-5); d <= now; d = d.AddMonths(1))
                {
                    chartSales.Series["Chi tiêu"].Points.AddXY(
                        d.Month + "-" + d.Year,
                        bus_imported.GetValueOfAllBills_Month(d).Value / 1_000_000);
                    chartSales.Series["Thu nhập"].Points.AddXY(
                        d.Month + "-" + d.Year,
                        bus_ordered.GetValueOfAllBills_Month(d).Value / 1_000_000);
                }
            }
            else if (rad5years.Checked)
            {
                DateTime now = DateTime.Today;
                for (DateTime d = now.AddYears(-4); d <= now; d = d.AddYears(1))
                {
                    double sp = 0, inc = 0;
                    for (int i = 1; i <= 12; i++)
                    {
                        var nd = new DateTime(d.Year, i, 1);
                        sp += bus_imported.GetValueOfAllBills_Month(nd).Value;
                        inc += bus_ordered.GetValueOfAllBills_Month(nd).Value;
                    }
                    chartSales.Series["Chi tiêu"].Points.AddXY(d.Year, sp / 1_000_000);
                    chartSales.Series["Thu nhập"].Points.AddXY(d.Year, inc / 1_000_000);
                }
            }
        }

        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control c in parent.Controls)
            {
                c.Font = font;
                if (c.HasChildren) ApplyFont(c, font);
            }
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e) { }
        private void btnOutputReport_Click(object sender, EventArgs e) { }
        private void dgvImportHistory_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cbInformationPlus_Click(object sender, EventArgs e) { }
    }
}