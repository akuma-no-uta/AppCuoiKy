
namespace BasicGroceryStore
{
    partial class UCStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCStaff));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbDateContract = new System.Windows.Forms.ComboBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.txtGender = new System.Windows.Forms.TextBox();
            this.gbContractsAndAccount = new System.Windows.Forms.GroupBox();
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.btnMakeContract = new System.Windows.Forms.Button();
            this.btnLoadStaffInfor = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnEditStaffInfor = new System.Windows.Forms.Button();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.dtPickDoB = new System.Windows.Forms.DateTimePicker();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtCitizenID = new System.Windows.Forms.MaskedTextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picRepresent = new System.Windows.Forms.PictureBox();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numUDTo = new System.Windows.Forms.NumericUpDown();
            this.numUDFrom = new System.Windows.Forms.NumericUpDown();
            this.cbTypeWork = new System.Windows.Forms.ComboBox();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.txtAddressFilter = new System.Windows.Forms.TextBox();
            this.cbGenderFilter = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chbName = new System.Windows.Forms.CheckBox();
            this.chbAge = new System.Windows.Forms.CheckBox();
            this.chbAddress = new System.Windows.Forms.CheckBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.chbGender = new System.Windows.Forms.CheckBox();
            this.chbDateContract = new System.Windows.Forms.CheckBox();
            this.chbTypeWork = new System.Windows.Forms.CheckBox();
            this.chbSpells = new System.Windows.Forms.CheckBox();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbSpells = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlMain.SuspendLayout();
            this.gbDetail.SuspendLayout();
            this.gbContractsAndAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRepresent)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDFrom)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbDateContract
            // 
            this.cbDateContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDateContract.FormattingEnabled = true;
            this.cbDateContract.Location = new System.Drawing.Point(22, 191);
            this.cbDateContract.Name = "cbDateContract";
            this.cbDateContract.Size = new System.Drawing.Size(297, 33);
            this.cbDateContract.TabIndex = 16;
            this.toolTip.SetToolTip(this.cbDateContract, "Unexpired: Còn hạn\r\nExpiration soon: Sắp hết hạn\r\nExpired: Hết hạn\r\n");
            this.cbDateContract.SelectedIndexChanged += new System.EventHandler(this.cbDateContract_SelectedIndexChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Peru;
            this.pnlMain.Controls.Add(this.gbDetail);
            this.pnlMain.Controls.Add(this.gbFilter);
            this.pnlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1350, 860);
            this.pnlMain.TabIndex = 1;
            // 
            // gbDetail
            // 
            this.gbDetail.BackColor = System.Drawing.Color.LightSalmon;
            this.gbDetail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gbDetail.BackgroundImage")));
            this.gbDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbDetail.Controls.Add(this.groupBox2);
            this.gbDetail.Controls.Add(this.txtGender);
            this.gbDetail.Controls.Add(this.gbContractsAndAccount);
            this.gbDetail.Controls.Add(this.dtPickDoB);
            this.gbDetail.Controls.Add(this.txtPhone);
            this.gbDetail.Controls.Add(this.txtCitizenID);
            this.gbDetail.Controls.Add(this.txtEmail);
            this.gbDetail.Controls.Add(this.txtAddress);
            this.gbDetail.Controls.Add(this.txtName);
            this.gbDetail.Controls.Add(this.label8);
            this.gbDetail.Controls.Add(this.label5);
            this.gbDetail.Controls.Add(this.label7);
            this.gbDetail.Controls.Add(this.label4);
            this.gbDetail.Controls.Add(this.label3);
            this.gbDetail.Controls.Add(this.label2);
            this.gbDetail.Controls.Add(this.picRepresent);
            this.gbDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetail.Location = new System.Drawing.Point(645, 3);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(702, 857);
            this.gbDetail.TabIndex = 1;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Thông tin nhân viên và hợp đồng";
            // 
            // txtGender
            // 
            this.txtGender.Location = new System.Drawing.Point(297, 79);
            this.txtGender.Name = "txtGender";
            this.txtGender.ReadOnly = true;
            this.txtGender.Size = new System.Drawing.Size(263, 30);
            this.txtGender.TabIndex = 33;
            // 
            // gbContractsAndAccount
            // 
            this.gbContractsAndAccount.BackColor = System.Drawing.Color.White;
            this.gbContractsAndAccount.Controls.Add(this.dgvContracts);
            this.gbContractsAndAccount.Controls.Add(this.btnMakeContract);
            this.gbContractsAndAccount.Controls.Add(this.label11);
            this.gbContractsAndAccount.Controls.Add(this.btnEditStaffInfor);
            this.gbContractsAndAccount.Location = new System.Drawing.Point(9, 423);
            this.gbContractsAndAccount.Name = "gbContractsAndAccount";
            this.gbContractsAndAccount.Size = new System.Drawing.Size(561, 348);
            this.gbContractsAndAccount.TabIndex = 30;
            this.gbContractsAndAccount.TabStop = false;
            this.gbContractsAndAccount.Text = "Thông tin hợp đồng";
            // 
            // dgvContracts
            // 
            this.dgvContracts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContracts.Location = new System.Drawing.Point(6, 58);
            this.dgvContracts.Name = "dgvContracts";
            this.dgvContracts.RowHeadersWidth = 62;
            this.dgvContracts.Size = new System.Drawing.Size(545, 234);
            this.dgvContracts.TabIndex = 37;
            // 
            // btnMakeContract
            // 
            this.btnMakeContract.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnMakeContract.ForeColor = System.Drawing.Color.White;
            this.btnMakeContract.Location = new System.Drawing.Point(385, 306);
            this.btnMakeContract.Name = "btnMakeContract";
            this.btnMakeContract.Size = new System.Drawing.Size(170, 36);
            this.btnMakeContract.TabIndex = 24;
            this.btnMakeContract.Text = "Tạo hợp đồng";
            this.btnMakeContract.UseVisualStyleBackColor = false;
            this.btnMakeContract.Click += new System.EventHandler(this.btnMakeContract_Click);
            // 
            // btnLoadStaffInfor
            // 
            this.btnLoadStaffInfor.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLoadStaffInfor.ForeColor = System.Drawing.Color.White;
            this.btnLoadStaffInfor.Location = new System.Drawing.Point(3, 92);
            this.btnLoadStaffInfor.Name = "btnLoadStaffInfor";
            this.btnLoadStaffInfor.Size = new System.Drawing.Size(162, 36);
            this.btnLoadStaffInfor.TabIndex = 32;
            this.btnLoadStaffInfor.Text = "Tải thông tin";
            this.btnLoadStaffInfor.UseVisualStyleBackColor = false;
            this.btnLoadStaffInfor.Click += new System.EventHandler(this.btnLoadStaffInfor_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(404, 29);
            this.label11.TabIndex = 36;
            this.label11.Text = "Danh sách hợp đồng với cửa hàng";
            // 
            // btnEditStaffInfor
            // 
            this.btnEditStaffInfor.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnEditStaffInfor.ForeColor = System.Drawing.Color.White;
            this.btnEditStaffInfor.Location = new System.Drawing.Point(0, 306);
            this.btnEditStaffInfor.Name = "btnEditStaffInfor";
            this.btnEditStaffInfor.Size = new System.Drawing.Size(178, 36);
            this.btnEditStaffInfor.TabIndex = 31;
            this.btnEditStaffInfor.Text = "Sửa thông tin";
            this.btnEditStaffInfor.UseVisualStyleBackColor = false;
            this.btnEditStaffInfor.Click += new System.EventHandler(this.btnEditStaffInfor_Click);
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnShowPassword.ForeColor = System.Drawing.Color.White;
            this.btnShowPassword.Location = new System.Drawing.Point(179, 94);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(164, 35);
            this.btnShowPassword.TabIndex = 35;
            this.btnShowPassword.Text = "Hiện mật khẩu";
            this.btnShowPassword.UseVisualStyleBackColor = false;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(366, 94);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(164, 33);
            this.btnChangePassword.TabIndex = 32;
            this.btnChangePassword.Text = "Đổi mật khẩu";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 25);
            this.label10.TabIndex = 34;
            this.label10.Text = "Mật khẩu";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 25);
            this.label9.TabIndex = 32;
            this.label9.Text = "Tài khoản";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(136, 59);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(394, 30);
            this.txtPassword.TabIndex = 33;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(136, 18);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(394, 30);
            this.txtUsername.TabIndex = 32;
            // 
            // dtPickDoB
            // 
            this.dtPickDoB.Enabled = false;
            this.dtPickDoB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickDoB.Location = new System.Drawing.Point(297, 119);
            this.dtPickDoB.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dtPickDoB.MinDate = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            this.dtPickDoB.Name = "dtPickDoB";
            this.dtPickDoB.Size = new System.Drawing.Size(263, 30);
            this.dtPickDoB.TabIndex = 29;
            this.dtPickDoB.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(297, 197);
            this.txtPhone.Mask = "0000-000-000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(263, 30);
            this.txtPhone.TabIndex = 28;
            // 
            // txtCitizenID
            // 
            this.txtCitizenID.Location = new System.Drawing.Point(297, 161);
            this.txtCitizenID.Mask = "000000000000";
            this.txtCitizenID.Name = "txtCitizenID";
            this.txtCitizenID.ReadOnly = true;
            this.txtCitizenID.Size = new System.Drawing.Size(263, 30);
            this.txtCitizenID.TabIndex = 27;
            this.txtCitizenID.ValidatingType = typeof(int);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(297, 235);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(263, 30);
            this.txtEmail.TabIndex = 26;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(695, -3);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(10, 30);
            this.txtAddress.TabIndex = 25;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(297, 37);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(263, 30);
            this.txtName.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(183, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(180, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Điện thoại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(180, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "CCCD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(180, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(180, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giới";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(180, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên";
            // 
            // picRepresent
            // 
            this.picRepresent.BackColor = System.Drawing.Color.Linen;
            this.picRepresent.Location = new System.Drawing.Point(6, 41);
            this.picRepresent.Name = "picRepresent";
            this.picRepresent.Size = new System.Drawing.Size(168, 224);
            this.picRepresent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRepresent.TabIndex = 0;
            this.picRepresent.TabStop = false;
            // 
            // gbFilter
            // 
            this.gbFilter.BackColor = System.Drawing.Color.LightSalmon;
            this.gbFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gbFilter.BackgroundImage")));
            this.gbFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbFilter.Controls.Add(this.groupBox1);
            this.gbFilter.Controls.Add(this.panel2);
            this.gbFilter.Controls.Add(this.panel1);
            this.gbFilter.Controls.Add(this.cbSpells);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(645, 863);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Lọc thông tin";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.numUDTo);
            this.panel2.Controls.Add(this.numUDFrom);
            this.panel2.Controls.Add(this.cbDateContract);
            this.panel2.Controls.Add(this.cbTypeWork);
            this.panel2.Controls.Add(this.txtNameFilter);
            this.panel2.Controls.Add(this.txtAddressFilter);
            this.panel2.Controls.Add(this.cbGenderFilter);
            this.panel2.Location = new System.Drawing.Point(267, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 310);
            this.panel2.TabIndex = 25;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(14, 267);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 36);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Làm trống";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(181, 268);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(138, 36);
            this.btnFind.TabIndex = 18;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "đến";
            // 
            // numUDTo
            // 
            this.numUDTo.Location = new System.Drawing.Point(233, 82);
            this.numUDTo.Maximum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numUDTo.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numUDTo.Name = "numUDTo";
            this.numUDTo.Size = new System.Drawing.Size(86, 30);
            this.numUDTo.TabIndex = 14;
            this.numUDTo.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numUDTo.ValueChanged += new System.EventHandler(this.numUDTo_ValueChanged);
            // 
            // numUDFrom
            // 
            this.numUDFrom.Location = new System.Drawing.Point(22, 81);
            this.numUDFrom.Maximum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numUDFrom.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numUDFrom.Name = "numUDFrom";
            this.numUDFrom.Size = new System.Drawing.Size(107, 30);
            this.numUDFrom.TabIndex = 13;
            this.numUDFrom.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // cbTypeWork
            // 
            this.cbTypeWork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeWork.FormattingEnabled = true;
            this.cbTypeWork.Location = new System.Drawing.Point(22, 230);
            this.cbTypeWork.Name = "cbTypeWork";
            this.cbTypeWork.Size = new System.Drawing.Size(297, 33);
            this.cbTypeWork.TabIndex = 11;
            this.cbTypeWork.SelectedIndexChanged += new System.EventHandler(this.cbTypeWork_SelectedIndexChanged);
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Location = new System.Drawing.Point(22, 46);
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(297, 30);
            this.txtNameFilter.TabIndex = 8;
            // 
            // txtAddressFilter
            // 
            this.txtAddressFilter.Location = new System.Drawing.Point(22, 116);
            this.txtAddressFilter.Name = "txtAddressFilter";
            this.txtAddressFilter.Size = new System.Drawing.Size(297, 30);
            this.txtAddressFilter.TabIndex = 9;
            // 
            // cbGenderFilter
            // 
            this.cbGenderFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGenderFilter.FormattingEnabled = true;
            this.cbGenderFilter.Items.AddRange(new object[] {
            "nam",
            "nữ",
            "khác"});
            this.cbGenderFilter.Location = new System.Drawing.Point(22, 152);
            this.cbGenderFilter.Name = "cbGenderFilter";
            this.cbGenderFilter.Size = new System.Drawing.Size(297, 33);
            this.cbGenderFilter.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.chbName);
            this.panel1.Controls.Add(this.chbAge);
            this.panel1.Controls.Add(this.chbAddress);
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.chbGender);
            this.panel1.Controls.Add(this.chbDateContract);
            this.panel1.Controls.Add(this.chbTypeWork);
            this.panel1.Controls.Add(this.chbSpells);
            this.panel1.Location = new System.Drawing.Point(12, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 309);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chbName
            // 
            this.chbName.AutoSize = true;
            this.chbName.Checked = true;
            this.chbName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbName.Location = new System.Drawing.Point(3, 53);
            this.chbName.Name = "chbName";
            this.chbName.Size = new System.Drawing.Size(163, 29);
            this.chbName.TabIndex = 0;
            this.chbName.Text = "Tên nhân viên";
            this.chbName.UseVisualStyleBackColor = true;
            this.chbName.CheckedChanged += new System.EventHandler(this.chbName_CheckedChanged);
            // 
            // chbAge
            // 
            this.chbAge.AutoSize = true;
            this.chbAge.Checked = true;
            this.chbAge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAge.Location = new System.Drawing.Point(3, 88);
            this.chbAge.Name = "chbAge";
            this.chbAge.Size = new System.Drawing.Size(99, 29);
            this.chbAge.TabIndex = 1;
            this.chbAge.Text = "Độ tuổi";
            this.chbAge.UseVisualStyleBackColor = true;
            this.chbAge.CheckedChanged += new System.EventHandler(this.chbAge_CheckedChanged);
            // 
            // chbAddress
            // 
            this.chbAddress.AutoSize = true;
            this.chbAddress.Checked = true;
            this.chbAddress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAddress.Location = new System.Drawing.Point(3, 123);
            this.chbAddress.Name = "chbAddress";
            this.chbAddress.Size = new System.Drawing.Size(97, 29);
            this.chbAddress.TabIndex = 2;
            this.chbAddress.Text = "Địa chỉ";
            this.chbAddress.UseVisualStyleBackColor = true;
            this.chbAddress.CheckedChanged += new System.EventHandler(this.chbAddress_CheckedChanged);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(22, 262);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(174, 37);
            this.btnReload.TabIndex = 20;
            this.btnReload.Text = "Tải lại";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // chbGender
            // 
            this.chbGender.AutoSize = true;
            this.chbGender.Checked = true;
            this.chbGender.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbGender.Location = new System.Drawing.Point(3, 147);
            this.chbGender.Name = "chbGender";
            this.chbGender.Size = new System.Drawing.Size(108, 29);
            this.chbGender.TabIndex = 3;
            this.chbGender.Text = "Giới tính";
            this.chbGender.UseVisualStyleBackColor = true;
            this.chbGender.CheckedChanged += new System.EventHandler(this.chbGender_CheckedChanged);
            // 
            // chbDateContract
            // 
            this.chbDateContract.AutoSize = true;
            this.chbDateContract.Checked = true;
            this.chbDateContract.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDateContract.Location = new System.Drawing.Point(5, 188);
            this.chbDateContract.Name = "chbDateContract";
            this.chbDateContract.Size = new System.Drawing.Size(161, 29);
            this.chbDateContract.TabIndex = 4;
            this.chbDateContract.Text = "Hạn hợp đồng";
            this.chbDateContract.UseVisualStyleBackColor = true;
            this.chbDateContract.CheckedChanged += new System.EventHandler(this.chbDateContract_CheckedChanged);
            // 
            // chbTypeWork
            // 
            this.chbTypeWork.AutoSize = true;
            this.chbTypeWork.Checked = true;
            this.chbTypeWork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTypeWork.Location = new System.Drawing.Point(3, 230);
            this.chbTypeWork.Name = "chbTypeWork";
            this.chbTypeWork.Size = new System.Drawing.Size(173, 29);
            this.chbTypeWork.TabIndex = 5;
            this.chbTypeWork.Text = "Dạng công việc";
            this.chbTypeWork.UseVisualStyleBackColor = true;
            this.chbTypeWork.CheckedChanged += new System.EventHandler(this.chbTypeWork_CheckedChanged);
            // 
            // chbSpells
            // 
            this.chbSpells.AutoSize = true;
            this.chbSpells.Checked = true;
            this.chbSpells.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSpells.Location = new System.Drawing.Point(40, 267);
            this.chbSpells.Name = "chbSpells";
            this.chbSpells.Size = new System.Drawing.Size(153, 29);
            this.chbSpells.TabIndex = 7;
            this.chbSpells.Text = "Buổi làm việc";
            this.chbSpells.UseVisualStyleBackColor = true;
            this.chbSpells.CheckedChanged += new System.EventHandler(this.chbSpells_CheckedChanged);
            // 
            // dgvStaff
            // 
            this.dgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Location = new System.Drawing.Point(6, 29);
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.RowHeadersWidth = 62;
            this.dgvStaff.Size = new System.Drawing.Size(608, 331);
            this.dgvStaff.TabIndex = 23;
            this.dgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(5, 374);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(183, 36);
            this.btnAddNew.TabIndex = 21;
            this.btnAddNew.Text = "Thêm mới";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(437, 374);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(183, 36);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Xóa thông tin";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbSpells
            // 
            this.cbSpells.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpells.FormattingEnabled = true;
            this.cbSpells.Location = new System.Drawing.Point(675, 284);
            this.cbSpells.Name = "cbSpells";
            this.cbSpells.Size = new System.Drawing.Size(10, 33);
            this.cbSpells.TabIndex = 12;
            this.cbSpells.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvStaff);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAddNew);
            this.groupBox1.Location = new System.Drawing.Point(6, 355);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 416);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đanh sách nhân viên";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(64, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 25);
            this.label12.TabIndex = 21;
            this.label12.Text = "Bộ lọc";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(131, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 25);
            this.label13.TabIndex = 22;
            this.label13.Text = "Thông số lọc";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnLoadStaffInfor);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.btnShowPassword);
            this.groupBox2.Controls.Add(this.btnChangePassword);
            this.groupBox2.Location = new System.Drawing.Point(9, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 133);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tài khoản";
            // 
            // UCStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "UCStaff";
            this.Size = new System.Drawing.Size(1350, 860);
            this.pnlMain.ResumeLayout(false);
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.gbContractsAndAccount.ResumeLayout(false);
            this.gbContractsAndAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRepresent)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDFrom)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cbDateContract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUDTo;
        private System.Windows.Forms.NumericUpDown numUDFrom;
        private System.Windows.Forms.ComboBox cbSpells;
        private System.Windows.Forms.ComboBox cbTypeWork;
        private System.Windows.Forms.ComboBox cbGenderFilter;
        private System.Windows.Forms.TextBox txtAddressFilter;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.CheckBox chbSpells;
        private System.Windows.Forms.CheckBox chbTypeWork;
        private System.Windows.Forms.CheckBox chbDateContract;
        private System.Windows.Forms.CheckBox chbGender;
        private System.Windows.Forms.CheckBox chbAddress;
        private System.Windows.Forms.CheckBox chbAge;
        private System.Windows.Forms.CheckBox chbName;
        private System.Windows.Forms.PictureBox picRepresent;
        private System.Windows.Forms.DateTimePicker dtPickDoB;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.MaskedTextBox txtCitizenID;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEditStaffInfor;
        private System.Windows.Forms.Button btnMakeContract;
        private System.Windows.Forms.GroupBox gbContractsAndAccount;
        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnLoadStaffInfor;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
