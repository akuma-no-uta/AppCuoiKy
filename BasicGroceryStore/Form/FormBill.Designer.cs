namespace BasicGroceryStore
{
    partial class FormBill
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMove = new System.Windows.Forms.Panel();
            this.lblTabShow = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnDeleteBill = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvBillDetails = new System.Windows.Forms.DataGridView();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.lblBillID = new System.Windows.Forms.Label();
            this.lblDateCreate = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtBillID = new System.Windows.Forms.TextBox();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.txtDateCreate = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMove
            // 
            this.pnlMove.BackColor = System.Drawing.Color.OrangeRed;
            this.pnlMove.Controls.Add(this.lblTabShow);
            this.pnlMove.Controls.Add(this.btnMinimize);
            this.pnlMove.Location = new System.Drawing.Point(0, 0);
            this.pnlMove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMove.Name = "pnlMove";
            this.pnlMove.Size = new System.Drawing.Size(750, 62);
            this.pnlMove.TabIndex = 5;
            this.pnlMove.Tag = "";
            this.pnlMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMove_MouseDown);
            this.pnlMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMove_MouseMove);
            this.pnlMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMove_MouseUp);
            // 
            // lblTabShow
            // 
            this.lblTabShow.AutoSize = true;
            this.lblTabShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabShow.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTabShow.Location = new System.Drawing.Point(27, 14);
            this.lblTabShow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTabShow.Name = "lblTabShow";
            this.lblTabShow.Size = new System.Drawing.Size(282, 33);
            this.lblTabShow.TabIndex = 4;
            this.lblTabShow.Text = "Thông tin đơn hàng";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Image = global::BasicGroceryStore.Properties.Resources.subtract_26px;
            this.btnMinimize.Location = new System.Drawing.Point(638, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(94, 62);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnDeleteBill
            // 
            this.btnDeleteBill.Location = new System.Drawing.Point(18, 795);
            this.btnDeleteBill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteBill.Name = "btnDeleteBill";
            this.btnDeleteBill.Size = new System.Drawing.Size(350, 48);
            this.btnDeleteBill.TabIndex = 0;
            this.btnDeleteBill.Text = "Xóa đơn hàng";
            this.btnDeleteBill.UseVisualStyleBackColor = true;
            this.btnDeleteBill.Click += new System.EventHandler(this.btnDeleteBill_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(382, 795);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(350, 48);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvBillDetails
            // 
            this.dgvBillDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillDetails.Location = new System.Drawing.Point(18, 255);
            this.dgvBillDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvBillDetails.Name = "dgvBillDetails";
            this.dgvBillDetails.ReadOnly = true;
            this.dgvBillDetails.RowHeadersWidth = 62;
            this.dgvBillDetails.Size = new System.Drawing.Size(714, 531);
            this.dgvBillDetails.TabIndex = 2;
            // 
            // lblStaffName
            // 
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.Location = new System.Drawing.Point(27, 14);
            this.lblStaffName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(120, 29);
            this.lblStaffName.TabIndex = 37;
            this.lblStaffName.Text = "Nhân viên";
            // 
            // lblBillID
            // 
            this.lblBillID.AutoSize = true;
            this.lblBillID.Location = new System.Drawing.Point(27, 63);
            this.lblBillID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBillID.Name = "lblBillID";
            this.lblBillID.Size = new System.Drawing.Size(139, 29);
            this.lblBillID.TabIndex = 38;
            this.lblBillID.Text = "Mã hóa đơn";
            // 
            // lblDateCreate
            // 
            this.lblDateCreate.AutoSize = true;
            this.lblDateCreate.Location = new System.Drawing.Point(27, 112);
            this.lblDateCreate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateCreate.Name = "lblDateCreate";
            this.lblDateCreate.Size = new System.Drawing.Size(108, 29);
            this.lblDateCreate.TabIndex = 39;
            this.lblDateCreate.Text = "Ngày tạo";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(27, 162);
            this.lblTotalPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(115, 29);
            this.lblTotalPrice.TabIndex = 40;
            this.lblTotalPrice.Text = "Tổng tiền";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(284, 157);
            this.txtTotalPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(446, 35);
            this.txtTotalPrice.TabIndex = 41;
            // 
            // txtBillID
            // 
            this.txtBillID.Location = new System.Drawing.Point(284, 58);
            this.txtBillID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillID.Name = "txtBillID";
            this.txtBillID.ReadOnly = true;
            this.txtBillID.Size = new System.Drawing.Size(446, 35);
            this.txtBillID.TabIndex = 42;
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(284, 9);
            this.txtStaffName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(446, 35);
            this.txtStaffName.TabIndex = 43;
            // 
            // txtDateCreate
            // 
            this.txtDateCreate.Location = new System.Drawing.Point(284, 108);
            this.txtDateCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDateCreate.Name = "txtDateCreate";
            this.txtDateCreate.ReadOnly = true;
            this.txtDateCreate.Size = new System.Drawing.Size(446, 35);
            this.txtDateCreate.TabIndex = 44;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(284, 206);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(446, 35);
            this.txtCustomerName.TabIndex = 45;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(27, 211);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(184, 29);
            this.lblCustomerName.TabIndex = 46;
            this.lblCustomerName.Text = "Tên khách hàng";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlMain.Controls.Add(this.lblCustomerName);
            this.pnlMain.Controls.Add(this.txtCustomerName);
            this.pnlMain.Controls.Add(this.txtDateCreate);
            this.pnlMain.Controls.Add(this.txtStaffName);
            this.pnlMain.Controls.Add(this.txtBillID);
            this.pnlMain.Controls.Add(this.txtTotalPrice);
            this.pnlMain.Controls.Add(this.lblTotalPrice);
            this.pnlMain.Controls.Add(this.lblDateCreate);
            this.pnlMain.Controls.Add(this.lblBillID);
            this.pnlMain.Controls.Add(this.lblStaffName);
            this.pnlMain.Controls.Add(this.dgvBillDetails);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.btnDeleteBill);
            this.pnlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 62);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(750, 862);
            this.pnlMain.TabIndex = 6;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // FormBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 923);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBill";
            this.Text = "FormBill";
            this.pnlMove.ResumeLayout(false);
            this.pnlMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillDetails)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMove;
        private System.Windows.Forms.Label lblTabShow;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnDeleteBill;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvBillDetails;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label lblBillID;
        private System.Windows.Forms.Label lblDateCreate;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.TextBox txtBillID;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.TextBox txtDateCreate;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Panel pnlMain;
    }
}