using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace BasicGroceryStore
{
    internal class DAO_Bill : IBillServices
    {
        private string typeBill;
        public DAO_Bill(string typeBill)
        {
            this.typeBill = typeBill;
        }
        public bool CheckCustomerExists(string name, string phone)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery(
                "SELECT * FROM CustomerMember WHERE Name = @Name AND Phone = @Phone",
                CommandType.Text,
                new SqlParameter("@Name", name),
                new SqlParameter("@Phone", phone)
            );

            return dt.Rows.Count > 0;
        }
        public bool Create(Bill bill, string customerName)
        {
            List<SqlParameter> param = new List<SqlParameter>() {
                new SqlParameter("@ID", bill.ID),
                new SqlParameter("@DateCreate", bill.DateCreate),
                new SqlParameter("@Value", bill.Value),
                new SqlParameter("@StaffID", bill.StaffID) };
        
            if (typeBill == "Ordered") // for Ordered
            {
                param.Add(new SqlParameter("@CustomerName", customerName));
            }

            return (DataProvider.Instance.ExecuteNonQuery($"sp_Insert{typeBill}", CommandType.StoredProcedure, param.ToArray()) > 0) ? true : false;
        }

        public bool Update(Bill bill, string customerName)
        {
            SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@ID", bill.ID),
                    new SqlParameter("@DateCreate", bill.DateCreate),
                    new SqlParameter("@Value", bill.Value),
                    new SqlParameter("@StaffID", bill.StaffID) };

            if (typeBill == "Ordered") // for Ordered
            {
                param[param.Length] = new SqlParameter("@CustomerName", customerName);
            }

            return (DataProvider.Instance.ExecuteNonQuery($"sp_Update{typeBill}", CommandType.StoredProcedure, param) > 0) ? true : false;
        }

        public bool Delete(Bill bill)
        {
            return (DataProvider.Instance.ExecuteNonQuery($"exec sp_Delete{typeBill}", CommandType.StoredProcedure, 
                new SqlParameter("@ID", bill.ID)) > 0) ? true : false;
        }

        public DataTable GetAllBill()
        {
            return DataProvider.Instance.ExecuteQuery($"select * from {typeBill}", CommandType.Text, null);
        }

        public int GetQuantityOfBill()
        {
            return (int)DataProvider.Instance.ExecuteScalar($"select dbo.func_NumberOf{typeBill}()", CommandType.Text);
        }

        public float GetValueOfBill(string bill_id)
        {
            return (float)DataProvider.Instance.ExecuteScalar($"select value from {typeBill} where Id={bill_id}", CommandType.Text);
        }

        public DataTable GetAllItemInBill(string bill_id)
        {
            return DataProvider.Instance.ExecuteQuery("sp_GetAllItemInBill", CommandType.StoredProcedure, 
                new SqlParameter("@TypeBill", typeBill),
                new SqlParameter("@ID", bill_id));
        }

        public double? GetValueOfAllBills()
        {
            string query = $"select sum(x.value) from {typeBill} x";
            return (double?)DataProvider.Instance.ExecuteScalar(query, CommandType.Text, null);
        }

        public double? GetValueOfAllBills_Day(DateTime date)
        {
            if(typeBill == "Imported")
            {
                object value = DataProvider.Instance.ExecuteScalar($"select dbo.func_TotalBuyOfDay('{GetFormatString.GetDateString(date)}')", CommandType.Text);
                return (value.ToString() == "") ? null : (double?)value;
            }
            else
            {
                object value = DataProvider.Instance.ExecuteScalar($"select dbo.func_TotalSellOfDay('{GetFormatString.GetDateString(date)}')", CommandType.Text);
                return (value.ToString() == "") ? null : (double?)value;
            }
        }

        public double? GetValueOfAllBills_Month(DateTime date)
        {
            if (typeBill == "Imported")
            {
                object value = DataProvider.Instance.ExecuteScalar($"select dbo.func_TotalBuyOfMonth({date.Month}, {date.Year})", CommandType.Text);
                return (value.ToString() == "") ? null : (double?)value;
            }
            else
            {
                object value = DataProvider.Instance.ExecuteScalar($"select dbo.func_TotalSellOfMonth({date.Month}, {date.Year})", CommandType.Text);
                return (value.ToString() == "") ? null : (double?)value;
            }
        }
        public Dictionary<string, int> GetTopSellingProducts()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            string query = @"
                SELECT TOP 10
                    p.Name,
                    SUM(od.Quantity) AS TotalSold
                FROM OrderedDetail od
                INNER JOIN Product p ON od.ProductID = p.ID
                GROUP BY p.Name
                ORDER BY SUM(od.Quantity) DESC";

            DataTable dt = DataProvider.Instance.ExecuteQuery(query,CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string name = row["Name"].ToString();
                int total = System.Convert.ToInt32(row["TotalSold"]);

                result.Add(name, total);
            }

            return result;
        }
        //public DataTable FindBillByDateRange(DateTime from, DateTime to)
        //{
        //    string dateFrom = AdditionalFunctions.getDateString(from);
        //    string dateTo = AdditionalFunctions.getDateString(to);
        //    return DataProvider.Instance.ExecuteQuery($"select * from dbo.func_Find{typeBill}ByDateRange('{dateFrom}', {dateTo})", CommandType.Text);
        //}
    }
}
