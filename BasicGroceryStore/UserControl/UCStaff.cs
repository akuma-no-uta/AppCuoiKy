using System;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
namespace BasicGroceryStore
{
    public partial class UCStaff : UserControl
    {
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private Font customFont;
        private BUS_Staff bus_staff;
        private BUS_Account bus_account;
        private BUS_Contract bus_contract;

        private bool flagSpells;
        private Staff _staff;

        static UCStaff _obj;
        public static UCStaff Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new UCStaff();
                }
                return _obj;
            }
        }

        public UCStaff()
        {
            InitializeComponent();
        
            bus_staff = new BUS_Staff();
            bus_account = new BUS_Account();
            bus_contract = new BUS_Contract();
            LoadContentCombobox();

            LoadData();
            _staff = new Staff();
        }

        private void LoadData()
        {
            ClearInformation();
            string fontPath = "C:/Users/LENOVO/BasicGroceryStore/BasicGroceryStore/Futura/SVN-Futura Book.ttf";
            pfc.AddFontFile(fontPath);

            if (pfc.Families.Length > 0)
                customFont = new Font(pfc.Families[0], 11F);
            else
                customFont = this.Font;

            this.Font = customFont;
            ApplyFont(this, customFont);
            dgvStaff.Controls.Clear();

            dgvStaff.DataSource = bus_staff.GetAllStaff();
            
            dgvStaff.Columns[0].Visible = false; //Hide ID column
        }

        private void ClearInformation()
        {
            picRepresent.Image = null;
            txtName.Clear();
            txtGender.Clear();
            txtCitizenID.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            ClearStaffSecretInformation();
        }

        private void ClearStaffSecretInformation()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            dgvContracts.Controls.Clear();
            dgvContracts.DataSource = null;
        }

        private void LoadContentCombobox()
        {
            cbTypeWork.DataSource = Enum.GetValues(typeof(TypeWork));
            cbSpells.DataSource = Enum.GetValues(typeof(Spells));
            cbDateContract.DataSource = Enum.GetValues(typeof(StatusOfContract));
        }

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

        #region Filter_Change
        private void chbTypeWork_CheckedChanged(object sender, EventArgs e)
        {
            cbTypeWork.Enabled = !cbTypeWork.Enabled;
        }

        private void chbSpells_CheckedChanged(object sender, EventArgs e)
        {
            cbSpells.Enabled = !cbSpells.Enabled;
        }

        private void chbDateContract_CheckedChanged(object sender, EventArgs e)
        {
            cbDateContract.Enabled = !cbDateContract.Enabled;
        }

        private void chbGender_CheckedChanged(object sender, EventArgs e)
        {
            cbGenderFilter.Enabled = !cbGenderFilter.Enabled;
        }

        private void chbAddress_CheckedChanged(object sender, EventArgs e)
        {
            txtAddressFilter.Enabled = !txtAddressFilter.Enabled;
        }

        private void chbAge_CheckedChanged(object sender, EventArgs e)
        {
            numUDFrom.Enabled = !numUDFrom.Enabled;
            numUDTo.Enabled = !numUDTo.Enabled;
        }

        private void chbName_CheckedChanged(object sender, EventArgs e)
        {
            txtNameFilter.Enabled = !txtNameFilter.Enabled;
        }
       
        private void cbTypeWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            flagSpells = true;
            if (cbTypeWork.SelectedItem.ToString() == TypeWork.fulltime.ToString())
            {
                flagSpells = false;
            }
            chbSpells.Checked = flagSpells;
            chbSpells.Enabled = flagSpells;
        }
        #endregion

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            new FormStaff(new Staff()).ShowDialog();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNameFilter.Clear();
            txtAddressFilter.Clear();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!chbName.Checked && !chbAge.Checked && !chbAddress.Checked && !chbGender.Checked &&
                !chbDateContract.Checked && !chbTypeWork.Checked && !chbSpells.Checked)
                return;

            DataTable table = null;
            DataTable table_filter;

            if (chbName.Checked)
            {
                table_filter = bus_staff.FindStaffByName(txtNameFilter.Text);
                table = getTableFilter(table, table_filter);
            }
            if (chbAge.Checked)
            {
                int from = (int)numUDFrom.Value;
                int to = (int)numUDTo.Value;
                if (from > to)
                {
                    MessageBox.Show("Giá trị bắt đầu phải lớn hơn hoặc bằng giá trị kết thúc!", "THÔNG BÁO");
                    return;
                }

                table_filter = bus_staff.FindStaffByAgeRange(from, to);
                table = getTableFilter(table, table_filter);
            }
            if (chbAddress.Checked)
            {
                table_filter = bus_staff.FindStaffByAddress(txtAddressFilter.Text);
                table = getTableFilter(table, table_filter);
            }
            if (chbGender.Checked)
            {
                table_filter = bus_staff.FindStaffByGender(cbGenderFilter.Text);
                table = getTableFilter(table, table_filter);
            }
            if (chbDateContract.Checked)
            {
                table_filter = bus_staff.FindStaffByContractStatus(cbDateContract.Text);
                table = getTableFilter(table, table_filter);
            }
            if (chbTypeWork.Checked)
            {
                table_filter = bus_staff.FindStaffByTypeWork(cbTypeWork.Text);
                table = getTableFilter(table, table_filter);
            }
            if (chbSpells.Checked)
            {
                table_filter = bus_staff.FindStaffBySpells(cbSpells.Text);
                table = getTableFilter(table, table_filter);
            }

            dgvStaff.Controls.Clear();
            dgvStaff.DataSource = table;
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            btnShowPassword.Text = (btnShowPassword.Text == "Hiện mật khẩu") ? "Ẩn mật khẩu" : "Hiện mật khẩu";
            txtPassword.PasswordChar = (txtPassword.PasswordChar == '*') ? '\0' : '*';
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // ❗ chưa chọn nhân viên
            if (_staff == null || string.IsNullOrEmpty(_staff.ID))
            {
                MessageBox.Show("Vui lòng chọn nhân viên!",
                    "THÔNG BÁO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // ❗ check quyền (chỉ admin hoặc chính mình)
            if (MainForm.current_role != 1 && _staff.ID != MainForm.staff_using.ID)
            {
                MessageBox.Show("Bạn không có quyền đổi mật khẩu!",
                    "CẢNH BÁO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            Account acc = bus_account.GetAccountByStaffID(_staff.ID);
            if (acc == null)
            {
                MessageBox.Show("Nhân viên chưa có tài khoản!",
                    "LỖI",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 🔥 gọi input tự tạo
            string newPassword = ShowInputPassword("ĐỔI MẬT KHẨU");

            // ❗ validate
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Mật khẩu không được để trống!",
                    "LỖI",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (newPassword.Length < 4)
            {
                MessageBox.Show("Mật khẩu phải >= 4 ký tự!",
                    "LỖI",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 🔥 update
            acc.Password = newPassword;

            if (bus_account.Update(acc))
            {
                MessageBox.Show("Đổi mật khẩu thành công!",
                    "THÔNG BÁO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtPassword.Text = newPassword;
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!",
                    "LỖI",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEditStaffInfor_Click(object sender, EventArgs e)
        {
            if (_staff.Name != "")
                new FormStaff(_staff).ShowDialog();
        }

        private void btnMakeContract_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Xóa thông tin nhân viên {_staff.Name}?", "CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (bus_staff.Delete(_staff))
                {
                    MessageBox.Show($"Xóa thông tin nhân viên {_staff.Name} thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                    _staff = new Staff();
                    LoadData();
                }
                else
                {
                    MessageBox.Show($"Xóa thông tin nhân viên {_staff.Name} không thành công!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearStaffSecretInformation();

            _staff = bus_staff.GetStaff(dgvStaff.CurrentRow.Cells[0].Value.ToString()); // Id cell

            txtName.Text = _staff.Name;
            txtGender.Text = _staff.Gender;
            dtPickDoB.Value = _staff.DateOfBirth;
            txtCitizenID.Text = _staff.CitizenID;
            txtAddress.Text = _staff.Address;
            txtEmail.Text = _staff.Email;
            txtPhone.Text = _staff.Phone;

            picRepresent.Image = _staff.Images;
        }

        private void btnLoadStaffInfor_Click(object sender, EventArgs e)
        {
            Account acc = bus_account.GetAccountByStaffID(_staff.ID);
            txtUsername.Text = acc.Username;
            txtPassword.Text = acc.Password;

            dgvContracts.DataSource = bus_contract.GetAllContractOfStaff(_staff.ID);
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

        private void cbDateContract_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numUDTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        private string ShowInputPassword(string title)
        {
            Form f = new Form();
            f.Width = 300;
            f.Height = 150;
            f.Text = title;
            f.StartPosition = FormStartPosition.CenterParent;
            f.FormBorderStyle = FormBorderStyle.FixedDialog;

            Label lbl = new Label() { Left = 10, Top = 10, Text = "Nhập mật khẩu mới:" };
            TextBox txt = new TextBox()
            {
                Left = 10,
                Top = 35,
                Width = 260,
                PasswordChar = '*'
            };

            Button btnOk = new Button() { Text = "OK", Left = 50, Width = 80, Top = 70 };
            Button btnCancel = new Button() { Text = "Hủy", Left = 150, Width = 80, Top = 70 };

            string result = "";

            btnOk.Click += (sender, e) =>
            {
                result = txt.Text;
                f.Close();
            };

            btnCancel.Click += (sender, e) =>
            {
                result = "";
                f.Close();
            };

            f.Controls.Add(lbl);
            f.Controls.Add(txt);
            f.Controls.Add(btnOk);
            f.Controls.Add(btnCancel);

            f.ShowDialog();

            return result;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
