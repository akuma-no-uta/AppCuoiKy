using System.Windows.Forms;

namespace BasicGroceryStore
{
    partial class UCCalendar
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpInPromo;
        private System.Windows.Forms.GroupBox grpNotInPromo;
        private System.Windows.Forms.GroupBox grpChart;

        private System.Windows.Forms.TextBox txtPromotionName;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        private System.Windows.Forms.DataGridView dgvPromotion;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridView dgvAllProducts;

        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnRemoveProduct;

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCalendar));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtPromotionName = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPromotion = new System.Windows.Forms.DataGridView();
            this.grpInPromo = new System.Windows.Forms.GroupBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            this.grpNotInPromo = new System.Windows.Forms.GroupBox();
            this.dgvAllProducts = new System.Windows.Forms.DataGridView();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.grpChart = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotion)).BeginInit();
            this.grpInPromo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.grpNotInPromo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProducts)).BeginInit();
            this.grpChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMain.BackgroundImage")));
            this.pnlMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Controls.Add(this.grpInPromo);
            this.pnlMain.Controls.Add(this.grpNotInPromo);
            this.pnlMain.Controls.Add(this.grpChart);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1350, 860);
            this.pnlMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.txtPromotionName);
            this.panel1.Controls.Add(this.lblDiscount);
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Controls.Add(this.lblStart);
            this.panel1.Controls.Add(this.dtStart);
            this.panel1.Controls.Add(this.lblEnd);
            this.panel1.Controls.Add(this.dtEnd);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 195);
            this.panel1.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 18);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên KM:";
            // 
            // txtPromotionName
            // 
            this.txtPromotionName.Location = new System.Drawing.Point(130, 15);
            this.txtPromotionName.Name = "txtPromotionName";
            this.txtPromotionName.Size = new System.Drawing.Size(220, 26);
            this.txtPromotionName.TabIndex = 1;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(12, 58);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(104, 20);
            this.lblDiscount.TabIndex = 2;
            this.lblDiscount.Text = "Giảm giá (%):";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(130, 55);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(220, 26);
            this.txtDiscount.TabIndex = 3;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(12, 100);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(107, 20);
            this.lblStart.TabIndex = 4;
            this.lblStart.Text = "Ngày bắt đầu:";
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(130, 97);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(220, 26);
            this.dtStart.TabIndex = 5;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(12, 142);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(110, 20);
            this.lblEnd.TabIndex = 6;
            this.lblEnd.Text = "Ngày kết thúc:";
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(130, 139);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(220, 26);
            this.dtEnd.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(362, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 38);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Thêm KM";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(362, 68);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 38);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Sửa KM";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Tomato;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(362, 121);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 38);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Xóa KM";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvPromotion);
            this.groupBox1.Location = new System.Drawing.Point(15, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 485);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách khuyến mãi";
            // 
            // dgvPromotion
            // 
            this.dgvPromotion.AllowUserToAddRows = false;
            this.dgvPromotion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPromotion.ColumnHeadersHeight = 34;
            this.dgvPromotion.Location = new System.Drawing.Point(10, 30);
            this.dgvPromotion.MultiSelect = false;
            this.dgvPromotion.Name = "dgvPromotion";
            this.dgvPromotion.ReadOnly = true;
            this.dgvPromotion.RowHeadersWidth = 40;
            this.dgvPromotion.RowTemplate.Height = 28;
            this.dgvPromotion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPromotion.Size = new System.Drawing.Size(478, 443);
            this.dgvPromotion.TabIndex = 0;
            // 
            // grpInPromo
            // 
            this.grpInPromo.BackColor = System.Drawing.Color.White;
            this.grpInPromo.Controls.Add(this.dgvProducts);
            this.grpInPromo.Controls.Add(this.btnRemoveProduct);
            this.grpInPromo.Location = new System.Drawing.Point(525, 15);
            this.grpInPromo.Name = "grpInPromo";
            this.grpInPromo.Size = new System.Drawing.Size(390, 380);
            this.grpInPromo.TabIndex = 2;
            this.grpInPromo.TabStop = false;
            this.grpInPromo.Text = "Sản phẩm đang khuyến mãi";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeight = 30;
            this.dgvProducts.Location = new System.Drawing.Point(10, 28);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 40;
            this.dgvProducts.RowTemplate.Height = 26;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(370, 300);
            this.dgvProducts.TabIndex = 0;
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.BackColor = System.Drawing.Color.Tomato;
            this.btnRemoveProduct.FlatAppearance.BorderSize = 0;
            this.btnRemoveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveProduct.ForeColor = System.Drawing.Color.White;
            this.btnRemoveProduct.Location = new System.Drawing.Point(245, 336);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(135, 35);
            this.btnRemoveProduct.TabIndex = 1;
            this.btnRemoveProduct.Text = "▲  Xóa khỏi KM";
            this.btnRemoveProduct.UseVisualStyleBackColor = false;
            // 
            // grpNotInPromo
            // 
            this.grpNotInPromo.BackColor = System.Drawing.Color.White;
            this.grpNotInPromo.Controls.Add(this.dgvAllProducts);
            this.grpNotInPromo.Controls.Add(this.btnAddProduct);
            this.grpNotInPromo.Location = new System.Drawing.Point(525, 405);
            this.grpNotInPromo.Name = "grpNotInPromo";
            this.grpNotInPromo.Size = new System.Drawing.Size(390, 300);
            this.grpNotInPromo.TabIndex = 3;
            this.grpNotInPromo.TabStop = false;
            this.grpNotInPromo.Text = "Chọn sản phẩm để thêm vào KM";
            // 
            // dgvAllProducts
            // 
            this.dgvAllProducts.AllowUserToAddRows = false;
            this.dgvAllProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllProducts.ColumnHeadersHeight = 30;
            this.dgvAllProducts.Location = new System.Drawing.Point(10, 25);
            this.dgvAllProducts.MultiSelect = false;
            this.dgvAllProducts.Name = "dgvAllProducts";
            this.dgvAllProducts.ReadOnly = true;
            this.dgvAllProducts.RowHeadersWidth = 40;
            this.dgvAllProducts.RowTemplate.Height = 26;
            this.dgvAllProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllProducts.Size = new System.Drawing.Size(370, 222);
            this.dgvAllProducts.TabIndex = 0;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Location = new System.Drawing.Point(10, 253);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(135, 35);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "▼  Thêm vào KM";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            // 
            // grpChart
            // 
            this.grpChart.BackColor = System.Drawing.Color.White;
            this.grpChart.Controls.Add(this.chart1);
            this.grpChart.Location = new System.Drawing.Point(925, 15);
            this.grpChart.Name = "grpChart";
            this.grpChart.Size = new System.Drawing.Size(410, 625);
            this.grpChart.TabIndex = 4;
            this.grpChart.TabStop = false;
            this.grpChart.Text = "Biểu đồ tổng tiền được giảm giá (VNĐ)";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(8, 28);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(394, 588);
            this.chart1.TabIndex = 0;
            // 
            // UCCalendar
            // 
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.Controls.Add(this.pnlMain);
            this.Name = "UCCalendar";
            this.Size = new System.Drawing.Size(1350, 860);
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotion)).EndInit();
            this.grpInPromo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.grpNotInPromo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllProducts)).EndInit();
            this.grpChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}