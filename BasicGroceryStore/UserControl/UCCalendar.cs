using BasicGroceryStore.BusinessLogicLayer;
using BasicGroceryStore.DTO;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicGroceryStore
{
    public partial class UCCalendar : UserControl
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private Font customFont;

        private BUS_Promotion busPromotion;
        private string selectedID = "";

        static UCCalendar _obj;

        public static UCCalendar Instance
        {
            get
            {
                if (_obj == null)
                    _obj = new UCCalendar();
                return _obj;
            }
        }

        public UCCalendar()
        {
            InitializeComponent();

            // ===== FONT =====
            string fontPath = "C:/Users/LENOVO/BasicGroceryStore/BasicGroceryStore/Futura/SVN-Futura Book.ttf";
            pfc.AddFontFile(fontPath);

            customFont = (pfc.Families.Length > 0)
                ? new Font(pfc.Families[0], 11F)
                : this.Font;

            this.Font = customFont;
            ApplyFont(this, customFont);

            // ===== BUS =====
            busPromotion = new BUS_Promotion();

            // ===== LOAD =====
            LoadPromotion();
            LoadChart();

            // ===== EVENT =====
            dgvPromotion.CellClick += dgvPromotion_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        // ================= FONT =================
        private void ApplyFont(Control parent, Font font)
        {
            foreach (Control c in parent.Controls)
            {
                c.Font = font;
                if (c.HasChildren)
                    ApplyFont(c, font);
            }
        }

        // ================= LOAD DATA =================
        private void LoadPromotion()
        {
            dgvPromotion.DataSource = busPromotion.GetAllPromotion();
        }

        // ================= CHART =================
        private void LoadChart()
        {
            chart1.Series.Clear();

            Series series = new Series("Discount");
            series.ChartType = SeriesChartType.Column;

            DataTable dt = busPromotion.GetAllPromotion();

            foreach (DataRow row in dt.Rows)
            {
                string name = row["PromotionName"].ToString();

                float discount = 0;
                float.TryParse(row["DiscountPercent"].ToString(), out discount);

                series.Points.AddXY(name, discount);
            }

            chart1.Series.Add(series);
        }

        // ================= CLEAR FORM =================
        private void ClearForm()
        {
            txtPromotionName.Clear();
            txtDiscount.Clear();
            cbCategory.SelectedIndex = 0;

            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;

            selectedID = "";
            dataGridView1.DataSource = null;
        }

        // ================= ADD =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Promotion p = new Promotion();

                p.PromotionName = txtPromotionName.Text.Trim();
                p.Category = cbCategory.Text;

                float discount;
                float.TryParse(txtDiscount.Text, out discount);
                p.DiscountPercent = discount;

                p.StartDate = dtStart.Value;
                p.EndDate = dtEnd.Value;

                if (busPromotion.Create(p))
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadPromotion();
                    LoadChart();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        // ================= EDIT =================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedID == "")
            {
                MessageBox.Show("Chọn khuyến mãi!");
                return;
            }

            try
            {
                Promotion p = new Promotion();

                p.ID = selectedID;
                p.PromotionName = txtPromotionName.Text.Trim();
                p.Category = cbCategory.Text;

                float discount;
                float.TryParse(txtDiscount.Text, out discount);
                p.DiscountPercent = discount;

                p.StartDate = dtStart.Value;
                p.EndDate = dtEnd.Value;

                if (busPromotion.Update(p))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadPromotion();
                    LoadChart();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        // ================= DELETE =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedID == "")
            {
                MessageBox.Show("Chọn khuyến mãi!");
                return;
            }

            if (MessageBox.Show("Xóa?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (busPromotion.Delete(selectedID))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadPromotion();
                    LoadChart();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        // ================= CLICK ROW =================
        private void dgvPromotion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvPromotion.Rows[e.RowIndex];

            selectedID = row.Cells["ID"].Value.ToString();

            txtPromotionName.Text = row.Cells["PromotionName"].Value.ToString();
            cbCategory.Text = row.Cells["Category"].Value.ToString();
            txtDiscount.Text = row.Cells["DiscountPercent"].Value.ToString();

            DateTime start, end;

            DateTime.TryParse(row.Cells["StartDate"].Value.ToString(), out start);
            DateTime.TryParse(row.Cells["EndDate"].Value.ToString(), out end);

            dtStart.Value = start;
            dtEnd.Value = end;

            // 🔥 LOAD PRODUCT
            LoadProductByPromotion(selectedID);
        }

        // ================= LOAD PRODUCT =================
        private void LoadProductByPromotion(string promotionID)
        {
            try
            {
                DataTable dt = busPromotion.GetProductByPromotion(promotionID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load product: " + ex.Message);
            }
        }
    }
}