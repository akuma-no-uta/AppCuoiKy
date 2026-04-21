
namespace BasicGroceryStore
{
    partial class UCImported
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCImported));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbMakeBill = new System.Windows.Forms.GroupBox();
            this.gbListProduct = new System.Windows.Forms.GroupBox();
            this.btnMakeBills = new System.Windows.Forms.Button();
            this.flowpnl_Item = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancelBill = new System.Windows.Forms.Button();
            this.dtPickDateCreate = new System.Windows.Forms.DateTimePicker();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.txtBillID = new System.Windows.Forms.TextBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.btnMakeNewProduct = new System.Windows.Forms.Button();
            this.btnChooseProduct = new System.Windows.Forms.Button();
            this.btnCheckSupplier = new System.Windows.Forms.Button();
            this.btnCheckHistory = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.numUDFrom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.numUDTo = new System.Windows.Forms.NumericUpDown();
            this.txtSupplierFilter = new System.Windows.Forms.TextBox();
            this.cbTypeProduct = new System.Windows.Forms.ComboBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbName = new System.Windows.Forms.CheckBox();
            this.chbPrice = new System.Windows.Forms.CheckBox();
            this.chbSupplier = new System.Windows.Forms.CheckBox();
            this.chbTypeProduct = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.gbMakeBill.SuspendLayout();
            this.gbListProduct.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDTo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.DarkViolet;
            this.pnlMain.Controls.Add(this.gbMakeBill);
            this.pnlMain.Controls.Add(this.gbFilter);
            this.pnlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1350, 860);
            this.pnlMain.TabIndex = 3;
            // 
            // gbMakeBill
            // 
            this.gbMakeBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.gbMakeBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gbMakeBill.BackgroundImage")));
            this.gbMakeBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbMakeBill.Controls.Add(this.gbListProduct);
            this.gbMakeBill.Controls.Add(this.dtPickDateCreate);
            this.gbMakeBill.Controls.Add(this.txtStaffName);
            this.gbMakeBill.Controls.Add(this.txtBillID);
            this.gbMakeBill.Controls.Add(this.txtTotalPrice);
            this.gbMakeBill.Controls.Add(this.label6);
            this.gbMakeBill.Controls.Add(this.label4);
            this.gbMakeBill.Controls.Add(this.label3);
            this.gbMakeBill.Controls.Add(this.label2);
            this.gbMakeBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMakeBill.Location = new System.Drawing.Point(643, 0);
            this.gbMakeBill.Name = "gbMakeBill";
            this.gbMakeBill.Size = new System.Drawing.Size(707, 860);
            this.gbMakeBill.TabIndex = 6;
            this.gbMakeBill.TabStop = false;
            this.gbMakeBill.Text = "Tạo thông tin nhập hàng";
            // 
            // gbListProduct
            // 
            this.gbListProduct.BackColor = System.Drawing.Color.White;
            this.gbListProduct.Controls.Add(this.btnMakeBills);
            this.gbListProduct.Controls.Add(this.flowpnl_Item);
            this.gbListProduct.Controls.Add(this.btnCancelBill);
            this.gbListProduct.Location = new System.Drawing.Point(6, 239);
            this.gbListProduct.Name = "gbListProduct";
            this.gbListProduct.Size = new System.Drawing.Size(592, 487);
            this.gbListProduct.TabIndex = 37;
            this.gbListProduct.TabStop = false;
            this.gbListProduct.Text = "Danh sách sản phẩm nhập kho";
            // 
            // btnMakeBills
            // 
            this.btnMakeBills.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnMakeBills.ForeColor = System.Drawing.Color.White;
            this.btnMakeBills.Location = new System.Drawing.Point(398, 445);
            this.btnMakeBills.Name = "btnMakeBills";
            this.btnMakeBills.Size = new System.Drawing.Size(183, 36);
            this.btnMakeBills.TabIndex = 38;
            this.btnMakeBills.Text = "Tạo phiếu nhập";
            this.btnMakeBills.UseVisualStyleBackColor = false;
            this.btnMakeBills.Click += new System.EventHandler(this.btnMakeBills_Click);
            // 
            // flowpnl_Item
            // 
            this.flowpnl_Item.AutoScroll = true;
            this.flowpnl_Item.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowpnl_Item.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flowpnl_Item.Location = new System.Drawing.Point(6, 29);
            this.flowpnl_Item.Name = "flowpnl_Item";
            this.flowpnl_Item.Size = new System.Drawing.Size(575, 410);
            this.flowpnl_Item.TabIndex = 1;
            this.toolTip.SetToolTip(this.flowpnl_Item, "Nhấn đúp chuột vào sản phẩm để thêm vào giỏ hàng");
            // 
            // btnCancelBill
            // 
            this.btnCancelBill.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCancelBill.ForeColor = System.Drawing.Color.White;
            this.btnCancelBill.Location = new System.Drawing.Point(6, 445);
            this.btnCancelBill.Name = "btnCancelBill";
            this.btnCancelBill.Size = new System.Drawing.Size(183, 36);
            this.btnCancelBill.TabIndex = 32;
            this.btnCancelBill.Text = "Hủy phiếu nhập";
            this.btnCancelBill.UseVisualStyleBackColor = false;
            this.btnCancelBill.Click += new System.EventHandler(this.btnCancelBill_Click);
            // 
            // dtPickDateCreate
            // 
            this.dtPickDateCreate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtPickDateCreate.Enabled = false;
            this.dtPickDateCreate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickDateCreate.Location = new System.Drawing.Point(189, 138);
            this.dtPickDateCreate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtPickDateCreate.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dtPickDateCreate.Name = "dtPickDateCreate";
            this.dtPickDateCreate.Size = new System.Drawing.Size(318, 30);
            this.dtPickDateCreate.TabIndex = 36;
            this.dtPickDateCreate.Value = new System.DateTime(2022, 2, 4, 0, 0, 0, 0);
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(189, 43);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.Size = new System.Drawing.Size(318, 30);
            this.txtStaffName.TabIndex = 35;
            // 
            // txtBillID
            // 
            this.txtBillID.Location = new System.Drawing.Point(189, 90);
            this.txtBillID.Name = "txtBillID";
            this.txtBillID.ReadOnly = true;
            this.txtBillID.Size = new System.Drawing.Size(318, 30);
            this.txtBillID.TabIndex = 34;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(189, 187);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(318, 30);
            this.txtTotalPrice.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(18, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 25);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tổng tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(18, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày tạo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(18, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhân viên";
            // 
            // gbFilter
            // 
            this.gbFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(158)))), ((int)(((byte)(247)))));
            this.gbFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gbFilter.BackgroundImage")));
            this.gbFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbFilter.Controls.Add(this.groupBox1);
            this.gbFilter.Controls.Add(this.panel2);
            this.gbFilter.Controls.Add(this.panel1);
            this.gbFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(0, 0);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(656, 860);
            this.gbFilter.TabIndex = 5;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Lọc thông tin";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvProduct);
            this.groupBox1.Controls.Add(this.btnMakeNewProduct);
            this.groupBox1.Controls.Add(this.btnChooseProduct);
            this.groupBox1.Controls.Add(this.btnCheckSupplier);
            this.groupBox1.Controls.Add(this.btnCheckHistory);
            this.groupBox1.Location = new System.Drawing.Point(15, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 436);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách sản phẩm";
            // 
            // dgvProduct
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumPurple;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.EnableHeadersVisualStyles = false;
            this.dgvProduct.Location = new System.Drawing.Point(6, 29);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.ReadOnly = true;
            this.dgvProduct.RowHeadersWidth = 62;
            this.dgvProduct.Size = new System.Drawing.Size(599, 307);
            this.dgvProduct.TabIndex = 34;
            this.dgvProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellDoubleClick);
            // 
            // btnMakeNewProduct
            // 
            this.btnMakeNewProduct.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnMakeNewProduct.ForeColor = System.Drawing.Color.White;
            this.btnMakeNewProduct.Location = new System.Drawing.Point(6, 342);
            this.btnMakeNewProduct.Name = "btnMakeNewProduct";
            this.btnMakeNewProduct.Size = new System.Drawing.Size(220, 36);
            this.btnMakeNewProduct.TabIndex = 32;
            this.btnMakeNewProduct.Text = "Thêm sản phẩm mới";
            this.btnMakeNewProduct.UseVisualStyleBackColor = false;
            this.btnMakeNewProduct.Click += new System.EventHandler(this.btnMakeNewProduct_Click);
            // 
            // btnChooseProduct
            // 
            this.btnChooseProduct.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnChooseProduct.ForeColor = System.Drawing.Color.White;
            this.btnChooseProduct.Location = new System.Drawing.Point(376, 342);
            this.btnChooseProduct.Name = "btnChooseProduct";
            this.btnChooseProduct.Size = new System.Drawing.Size(220, 36);
            this.btnChooseProduct.TabIndex = 29;
            this.btnChooseProduct.Text = "Chọn sản phẩm";
            this.btnChooseProduct.UseVisualStyleBackColor = false;
            // 
            // btnCheckSupplier
            // 
            this.btnCheckSupplier.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCheckSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckSupplier.ForeColor = System.Drawing.Color.White;
            this.btnCheckSupplier.Location = new System.Drawing.Point(6, 394);
            this.btnCheckSupplier.Name = "btnCheckSupplier";
            this.btnCheckSupplier.Size = new System.Drawing.Size(220, 36);
            this.btnCheckSupplier.TabIndex = 30;
            this.btnCheckSupplier.Text = "Thông tin các nhà cung cấp";
            this.btnCheckSupplier.UseVisualStyleBackColor = false;
            this.btnCheckSupplier.Click += new System.EventHandler(this.btnCheckSupplier_Click);
            // 
            // btnCheckHistory
            // 
            this.btnCheckHistory.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCheckHistory.ForeColor = System.Drawing.Color.White;
            this.btnCheckHistory.Location = new System.Drawing.Point(376, 394);
            this.btnCheckHistory.Name = "btnCheckHistory";
            this.btnCheckHistory.Size = new System.Drawing.Size(220, 36);
            this.btnCheckHistory.TabIndex = 28;
            this.btnCheckHistory.Text = "Lịch sử nhập hàng";
            this.btnCheckHistory.UseVisualStyleBackColor = false;
            this.btnCheckHistory.Click += new System.EventHandler(this.btnCheckHistory_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtNameFilter);
            this.panel2.Controls.Add(this.numUDFrom);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnReload);
            this.panel2.Controls.Add(this.numUDTo);
            this.panel2.Controls.Add(this.txtSupplierFilter);
            this.panel2.Controls.Add(this.cbTypeProduct);
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Location = new System.Drawing.Point(268, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 242);
            this.panel2.TabIndex = 36;
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Location = new System.Drawing.Point(17, 54);
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(315, 30);
            this.txtNameFilter.TabIndex = 20;
            // 
            // numUDFrom
            // 
            this.numUDFrom.Location = new System.Drawing.Point(17, 90);
            this.numUDFrom.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUDFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDFrom.Name = "numUDFrom";
            this.numUDFrom.Size = new System.Drawing.Size(107, 30);
            this.numUDFrom.TabIndex = 23;
            this.numUDFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "đến";
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(17, 203);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(123, 36);
            this.btnReload.TabIndex = 33;
            this.btnReload.Text = "Tải lại";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // numUDTo
            // 
            this.numUDTo.Location = new System.Drawing.Point(206, 88);
            this.numUDTo.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numUDTo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUDTo.Name = "numUDTo";
            this.numUDTo.Size = new System.Drawing.Size(107, 30);
            this.numUDTo.TabIndex = 24;
            this.numUDTo.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // txtSupplierFilter
            // 
            this.txtSupplierFilter.Location = new System.Drawing.Point(17, 126);
            this.txtSupplierFilter.Name = "txtSupplierFilter";
            this.txtSupplierFilter.Size = new System.Drawing.Size(315, 30);
            this.txtSupplierFilter.TabIndex = 21;
            // 
            // cbTypeProduct
            // 
            this.cbTypeProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeProduct.FormattingEnabled = true;
            this.cbTypeProduct.Location = new System.Drawing.Point(17, 162);
            this.cbTypeProduct.Name = "cbTypeProduct";
            this.cbTypeProduct.Size = new System.Drawing.Size(315, 33);
            this.cbTypeProduct.TabIndex = 22;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(181, 206);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(151, 36);
            this.btnFind.TabIndex = 27;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.chbName);
            this.panel1.Controls.Add(this.chbPrice);
            this.panel1.Controls.Add(this.chbSupplier);
            this.panel1.Controls.Add(this.chbTypeProduct);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Location = new System.Drawing.Point(15, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 242);
            this.panel1.TabIndex = 35;
            // 
            // chbName
            // 
            this.chbName.AutoSize = true;
            this.chbName.Checked = true;
            this.chbName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbName.Location = new System.Drawing.Point(16, 58);
            this.chbName.Name = "chbName";
            this.chbName.Size = new System.Drawing.Size(164, 29);
            this.chbName.TabIndex = 16;
            this.chbName.Text = "Tên sản phẩm";
            this.chbName.UseVisualStyleBackColor = true;
            // 
            // chbPrice
            // 
            this.chbPrice.AutoSize = true;
            this.chbPrice.Checked = true;
            this.chbPrice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPrice.Location = new System.Drawing.Point(14, 96);
            this.chbPrice.Name = "chbPrice";
            this.chbPrice.Size = new System.Drawing.Size(135, 29);
            this.chbPrice.TabIndex = 17;
            this.chbPrice.Text = "Giá (nghìn)";
            this.chbPrice.UseVisualStyleBackColor = true;
            // 
            // chbSupplier
            // 
            this.chbSupplier.AutoSize = true;
            this.chbSupplier.Checked = true;
            this.chbSupplier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSupplier.Location = new System.Drawing.Point(14, 131);
            this.chbSupplier.Name = "chbSupplier";
            this.chbSupplier.Size = new System.Drawing.Size(153, 29);
            this.chbSupplier.TabIndex = 18;
            this.chbSupplier.Text = "Nhà sản xuất";
            this.chbSupplier.UseVisualStyleBackColor = true;
            // 
            // chbTypeProduct
            // 
            this.chbTypeProduct.AutoSize = true;
            this.chbTypeProduct.Checked = true;
            this.chbTypeProduct.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTypeProduct.Location = new System.Drawing.Point(14, 166);
            this.chbTypeProduct.Name = "chbTypeProduct";
            this.chbTypeProduct.Size = new System.Drawing.Size(166, 29);
            this.chbTypeProduct.TabIndex = 19;
            this.chbTypeProduct.Text = "Loại sản phẩm";
            this.chbTypeProduct.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(38, 203);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(155, 36);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Làm trống";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Mục lọc";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(105, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 25);
            this.label7.TabIndex = 34;
            this.label7.Text = "Thông số lọc";
            // 
            // UCImported
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UCImported";
            this.Size = new System.Drawing.Size(1350, 860);
            this.pnlMain.ResumeLayout(false);
            this.gbMakeBill.ResumeLayout(false);
            this.gbMakeBill.PerformLayout();
            this.gbListProduct.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDTo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox gbMakeBill;
        private System.Windows.Forms.Button btnMakeBills;
        private System.Windows.Forms.Button btnCancelBill;
        private System.Windows.Forms.GroupBox gbListProduct;
        private System.Windows.Forms.DateTimePicker dtPickDateCreate;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.TextBox txtBillID;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnMakeNewProduct;
        private System.Windows.Forms.Button btnCheckSupplier;
        private System.Windows.Forms.Button btnChooseProduct;
        private System.Windows.Forms.Button btnCheckHistory;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUDTo;
        private System.Windows.Forms.NumericUpDown numUDFrom;
        private System.Windows.Forms.ComboBox cbTypeProduct;
        private System.Windows.Forms.TextBox txtSupplierFilter;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.CheckBox chbTypeProduct;
        private System.Windows.Forms.CheckBox chbSupplier;
        private System.Windows.Forms.CheckBox chbPrice;
        private System.Windows.Forms.CheckBox chbName;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.FlowLayoutPanel flowpnl_Item;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
    }
}
