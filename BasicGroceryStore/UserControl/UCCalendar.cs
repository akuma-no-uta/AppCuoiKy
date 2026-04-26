using BasicGroceryStore.BusinessLogicLayer;
using BasicGroceryStore.DTO;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicGroceryStore
{
    public partial class UCCalendar : UserControl
    {
        private BUS_Promotion busPromotion;
        private string selectedPromotionID = "";

        // Lưu toàn bộ danh sách sản phẩm chưa trong KM để filter
        private DataTable _allProductsTable;

        // Controls tìm kiếm — tạo bằng code vì không có trong Designer
        private TextBox _txtSearchProduct;
        private Label _lblSearchProduct;

        static UCCalendar _obj;
        public static UCCalendar Instance
        {
            get
            {
                if (_obj == null) _obj = new UCCalendar();
                return _obj;
            }
        }

        public UCCalendar()
        {
            InitializeComponent();
            busPromotion = new BUS_Promotion();

            // Tạo ô tìm kiếm sản phẩm phía trên dgvAllProducts
            BuildSearchBox();

            LoadPromotion();
            LoadChartTotalSaved();

            dgvPromotion.CellClick += dgvPromotion_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnAddProduct.Click += btnAddProduct_Click;
            btnRemoveProduct.Click += btnRemoveProduct_Click;
        }

        // ── TẠO Ô TÌM KIẾM ĐỘNG ──────────────────────────────────────────────
        private void BuildSearchBox()
        {
            // Label
            _lblSearchProduct = new Label();
            _lblSearchProduct.Text = "🔍 Tìm sản phẩm:";
            _lblSearchProduct.AutoSize = true;
            _lblSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            // TextBox
            _txtSearchProduct = new TextBox();
            // _txtSearchProduct.PlaceholderText = "Nhập tên sản phẩm...";
            _txtSearchProduct.ForeColor = System.Drawing.Color.Gray;
            _txtSearchProduct.Text = "Nhập tên sản phẩm...";
            _txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            _txtSearchProduct.Width = dgvAllProducts.Width;
            _txtSearchProduct.TextChanged += TxtSearchProduct_TextChanged;
            _txtSearchProduct.GotFocus += (s, e) =>
            {
                if (_txtSearchProduct.Text == "Nhập tên sản phẩm...")
                {
                    _txtSearchProduct.Text = "";
                    _txtSearchProduct.ForeColor = System.Drawing.Color.Black;
                }
            };
            _txtSearchProduct.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(_txtSearchProduct.Text))
                {
                    _txtSearchProduct.Text = "Nhập tên sản phẩm...";
                    _txtSearchProduct.ForeColor = System.Drawing.Color.Gray;
                }
            };

            // Đặt label và textbox vào cùng panel cha với dgvAllProducts
            var parent = dgvAllProducts.Parent;
            int x = dgvAllProducts.Left;
            int y = dgvAllProducts.Top;

            _lblSearchProduct.Location = new System.Drawing.Point(x, y - 44);
            _txtSearchProduct.Location = new System.Drawing.Point(x, y - 24);

            // Dịch dgvAllProducts xuống để nhường chỗ
            dgvAllProducts.Top += 50;
            dgvAllProducts.Height -= 50;

            parent.Controls.Add(_lblSearchProduct);
            parent.Controls.Add(_txtSearchProduct);

            _lblSearchProduct.BringToFront();
            _txtSearchProduct.BringToFront();
        }

        // ── TÌM KIẾM SẢN PHẨM REAL-TIME ─────────────────────────────────────
        private void TxtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            if (_allProductsTable == null) return;

            string keyword = _txtSearchProduct.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                dgvAllProducts.DataSource = _allProductsTable;
                return;
            }

            DataTable filtered = _allProductsTable.Clone();
            foreach (DataRow row in _allProductsTable.Rows)
            {
                // Tìm theo tên sản phẩm (cột Name)
                if (row["Name"].ToString().ToLower().Contains(keyword))
                    filtered.ImportRow(row);
            }

            dgvAllProducts.DataSource = filtered;
        }

        // ── LOAD ──────────────────────────────────────────────────────────────
        private void LoadPromotion()
        {
            dgvPromotion.DataSource = busPromotion.GetAllPromotion();
        }

        // ── CHART ─────────────────────────────────────────────────────────────
        private void LoadChartTotalSaved()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Tổng tiền được giảm giá (VNĐ)");

            Series series = new Series("Tiết kiệm");
            series.ChartType = SeriesChartType.Bar;
            series.Color = System.Drawing.Color.DeepSkyBlue;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "#,0";

            DataTable dt = busPromotion.GetTotalSavedByPromotion();
            foreach (DataRow row in dt.Rows)
            {
                string name = row["PromotionName"].ToString();
                double saved = row["TotalSaved"] == DBNull.Value
                               ? 0
                               : System.Convert.ToDouble(row["TotalSaved"].ToString());

                int idx = series.Points.AddXY(name, saved);
                series.Points[idx].ToolTip = string.Format("{0}: {1:#,0} VNĐ", name, saved);
            }

            chart1.Series.Add(series);
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,0";
        }

        // ── CLEAR ─────────────────────────────────────────────────────────────
        private void ClearForm()
        {
            txtPromotionName.Clear();
            txtDiscount.Clear();
            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;
            selectedPromotionID = "";
            dgvProducts.DataSource = null;
            dgvAllProducts.DataSource = null;
            _allProductsTable = null;
            if (_txtSearchProduct != null) _txtSearchProduct.Clear();
        }

        // ── ADD PROMOTION ──────────────────────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPromotionName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khuyến mãi!", "THÔNG BÁO",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dtEnd.Value.Date < dtStart.Value.Date)
                {
                    MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!", "THÔNG BÁO",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Promotion p = BuildPromotionFromForm();
                p.ID = Guid.NewGuid().ToString("N").Substring(0, 20);

                if (busPromotion.Create(p))
                {
                    MessageBox.Show("Thêm khuyến mãi thành công!", "THÔNG BÁO",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPromotion();
                    LoadChartTotalSaved();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại! Kiểm tra lại kết nối SQL Server.", "LỖI",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chi tiết: " + ex.Message
                    + "\n\n" + ex.InnerException?.Message, "LỖI",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── EDIT PROMOTION ─────────────────────────────────────────────────────
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedPromotionID == "")
            {
                MessageBox.Show("Chọn khuyến mãi cần sửa!", "THÔNG BÁO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                if (string.IsNullOrWhiteSpace(txtPromotionName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khuyến mãi!", "THÔNG BÁO",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dtEnd.Value.Date < dtStart.Value.Date)
                {
                    MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!", "THÔNG BÁO",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Promotion p = BuildPromotionFromForm();
                p.ID = selectedPromotionID;

                if (busPromotion.Update(p))
                {
                    MessageBox.Show("Cập nhật thành công!", "THÔNG BÁO",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPromotion();
                    LoadChartTotalSaved();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "LỖI",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chi tiết: " + ex.Message
                    + "\n\n" + ex.InnerException?.Message, "LỖI",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── DELETE PROMOTION ───────────────────────────────────────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPromotionID == "")
            {
                MessageBox.Show("Chọn khuyến mãi cần xóa!", "THÔNG BÁO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xóa khuyến mãi này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (busPromotion.Delete(selectedPromotionID))
                    {
                        MessageBox.Show("Xóa thành công!", "THÔNG BÁO",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPromotion();
                        LoadChartTotalSaved();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "LỖI",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chi tiết: " + ex.Message
                        + "\n\n" + ex.InnerException?.Message, "LỖI",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── CLICK ROW PROMOTION ───────────────────────────────────────────────
        private void dgvPromotion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvPromotion.Rows[e.RowIndex];

            selectedPromotionID = row.Cells["ID"].Value.ToString();
            txtPromotionName.Text = row.Cells["PromotionName"].Value.ToString();
            txtDiscount.Text = row.Cells["DiscountPercent"].Value.ToString();

            DateTime start, end;
            DateTime.TryParse(row.Cells["StartDate"].Value.ToString(), out start);
            DateTime.TryParse(row.Cells["EndDate"].Value.ToString(), out end);
            dtStart.Value = start;
            dtEnd.Value = end;

            if (_txtSearchProduct != null) _txtSearchProduct.Clear();
            LoadProductsInPromotion();
            LoadProductsNotInPromotion();
        }

        // ── LOAD SP ĐANG TRONG KM ─────────────────────────────────────────────
        private void LoadProductsInPromotion()
        {
            try
            {
                dgvProducts.DataSource = busPromotion.GetProductByPromotion(selectedPromotionID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load sản phẩm trong KM: " + ex.Message, "LỖI",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── LOAD SP CHƯA TRONG KM ────────────────────────────────────────────
        private void LoadProductsNotInPromotion()
        {
            try
            {
                _allProductsTable = busPromotion.GetProductsNotInPromotion(selectedPromotionID);
                dgvAllProducts.DataSource = _allProductsTable;

                // Reset ô tìm kiếm
                if (_txtSearchProduct != null) _txtSearchProduct.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load sản phẩm ngoài KM: " + ex.Message, "LỖI",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── THÊM SP VÀO KM ───────────────────────────────────────────────────
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (selectedPromotionID == "")
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi trước!", "THÔNG BÁO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvAllProducts.CurrentRow == null)
            {
                MessageBox.Show("Chọn sản phẩm cần thêm!", "THÔNG BÁO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productID = dgvAllProducts.CurrentRow.Cells["ID"].Value.ToString();

            if (busPromotion.AddProductToPromotion(selectedPromotionID, productID))
            {
                LoadProductsInPromotion();
                LoadProductsNotInPromotion();
                LoadChartTotalSaved();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại!", "LỖI",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── XÓA SP KHỎI KM ──────────────────────────────────────────────────
        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (selectedPromotionID == "")
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi trước!", "THÔNG BÁO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Chọn sản phẩm cần xóa!", "THÔNG BÁO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productID = dgvProducts.CurrentRow.Cells["ID"].Value.ToString();

            if (busPromotion.RemoveProductFromPromotion(selectedPromotionID, productID))
            {
                LoadProductsInPromotion();
                LoadProductsNotInPromotion();
                LoadChartTotalSaved();
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm thất bại!", "LỖI",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── HELPER ────────────────────────────────────────────────────────────
        private Promotion BuildPromotionFromForm()
        {
            float discount;
            if (!float.TryParse(txtDiscount.Text.Trim(), out discount))
            {
                MessageBox.Show("Phần trăm giảm giá không hợp lệ! Vui lòng nhập số.", "THÔNG BÁO",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw new Exception("DiscountPercent không hợp lệ");
            }

            return new Promotion
            {
                PromotionName = txtPromotionName.Text.Trim(),
                DiscountPercent = discount,
                StartDate = dtStart.Value,
                EndDate = dtEnd.Value
            };
        }
    }
}