using BasicGroceryStore.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace BasicGroceryStore
{
    public partial class UCOrdered : UserControl
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private Font customFont;
        private BUS_Promotion busPromotion;
        private BUS_Product bus_product;
        private BUS_Ordered bus_order;
        private BUS_Ordered_Item bus_item;

        private Ordered _order;
        private List<Ordered_Item> _orderedDetails;
        private DataTable _fullProductTable;

        static UCOrdered _obj;
        public static UCOrdered Instance
        {
            get
            {
                if (_obj == null) _obj = new UCOrdered();
                return _obj;
            }
        }

        public UCOrdered()
        {
            InitializeComponent();

            string fontPath = "C:/Users/LENOVO/BasicGroceryStore/BasicGroceryStore/Futura/SVN-Futura Book.ttf";
            pfc.AddFontFile(fontPath);

            customFont = pfc.Families.Length > 0
                ? new Font(pfc.Families[0], 11F)
                : this.Font;

            this.Font = customFont;
            ApplyFont(this, customFont);

            busPromotion = new BUS_Promotion();
            bus_product = new BUS_Product();
            bus_order = new BUS_Ordered();
            bus_item = new BUS_Ordered_Item();
        }

        // ── LOAD DATA ─────────────────────────────────────────────────────────
        public void LoadData()
        {
            cbTypeProduct.DataSource = bus_product.GetAllTypeOfProduct();

            dgvProduct.Controls.Clear();
            dgvProduct.DataSource = null;
            dgvProduct.Columns.Clear();

            _fullProductTable = bus_product.GetAllProduct();
            dgvProduct.DataSource = _fullProductTable;

            // Ẩn các cột không cần hiển thị
            foreach (string col in new[] { "ID", "Image", "Note", "SupplierID" })
                if (dgvProduct.Columns.Contains(col))
                    dgvProduct.Columns[col].Visible = false;

            // DiscountPercent và SalePrice đã có từ View — ẩn đi,
            // dùng để highlight và tính giá, không hiện số thô
            if (dgvProduct.Columns.Contains("DiscountPercent"))
            {
                dgvProduct.Columns["DiscountPercent"].Visible = false;
            }
            if (dgvProduct.Columns.Contains("SalePrice"))
            {
                dgvProduct.Columns["SalePrice"].Visible = false;
            }

            // Thêm cột Khuyến mãi để hiển thị text đẹp
            if (!dgvProduct.Columns.Contains("ColDiscount"))
            {
                var col = new DataGridViewTextBoxColumn();
                col.Name = "ColDiscount";
                col.HeaderText = "Khuyến mãi";
                col.ReadOnly = true;
                col.Width = 130;
                dgvProduct.Columns.Add(col);
            }

            HighlightDiscountedProducts();
        }

        // ── HIGHLIGHT SẢN PHẨM GIẢM GIÁ ─────────────────────────────────────
        // Đọc DiscountPercent trực tiếp từ DataTable (đã có từ View SQL)
        // Không còn gọi DB từng dòng → nhanh hơn, không bị lỗi im lặng
        private void HighlightDiscountedProducts()
        {
            foreach (DataGridViewRow row in dgvProduct.Rows)
            {
                if (row.IsNewRow) continue;

                float discount = 0;
                if (dgvProduct.Columns.Contains("DiscountPercent") &&
                    row.Cells["DiscountPercent"].Value != null &&
                    row.Cells["DiscountPercent"].Value != DBNull.Value)
                {
                    float.TryParse(row.Cells["DiscountPercent"].Value.ToString(), out discount);
                }

                if (!dgvProduct.Columns.Contains("ColDiscount")) continue;

                if (discount > 0)
                {
                    row.Cells["ColDiscount"].Value = $"🔥 Giảm {discount:0}%";
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    row.DefaultCellStyle.Font = new Font(customFont, FontStyle.Bold);
                    if (dgvProduct.Columns.Contains("Name"))
                        row.Cells["Name"].ToolTipText = $"Đang giảm {discount:0}% — nhấn đúp để thêm";
                }
                else
                {
                    row.Cells["ColDiscount"].Value = "";
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.Font = customFont;
                }
            }
        }

        // ── STAFF INFO ────────────────────────────────────────────────────────
        public void settingStaffInformation()
        {
            if (MainForm.staff_using != null)
                txtStaffName.Text = MainForm.staff_using.Name;
            else
                txtStaffName.Clear();
        }

        private Ordered settingInformation()
        {
            Ordered order = new Ordered();
            txtBillID.Text = order.ID;
            dtPickDateCreate.Value = order.DateCreate;
            settingStaffInformation();
            return order;
        }

        private void clearInformation()
        {
            txtBillID.Clear();
            txtStaffName.Clear();
            txtTotalPrice.Clear();
            txtCustomerName.Clear();
            txtSdt.Clear();
            flowpnl_Item.Controls.Clear();
            if (_orderedDetails != null) _orderedDetails.Clear();
            _order = null;
        }

        private DataTable getTableFilter(DataTable table, DataTable table_filter)
        {
            DataTable dataTable;
            if (table == null)
            {
                table = table_filter;
                table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };
                dataTable = table;
            }
            else
            {
                dataTable = table.Clone();
                foreach (DataRow row in table_filter.Rows)
                {
                    if (table.Rows.Contains(row[0]))
                        dataTable.ImportRow(row);
                }
            }
            return dataTable;
        }

        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control c in parent.Controls)
            {
                c.Font = font;
                if (c.HasChildren) ApplyFont(c, font);
            }
        }

        // ── BUTTONS ───────────────────────────────────────────────────────────
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnCancelBill_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy toàn bộ phiếu bán hàng?", "CẢNH BÁO",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                clearInformation();
        }

        private void btnMakeBills_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Bạn có muốn in hóa đơn không?", "THÔNG BÁO",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    break;

                case DialogResult.No:
                    if (_order == null)
                    {
                        MessageBox.Show("Chưa có thông tin phiếu bán hàng!", "THÔNG BÁO",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (_orderedDetails == null) _orderedDetails = new List<Ordered_Item>();

                    for (int i = 0; i < flowpnl_Item.Controls.Count; i++)
                    {
                        UCProductItem item = (UCProductItem)flowpnl_Item.Controls[i];
                        _orderedDetails.Add(new Ordered_Item(
                            iD: i + 1,
                            billID: _order.ID,
                            productID: item.product_id,
                            price: item.product_price,
                            quantity: item.product_quantity));
                    }

                    if (MainForm.staff_using != null)
                        _order.StaffID = MainForm.staff_using.ID;
                    else
                        _order.StaffID = "";

                    string customerName = txtCustomerName.Text.Trim();
                    string customerPhone = txtSdt.Text.Trim();

                    if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(customerPhone))
                    {
                        MessageBox.Show("Vui lòng nhập tên khách hàng và số điện thoại!",
                            "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (bus_order.CheckCustomerExists(customerName, customerPhone))
                    {
                        MessageBox.Show("Khách hàng này đã tồn tại!",
                            "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    _order.CustomerName = customerName;
                    _order.Value = txtTotalPrice.Tag != null
                        ? (float)(double)txtTotalPrice.Tag
                        : float.Parse(txtTotalPrice.Text.Replace(".", "").Replace(",", "").Replace(" đ", "").Trim());

                    if (bus_order.Create(_order, _order.CustomerName))
                    {
                        bool allItemsSaved = true;
                        foreach (Ordered_Item oi in _orderedDetails)
                        {
                            if (!bus_product.ReduceStock(oi.ProductID, oi.Quantity))
                            {
                                MessageBox.Show($"Không đủ hàng trong kho cho sản phẩm {oi.ProductID}!",
                                    "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                allItemsSaved = false;
                                break;
                            }
                            if (!bus_item.Create(oi))
                            {
                                MessageBox.Show("Lỗi khi lưu chi tiết hóa đơn!", "THÔNG BÁO",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                allItemsSaved = false;
                                break;
                            }
                        }

                        if (allItemsSaved)
                        {
                            MessageBox.Show("Đã lưu thông tin hóa đơn thành công!", "THÔNG BÁO",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainForm.LoadData.Invoke();
                            clearInformation();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lưu hóa đơn thất bại! Vui lòng thử lại.", "LỖI",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                default:
                    break;
            }
        }

        private void btnChooseProduct_Click(object sender, EventArgs e) { }

        private void btnCheckHistory_Click(object sender, EventArgs e)
        {
            UCStatistic.Instance.BringToFront();
        }

        private void btnUseScanMachine_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang được phát triển!");
        }

        private void btnCheckCustomer_Click(object sender, EventArgs e)
        {
            UCHomePage.Instance.BringToFront();
        }

        // ── TÌM KIẾM SẢN PHẨM ───────────────────────────────────────────────
        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable table = null;
            DataTable table_filter;

            if (!chbName.Checked && !chbPrice.Checked && !chbSupplier.Checked && !chbTypeProduct.Checked)
                return;

            if (chbName.Checked)
            {
                table_filter = bus_product.FindProductByName(txtNameFilter.Text.Trim());
                table = getTableFilter(table, table_filter);
            }
            if (chbPrice.Checked)
            {
                float from = (float)numUDFrom.Value * 1000;
                float to = (float)numUDTo.Value * 1000;

                if (from > to)
                {
                    MessageBox.Show("Giá trị bắt đầu phải nhỏ hơn hoặc bằng giá trị kết thúc!", "THÔNG BÁO");
                    return;
                }

                table_filter = bus_product.FindProductByPriceRange(from, to);
                table = getTableFilter(table, table_filter);
            }
            if (chbSupplier.Checked)
            {
                table_filter = bus_product.FindProductBySupplier(txtSupplierFilter.Text.Trim());
                table = getTableFilter(table, table_filter);
            }
            if (chbTypeProduct.Checked)
            {
                table_filter = bus_product.FindProductByTypeProduct(cbTypeProduct.Text.Trim());
                table = getTableFilter(table, table_filter);
            }

            dgvProduct.DataSource = null;
            dgvProduct.Columns.Clear();
            dgvProduct.DataSource = table;

            foreach (string col in new[] { "ID", "Image", "Note", "SupplierID" })
                if (dgvProduct.Columns.Contains(col))
                    dgvProduct.Columns[col].Visible = false;

            if (dgvProduct.Columns.Contains("DiscountPercent"))
                dgvProduct.Columns["DiscountPercent"].Visible = false;
            if (dgvProduct.Columns.Contains("SalePrice"))
                dgvProduct.Columns["SalePrice"].Visible = false;

            if (!dgvProduct.Columns.Contains("ColDiscount"))
            {
                var col = new DataGridViewTextBoxColumn();
                col.Name = "ColDiscount";
                col.HeaderText = "Khuyến mãi";
                col.ReadOnly = true;
                col.Width = 130;
                dgvProduct.Columns.Add(col);
            }

            HighlightDiscountedProducts();
        }

        // ── DOUBLE CLICK CHỌN SẢN PHẨM ───────────────────────────────────────
        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == dgvProduct.RowCount - 1)
                return;

            DataGridViewRow currentRow = dgvProduct.CurrentRow;
            if (currentRow == null) return;

            string product_id = "";
            string name = "";
            int store_quantity = 0;
            float originalPrice = 0;
            float salePrice = 0;
            float discount = 0;

            try
            {
                product_id = dgvProduct.Columns.Contains("ID")
                    ? currentRow.Cells["ID"].Value?.ToString().Trim() ?? ""
                    : currentRow.Cells[0].Value?.ToString().Trim() ?? "";

                name = dgvProduct.Columns.Contains("Name")
                    ? currentRow.Cells["Name"].Value?.ToString() ?? ""
                    : currentRow.Cells[1].Value?.ToString() ?? "";

                string qtyStr = dgvProduct.Columns.Contains("Quantity")
                    ? currentRow.Cells["Quantity"].Value?.ToString()
                    : currentRow.Cells[4].Value?.ToString();

                string priceStr = dgvProduct.Columns.Contains("Price")
                    ? currentRow.Cells["Price"].Value?.ToString()
                    : currentRow.Cells[7].Value?.ToString();

                // Đọc SalePrice và DiscountPercent trực tiếp từ View — không cần gọi DB nữa
                string salePriceStr = dgvProduct.Columns.Contains("SalePrice")
                    ? currentRow.Cells["SalePrice"].Value?.ToString()
                    : null;
                string discountStr = dgvProduct.Columns.Contains("DiscountPercent")
                    ? currentRow.Cells["DiscountPercent"].Value?.ToString()
                    : null;

                if (string.IsNullOrEmpty(product_id)) return;
                if (!int.TryParse(qtyStr, out store_quantity)) store_quantity = 0;
                if (!float.TryParse(priceStr, out originalPrice)) originalPrice = 0;
                if (!float.TryParse(salePriceStr, out salePrice)) salePrice = originalPrice;
                if (!float.TryParse(discountStr, out discount)) discount = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc dữ liệu sản phẩm: " + ex.Message);
                return;
            }

            if (_order == null)
                _order = settingInformation();

            if (_orderedDetails == null)
                _orderedDetails = new List<Ordered_Item>();

            // Thông báo nếu có khuyến mãi
          

            UCProductItem item = new UCProductItem(
                flowpnl_Item, txtTotalPrice,
                product_id, name, salePrice, originalPrice, discount);

            if (store_quantity < 1)
            {
                MessageBox.Show("Vui lòng nhập thêm sản phẩm!", "THÔNG BÁO",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int index = item.FindThisItemInContainer();
                if (index != -1 &&
                    ((UCProductItem)flowpnl_Item.Controls[index]).product_quantity >= store_quantity)
                {
                    MessageBox.Show("Không đủ số lượng hàng trong kho!");
                    return;
                }
                else
                {
                    item.SettingMaxQuantity(store_quantity);
                    item.SettingItem();
                }
            }
        }

        // ── Empty handlers ────────────────────────────────────────────────────
        private void gbFilter_Enter(object sender, EventArgs e) { }
        private void pnlMain_Paint(object sender, PaintEventArgs e) { }
        private void gbMakeBill_Enter(object sender, EventArgs e) { }
        private void gbListProduct_Enter(object sender, EventArgs e) { }
        private void dtPickDateCreate_ValueChanged(object sender, EventArgs e) { }
        private void txtStaffName_TextChanged(object sender, EventArgs e) { }
        private void txtBillID_TextChanged(object sender, EventArgs e) { }
        private void txtTotalPrice_TextChanged(object sender, EventArgs e) { }
        private void txtCustomerName_TextChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void flowpnl_Item_Paint(object sender, PaintEventArgs e) { }
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void btnClear_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void numUDTo_ValueChanged(object sender, EventArgs e) { }
        private void numUDFrom_ValueChanged(object sender, EventArgs e) { }
        private void cbTypeProduct_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtSupplierFilter_TextChanged(object sender, EventArgs e) { }
        private void txtNameFilter_TextChanged(object sender, EventArgs e) { }
        private void chbTypeProduct_CheckedChanged(object sender, EventArgs e) { }
        private void chbSupplier_CheckedChanged(object sender, EventArgs e) { }
        private void chbPrice_CheckedChanged(object sender, EventArgs e) { }
        private void chbName_CheckedChanged(object sender, EventArgs e) { }
        private void toolTip_Popup(object sender, PopupEventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void txtStaffName_TextChanged_1(object sender, EventArgs e) { }
    }
}