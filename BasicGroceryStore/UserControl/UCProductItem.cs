using System;
using System.Drawing;
using System.Windows.Forms;

namespace BasicGroceryStore
{
    public partial class UCProductItem : UserControl
    {
        #region properties
        private FlowLayoutPanel _container;
        private TextBox _txtTotalPrice;

        public string product_id;
        public string product_name;
        public float product_price;            // giá SAU giảm (dùng để tính tiền)
        public float product_original_price;   // giá GỐC (để hiển thị gạch ngang)
        public float product_discount;         // % giảm (0 nếu không có KM)
        public int product_quantity;
        public double total_value;
        #endregion

        /// <summary>Constructor cũ — tương thích ngược</summary>
        public UCProductItem(FlowLayoutPanel container, TextBox txtTotalPrice,
            string product_id, string product_name, float product_price)
            : this(container, txtTotalPrice, product_id, product_name, product_price, product_price, 0)
        { }

        /// <summary>Constructor đầy đủ — truyền cả giá gốc và % giảm</summary>
        public UCProductItem(FlowLayoutPanel container, TextBox txtTotalPrice,
            string product_id, string product_name,
            float product_price, float original_price, float discount)
        {
            InitializeComponent();

            this._container = container;
            this._txtTotalPrice = txtTotalPrice;

            this.product_id = product_id;
            this.product_name = product_name;
            this.product_price = product_price;
            this.product_original_price = original_price;
            this.product_discount = discount;
            this.product_quantity = 1;
        }

        /// <summary>Tính lại tổng hóa đơn và cập nhật txtTotalPrice</summary>
        public void CalculateTotalPrice()
        {
            double bill_sum = 0;
            foreach (UCProductItem item in _container.Controls)
                bill_sum += item.total_value;

            // Lưu số thô vào Tag để Parse về sau, hiển thị format đẹp
            _txtTotalPrice.Tag = bill_sum;
            _txtTotalPrice.Text = bill_sum.ToString("#,0") + " đ";
        }

        private void IncreaseQuantity()
        {
            numUDQuantity.Value += 1;
        }

        public void SettingMaxQuantity(int max_quantity)
        {
            numUDQuantity.Maximum = max_quantity;
        }

        public int FindThisItemInContainer()
        {
            foreach (UCProductItem item in _container.Controls)
            {
                if (item.product_id == this.product_id)
                    return _container.Controls.GetChildIndex(item);
            }
            return -1;
        }

        /// <summary>Thêm item mới hoặc tăng số lượng nếu đã có</summary>
        public void SettingItem()
        {
            int index = FindThisItemInContainer();
            if (index == -1)
            {
                lblProductName.Text = product_name;
                total_value = product_price;

                lblProductPrice.Text = product_price.ToString("#,0") + " đ";
                txtProductValue.Text = product_price.ToString("#,0") + " đ";

                if (product_discount > 0 && product_original_price > product_price)
                {
                    // Hiện giá gốc gạch ngang
                    lblOriginalPrice.Text = product_original_price.ToString("#,0") + " đ";
                    lblOriginalPrice.Visible = true;
                    lblOriginalPrice.Font = new Font(lblOriginalPrice.Font.FontFamily,
                                                       lblOriginalPrice.Font.Size,
                                                       FontStyle.Strikeout);

                    // Badge % giảm
                    lblDiscountBadge.Text = $"-{product_discount:0}%";
                    lblDiscountBadge.Visible = true;

                    // Làm nổi bật giá sau giảm
                    lblProductPrice.ForeColor = Color.DarkRed;
                    lblProductPrice.Font = new Font(lblProductPrice.Font.FontFamily,
                                                        lblProductPrice.Font.Size,
                                                        FontStyle.Bold);
                }
                else
                {
                    lblOriginalPrice.Visible = false;
                    lblDiscountBadge.Visible = false;
                    lblProductPrice.ForeColor = Color.Black;
                }

                _container.Controls.Add(this);
            }
            else
            {
                ((UCProductItem)_container.Controls[index]).IncreaseQuantity();
            }
            CalculateTotalPrice();
        }

        private void numUDQuantity_ValueChanged(object sender, EventArgs e)
        {
            product_quantity = (int)numUDQuantity.Value;
            total_value = product_quantity * product_price;
            txtProductValue.Text = total_value.ToString("#,0") + " đ";
            CalculateTotalPrice();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _container.Controls.Remove(this);
            CalculateTotalPrice();
        }
    }
}