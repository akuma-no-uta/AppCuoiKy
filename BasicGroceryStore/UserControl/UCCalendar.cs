using BasicGroceryStore.BusinessLogicLayer;
using BasicGroceryStore.DTO;
using System;
using System.Windows.Forms;

namespace BasicGroceryStore
{
    public partial class UCCalendar : UserControl
    {
        private BUS_Promotion busPromotion;
        private string selectedID = "";

        static UCCalendar _obj;

        public static UCCalendar Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new UCCalendar();
                }
                return _obj;
            }
        }

        public UCCalendar()
        {
            InitializeComponent();

            busPromotion = new BUS_Promotion();

            LoadPromotion();

            dgvPromotion.CellClick += dgvPromotion_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
        }

        private void UCCalendar_Load(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadPromotion()
        {
            dgvPromotion.DataSource = busPromotion.GetAllPromotion();
        }

        private void ClearForm()
        {
            txtPromotionName.Clear();
            txtDiscount.Clear();

            cbCategory.SelectedIndex = 0;

            dtStart.Value = DateTime.Now;
            dtEnd.Value = DateTime.Now;

            selectedID = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Promotion p = new Promotion();

                p.PromotionName = txtPromotionName.Text.Trim();
                p.Category = cbCategory.Text;
                p.DiscountPercent = float.Parse(txtDiscount.Text);
                p.StartDate = dtStart.Value;
                p.EndDate = dtEnd.Value;

                if (busPromotion.Create(p))
                {
                    MessageBox.Show("Thêm khuyến mãi thành công!");
                    LoadPromotion();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedID == "")
            {
                MessageBox.Show("Vui lòng chọn khuyễn mãi cần sửa!");
                return;
            }

            try
            {
                Promotion p = new Promotion();

                p.ID = selectedID;
                p.PromotionName = txtPromotionName.Text.Trim();
                p.Category = cbCategory.Text;
                p.DiscountPercent = float.Parse(txtDiscount.Text);
                p.StartDate = dtStart.Value;
                p.EndDate = dtEnd.Value;

                if (busPromotion.Update(p))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    LoadPromotion();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedID == "")
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                if (busPromotion.Delete(selectedID))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadPromotion();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void dgvPromotion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvPromotion.Rows[e.RowIndex];

            selectedID = row.Cells["ID"].Value.ToString();

            txtPromotionName.Text = row.Cells["PromotionName"].Value.ToString();
            cbCategory.Text = row.Cells["Category"].Value.ToString();
            txtDiscount.Text = row.Cells["DiscountPercent"].Value.ToString();

            dtStart.Value = System.Convert.ToDateTime(row.Cells["StartDate"].Value);
            dtEnd.Value = System.Convert.ToDateTime(row.Cells["EndDate"].Value);
        }
    }
}