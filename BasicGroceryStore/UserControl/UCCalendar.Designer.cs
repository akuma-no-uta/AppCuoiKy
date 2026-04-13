using System.Windows.Forms;

namespace BasicGroceryStore
{
    partial class UCCalendar
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlTop;
        private Panel pnlMain;
        private Label lblTitle;
        private DataGridView dgvPromotion;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        private TextBox txtPromotionName;
        private TextBox txtDiscount;

        private DateTimePicker dtStart;
        private DateTimePicker dtEnd;

        private Label lblName;
        private Label lblDiscount;
        private Label lblStart;
        private Label lblEnd;

        private ComboBox cbCategory;
        private Label lblCategory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvPromotion = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtPromotionName = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotion)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.OrangeRed;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1350, 60);
            this.pnlTop.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(317, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý khuyến mãi";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvPromotion);
            this.pnlMain.Controls.Add(this.btnAdd);
            this.pnlMain.Controls.Add(this.btnEdit);
            this.pnlMain.Controls.Add(this.btnDelete);
            this.pnlMain.Controls.Add(this.txtPromotionName);
            this.pnlMain.Controls.Add(this.txtDiscount);
            this.pnlMain.Controls.Add(this.dtStart);
            this.pnlMain.Controls.Add(this.dtEnd);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Controls.Add(this.lblDiscount);
            this.pnlMain.Controls.Add(this.lblStart);
            this.pnlMain.Controls.Add(this.lblEnd);
            this.pnlMain.Controls.Add(this.cbCategory);
            this.pnlMain.Controls.Add(this.lblCategory);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1350, 800);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // dgvPromotion
            // 
            this.dgvPromotion.AllowUserToAddRows = false;
            this.dgvPromotion.ColumnHeadersHeight = 34;
            this.dgvPromotion.Location = new System.Drawing.Point(24, 254);
            this.dgvPromotion.MultiSelect = false;
            this.dgvPromotion.Name = "dgvPromotion";
            this.dgvPromotion.ReadOnly = true;
            this.dgvPromotion.RowHeadersWidth = 62;
            this.dgvPromotion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPromotion.Size = new System.Drawing.Size(900, 383);
            this.dgvPromotion.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(550, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(550, 80);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 40);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(550, 140);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            // 
            // txtPromotionName
            // 
            this.txtPromotionName.Location = new System.Drawing.Point(180, 20);
            this.txtPromotionName.Name = "txtPromotionName";
            this.txtPromotionName.Size = new System.Drawing.Size(300, 26);
            this.txtPromotionName.TabIndex = 4;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(180, 70);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(300, 26);
            this.txtDiscount.TabIndex = 5;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(180, 120);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(300, 26);
            this.dtStart.TabIndex = 6;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(180, 170);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(300, 26);
            this.dtEnd.TabIndex = 7;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 20);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Tên KM:";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(20, 70);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(104, 20);
            this.lblDiscount.TabIndex = 9;
            this.lblDiscount.Text = "Giảm giá (%):";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(20, 120);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(107, 20);
            this.lblStart.TabIndex = 10;
            this.lblStart.Text = "Ngày bắt đầu:";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(20, 170);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(110, 20);
            this.lblEnd.TabIndex = 11;
            this.lblEnd.Text = "Ngày kết thúc:";
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.Items.AddRange(new object[] {
            "Tất cả",
            "Nước khoáng",
            "Nước giải khát",
            "Thực phẩm đóng hộp",
            "Bánh - kẹo"});
            this.cbCategory.Location = new System.Drawing.Point(180, 220);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(300, 28);
            this.cbCategory.TabIndex = 12;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(20, 220);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(86, 20);
            this.lblCategory.TabIndex = 13;
            this.lblCategory.Text = "Danh mục:";
            // 
            // UCCalendar
            // 
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "UCCalendar";
            this.Size = new System.Drawing.Size(1350, 860);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromotion)).EndInit();
            this.ResumeLayout(false);

        }
    }
}