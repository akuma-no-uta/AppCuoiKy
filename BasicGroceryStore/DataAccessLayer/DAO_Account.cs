using System;
using System.Data;
using System.Data.SqlClient;

namespace BasicGroceryStore
{
    internal class DAO_Account : IControl<Account>, IAccountServices
    {
        // ================= CREATE =================
        public bool Create(Account acc)
        {
            return DataProvider.Instance.ExecuteNonQuery(
                "sp_InsertAccount",
                CommandType.StoredProcedure,
                new SqlParameter("@StaffID", acc.Staff_id),
                new SqlParameter("@Username", acc.Username),
                new SqlParameter("@Password", acc.Password),
                new SqlParameter("@Role", acc.Role) // 🔥 THÊM ROLE
            ) > 0;
        }

        // ================= UPDATE =================
        public bool Update(Account acc)
        {
            return DataProvider.Instance.ExecuteNonQuery(
                "sp_UpdateAccount",
                CommandType.StoredProcedure,
                new SqlParameter("@StaffID", acc.Staff_id),
                new SqlParameter("@Username", acc.Username),
                new SqlParameter("@Password", acc.Password),
                new SqlParameter("@Role", acc.Role) // 🔥 THÊM ROLE
            ) > 0;
        }

        // ================= DELETE =================
        public bool Delete(Account acc)
        {
            return DataProvider.Instance.ExecuteNonQuery(
                "sp_DeleteAccount",
                CommandType.StoredProcedure,
                new SqlParameter("@StaffID", acc.Staff_id)
            ) > 0;
        }

        // ================= LOGIN (CŨ - KHÔNG KHUYẾN KHÍCH) =================
        public string CheckLogin(string username, string password)
        {
            object result = DataProvider.Instance.ExecuteScalar(
                "SELECT StaffID FROM Account WHERE Username = @Username AND Password = @Password",
                CommandType.Text,
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            );

            return result?.ToString() ?? "";
        }

        // ================= LOGIN + ROLE (QUAN TRỌNG) =================
        public Account CheckLoginWithRole(string username, string password)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery(
                "SELECT StaffID, Role FROM Account WHERE Username = @Username AND Password = @Password",
                CommandType.Text,
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            );

            if (dt.Rows.Count > 0)
            {
                string staffId = dt.Rows[0]["StaffID"].ToString();

                int role = dt.Rows[0]["Role"] == DBNull.Value
                    ? 0
                    : System.Convert.ToInt32(dt.Rows[0]["Role"]);

                return new Account(staffId, username, password, role);
            }

            return null;
        }

        // ================= GET ACCOUNT =================
        public Account GetAccountByStaffID(string staff_id)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM Account WHERE StaffID = @StaffID",
                CommandType.Text,
                new SqlParameter("@StaffID", staff_id)
            );

            if (dt.Rows.Count > 0)
            {
                string username = dt.Rows[0]["Username"].ToString();
                string password = dt.Rows[0]["Password"].ToString();

                int role = dt.Rows[0]["Role"] == DBNull.Value
                    ? 0
                    : System.Convert.ToInt32(dt.Rows[0]["Role"]);

                return new Account(staff_id, username, password, role);
            }

            return null;
        }

        // ================= SAVE ACCOUNT =================
        public void SaveAccount(Account acc, bool isSave)
        {
            DAO_Information dao = new DAO_Information("Account.xml");
            dao.UpdateSaveAccount(acc, isSave);
        }
    }
}