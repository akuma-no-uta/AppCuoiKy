
namespace BasicGroceryStore
{
    partial class FormCustomer
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtPickDateJoin = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtCustomerValue = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.lblCustomerValue = new System.Windows.Forms.Label();
            this.lblCustomerDateJoin = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.pnlMove.SuspendLayout();
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
            this.pnlMove.TabIndex = 3;
            this.pnlMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMove_MouseDown);
            this.pnlMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMove_MouseMove);
            this.pnlMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlMove_MouseUp);
            // 
            // lblTabShow
            // 
            this.lblTabShow.AutoSize = true;
            this.lblTabShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabShow.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTabShow.Location = new System.Drawing.Point(18, 11);
            this.lblTabShow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTabShow.Name = "lblTabShow";
            this.lblTabShow.Size = new System.Drawing.Size(314, 33);
            this.lblTabShow.TabIndex = 4;
            this.lblTabShow.Text = "Thông tin khách hàng";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Image = global::BasicGroceryStore.Properties.Resources.subtract_26px;
            this.btnMinimize.Location = new System.Drawing.Point(645, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(87, 62);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.dtPickDateJoin);
            this.pnlMain.Controls.Add(this.txtPhone);
            this.pnlMain.Controls.Add(this.txtCustomerValue);
            this.pnlMain.Controls.Add(this.txtName);
            this.pnlMain.Controls.Add(this.lblCustomerPhone);
            this.pnlMain.Controls.Add(this.lblCustomerValue);
            this.pnlMain.Controls.Add(this.lblCustomerDateJoin);
            this.pnlMain.Controls.Add(this.lblCustomerName);
            this.pnlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 62);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(750, 369);
            this.pnlMain.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(513, 302);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(219, 51);
            this.btnCancel.TabIndex = 54;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(225, 302);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(279, 51);
            this.btnSave.TabIndex = 53;
            this.btnSave.Text = "Lưu thông tin";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtPickDateJoin
            // 
            this.dtPickDateJoin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickDateJoin.Location = new System.Drawing.Point(225, 91);
            this.dtPickDateJoin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtPickDateJoin.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtPickDateJoin.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dtPickDateJoin.Name = "dtPickDateJoin";
            this.dtPickDateJoin.Size = new System.Drawing.Size(277, 35);
            this.dtPickDateJoin.TabIndex = 52;
            this.dtPickDateJoin.Value = new System.DateTime(2022, 8, 2, 0, 0, 0, 0);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(225, 158);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhone.Mask = "0000-000-000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(278, 35);
            this.txtPhone.TabIndex = 51;
            // 
            // txtCustomerValue
            // 
            this.txtCustomerValue.Location = new System.Drawing.Point(225, 226);
            this.txtCustomerValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCustomerValue.Name = "txtCustomerValue";
            this.txtCustomerValue.ReadOnly = false;
            this.txtCustomerValue.Size = new System.Drawing.Size(505, 35);
            this.txtCustomerValue.TabIndex = 50;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(225, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = false;
            this.txtName.Size = new System.Drawing.Size(505, 35);
            this.txtName.TabIndex = 49;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Location = new System.Drawing.Point(32, 165);
            this.lblCustomerPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(121, 29);
            this.lblCustomerPhone.TabIndex = 48;
            this.lblCustomerPhone.Text = "Điện thoại";
            // 
            // lblCustomerValue
            // 
            this.lblCustomerValue.AutoSize = true;
            this.lblCustomerValue.Location = new System.Drawing.Point(32, 231);
            this.lblCustomerValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerValue.Name = "lblCustomerValue";
            this.lblCustomerValue.Size = new System.Drawing.Size(155, 29);
            this.lblCustomerValue.TabIndex = 47;
            this.lblCustomerValue.Text = "Giá trị tích lũy";
            // 
            // lblCustomerDateJoin
            // 
            this.lblCustomerDateJoin.AutoSize = true;
            this.lblCustomerDateJoin.Location = new System.Drawing.Point(32, 98);
            this.lblCustomerDateJoin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerDateJoin.Name = "lblCustomerDateJoin";
            this.lblCustomerDateJoin.Size = new System.Drawing.Size(166, 29);
            this.lblCustomerDateJoin.TabIndex = 46;
            this.lblCustomerDateJoin.Text = "Ngày tham gia";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(32, 32);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(83, 29);
            this.lblCustomerName.TabIndex = 45;
            this.lblCustomerName.Text = "Họ tên";
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 431);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlMove);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormCustomer";
            this.Text = "FormCustomer";
            this.pnlMove.ResumeLayout(false);
            this.pnlMove.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMove;
        private System.Windows.Forms.Label lblTabShow;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DateTimePicker dtPickDateJoin;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.TextBox txtCustomerValue;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblCustomerValue;
        private System.Windows.Forms.Label lblCustomerDateJoin;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}