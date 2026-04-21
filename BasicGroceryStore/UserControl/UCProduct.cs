using ExcelDataReader;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace BasicGroceryStore
{
    public partial class UCProduct : UserControl
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private Font customFont;
        private BUS_Product bus_product;
        private BUS_Supplier bus_supplier;

        private Product _product;
        private Supplier _supplier = null;

        static UCProduct _obj;
        public static UCProduct Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new UCProduct();
                }
                return _obj;
            }
        }
        public UCProduct()
        {
            InitializeComponent();

            // ===================== FONT =====================
            string fontPath = "C:/Users/LENOVO/BasicGroceryStore/BasicGroceryStore/Futura/SVN-Futura Book.ttf";
            pfc.AddFontFile(fontPath);

            if (pfc.Families.Length > 0)
                customFont = new Font(pfc.Families[0], 11F);
            else
                customFont = this.Font;

            this.Font = customFont;
            ApplyFont(this, customFont);
            bus_product = new BUS_Product();
            bus_supplier = new BUS_Supplier();

            _product = new Product();
        }

        #region Function
        public void LoadData()
        {
            ClearProductDataForm();
            ClearSupplierForm();

            cbTypeProduct.DataSource = bus_product.GetAllTypeOfProduct();

            dgvProduct.Controls.Clear();
            dgvProduct.DataSource = bus_product.GetAllProduct();

            dgvProduct.Columns[0].Visible = false; //Hide ID column
        }

        private void ClearProductDataForm()
        {
            txtName.Clear();
            txtTypeProduct.Clear();
            txtUnit.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();

            picRepresent.Image = null;
        }

        private void ClearSupplierForm()
        {
            _supplier = null;

            txtSupplierID.Clear();
            txtSupplierName.Clear();
            txtSupplierAddress.Clear();
            txtSupplierEmail.Clear();
            txtSupplierPhone.Clear();

            dgvProductOfSupplier.Controls.Clear();
            dgvProductOfSupplier.DataSource = null;
        }

        /// <summary>
        /// Using for get union data from multiple tables
        /// </summary>
        /// <param name="table"></param>
        /// <param name="table_filter"></param>
        /// <returns></returns>
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
                    {
                        dataTable.ImportRow(row);
                    }
                }
            }
            return dataTable;
        }
        #endregion

        #region Control
        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if(_product.Name != "")
            {
                new FormProduct(_product).ShowDialog();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            new FormProduct().ShowDialog();
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            if(_supplier != null)
                new FormSupplier(_supplier).ShowDialog();
        }

        private void btnSeeMoreSupplier_Click(object sender, EventArgs e)
        {
            new FormSupplierSynthetic().ShowDialog();
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

        private void btnLoadSupplier_Click(object sender, EventArgs e)
        {
            _supplier = bus_supplier.GetSupplier(_product.SupplierID);

            txtSupplierID.Text = _supplier.ID;
            txtSupplierName.Text = _supplier.Name;
            txtSupplierAddress.Text = _supplier.Address;
            txtSupplierEmail.Text = _supplier.Email;
            txtSupplierPhone.Text = _supplier.Contact;

            dgvProductOfSupplier.DataSource = bus_product.GetProductOfSupplier(_supplier.ID);
            dgvProductOfSupplier.Columns[0].Visible = false;
            dgvProductOfSupplier.Columns[5].Visible = false;
            dgvProductOfSupplier.Columns[8].Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Bạn có muốn xóa sản phẩm {_product.Name}?", "CẢNH BÁO", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (bus_product.Delete(_product))
                {
                    MessageBox.Show("Đã xóa thông tin sản phẩm!", "THÔNG BÁO");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa thông tin sản phẩm không thành công!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNameFilter.Clear();
            numUDFrom.Value = 1;
            numUDTo.Value = 50;
            txtSupplierFilter.Clear();
            txtTypeProduct.Clear();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable table = null;
            DataTable table_filter;

            if (!chbName.Checked && !chbPrice.Checked && !chbSupplier.Checked && !chbTypeProduct.Checked)
                return;

            if(chbName.Checked)
            {
                table_filter = bus_product.FindProductByName(txtNameFilter.Text.Trim());
                table = getTableFilter(table, table_filter);
            }
            if (chbPrice.Checked)
            {
                float from = (float)numUDFrom.Value * 1000;
                float to = (float)numUDTo.Value * 1000;
                
                if(from > to)
                {
                    MessageBox.Show("Giá trị bắt đầu phải lớn hơn hoặc bằng giá trị kết thúc!", "THÔNG BÁO");
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

            dgvProduct.Controls.Clear();
            dgvProduct.DataSource = table;
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduct.CurrentCell.RowIndex == dgvProduct.RowCount - 1)
                return;

            ClearSupplierForm();

            _product = bus_product.GetProduct(dgvProduct.CurrentRow.Cells[0].Value.ToString()); 
            
            txtName.Text = _product.Name;
            txtTypeProduct.Text = _product.TypeProduct;
            txtUnit.Text = _product.Unit;
            txtQuantity.Text = _product.Quantity.ToString();
            txtPrice.Text = _product.Price.ToString();
            txtNote.Text = _product.Note;
            picRepresent.Image = _product.Image;
        }

        private void dgvProductOfSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductOfSupplier.CurrentCell.RowIndex == dgvProductOfSupplier.RowCount - 1)
                return;

            _product = bus_product.GetProduct(dgvProductOfSupplier.CurrentRow.Cells[0].Value.ToString());

            txtName.Text = _product.Name;
            txtTypeProduct.Text = _product.TypeProduct;
            txtUnit.Text = _product.Unit;
            txtQuantity.Text = _product.Quantity.ToString();
            txtPrice.Text = _product.Price.ToString();
            txtNote.Text = _product.Note;
            picRepresent.Image = _product.Image;
        }

        private void chbName_CheckedChanged(object sender, EventArgs e)
        {
            txtNameFilter.Enabled = chbName.Checked;
        }

        private void chbPrice_CheckedChanged(object sender, EventArgs e)
        {
            numUDFrom.Enabled = chbPrice.Checked;
            numUDTo.Enabled = chbPrice.Checked;
        }

        private void chbSupplier_CheckedChanged(object sender, EventArgs e)
        {
            txtSupplierFilter.Enabled = chbSupplier.Checked;
        }

        private void chbTypeProduct_CheckedChanged(object sender, EventArgs e)
        {
            cbTypeProduct.Enabled = chbTypeProduct.Checked;
        }

        #endregion

        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }

        private void gbSupplier_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void gbFilter_Enter_1(object sender, EventArgs e)
        {

        }

        private void txtTypeProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNote_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbDetail_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        DataTable table = result.Tables[0];

                        int successCount = 0;
                        int failCount = 0;

                        // 🔥 Supplier mặc định (bắt buộc phải tồn tại trong DB)
                        string defaultSupplierID = bus_supplier.GetSupplierIDByName("Vinamilk");

                        // 🔥 ảnh mặc định (tránh null)
                        Bitmap defaultImage = new Bitmap(1, 1);

                        for (int i = 1; i < table.Rows.Count; i++)
                        {
                            try
                            {
                                DataRow row = table.Rows[i];

                                string supplierID = defaultSupplierID;

                                // nếu có cột Supplier thì override
                                if (table.Columns.Count > 6)
                                {
                                    string supplierName = row[6].ToString().Trim();

                                    string foundID = bus_supplier.GetSupplierIDByName(supplierName);

                                    if (!string.IsNullOrEmpty(foundID))
                                        supplierID = foundID;
                                }

                                Product p = new Product()
                                {
                                    ID = Guid.NewGuid().ToString(),

                                    Name = row[0].ToString(),
                                    TypeProduct = row[1].ToString(),
                                    Unit = row[2].ToString(),

                                    Quantity = int.TryParse(row[3].ToString(), out int q) ? q : 0,
                                    Price = float.TryParse(row[4].ToString(), out float pr) ? pr : 0,

                                    Note = row[5].ToString(),

                                    SupplierID = supplierID,
                                    Image = defaultImage // 🔥 KHÔNG BAO GIỜ NULL
                                };

                                bool success = bus_product.Create(p);

                                if (success)
                                    successCount++;
                                else
                                    failCount++;
                            }
                            catch
                            {
                                failCount++;
                            }
                        }

                        MessageBox.Show(
                            $"Import xong!\nThành công: {successCount}\nThất bại: {failCount}",
                            "Kết quả"
                        );
                    }

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
   
}
