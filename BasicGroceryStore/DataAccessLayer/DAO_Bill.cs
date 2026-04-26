using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
                new SqlParameter("@Phone", phone));
            return dt.Rows.Count > 0;
        }

        public bool Create(Bill bill, string customerName)
        {
            List<SqlParameter> param = new List<SqlParameter>() {
                new SqlParameter("@ID",         bill.ID),
                new SqlParameter("@DateCreate", bill.DateCreate),
                new SqlParameter("@Value",      bill.Value),
                new SqlParameter("@StaffID",    bill.StaffID) };
            if (typeBill == "Ordered")
                param.Add(new SqlParameter("@CustomerName", customerName));
            return DataProvider.Instance.ExecuteNonQuery(
                $"sp_Insert{typeBill}", CommandType.StoredProcedure, param.ToArray()) > 0;
        }

        public bool Update(Bill bill, string customerName)
        {
            List<SqlParameter> param = new List<SqlParameter>() {
                new SqlParameter("@ID",         bill.ID),
                new SqlParameter("@DateCreate", bill.DateCreate),
                new SqlParameter("@Value",      bill.Value),
                new SqlParameter("@StaffID",    bill.StaffID) };
            if (typeBill == "Ordered")
                param.Add(new SqlParameter("@CustomerName", customerName));
            return DataProvider.Instance.ExecuteNonQuery(
                $"sp_Update{typeBill}", CommandType.StoredProcedure, param.ToArray()) > 0;
        }

        public bool Delete(Bill bill)
        {
            return DataProvider.Instance.ExecuteNonQuery(
                $"sp_Delete{typeBill}", CommandType.StoredProcedure,
                new SqlParameter("@ID", bill.ID)) > 0;
        }

        public DataTable GetAllBill()
        {
            return DataProvider.Instance.ExecuteQuery(
                $"SELECT * FROM {typeBill}", CommandType.Text, null);
        }

        public int GetQuantityOfBill()
        {
            return (int)DataProvider.Instance.ExecuteScalar(
                $"SELECT dbo.func_NumberOf{typeBill}()", CommandType.Text);
        }

        public float GetValueOfBill(string bill_id)
        {
            return (float)System.Convert.ToDouble(
                DataProvider.Instance.ExecuteScalar(
                    $"SELECT Value FROM {typeBill} WHERE Id='{bill_id}'", CommandType.Text));
        }

        public DataTable GetAllItemInBill(string bill_id)
        {
            string detailTable = (typeBill == "Imported") ? "ImportedDetail" : "OrderedDetail";
            string fk = (typeBill == "Imported") ? "ImportedID" : "OrderedID";

            string query = $@"
                SELECT
                    p.Name                       AS ItemName,
                    d.Quantity,
                    d.Price,
                    (d.Quantity * d.Price)        AS TotalPrice
                FROM {detailTable} d
                INNER JOIN Product p ON d.ProductID = p.ID
                WHERE d.{fk} = @ID";

            return DataProvider.Instance.ExecuteQuery(
                query, CommandType.Text, new SqlParameter("@ID", bill_id));
        }

        // ════════════════════════════════════════════════════════
        //  HÀM MỚI: Lấy toàn bộ sản phẩm đã nhập/bán
        //  trong khoảng thời gian, tổng hợp theo tên SP
        // ════════════════════════════════════════════════════════
        /// <summary>
        /// Trả về DataTable gồm: ItemName, TypeProduct, TotalQty, TotalPrice
        /// cho tất cả hóa đơn có DateCreate trong [startDate, endDate].
        /// </summary>
        public DataTable GetItemsSummaryByDateRange(DateTime startDate, DateTime endDate)
        {
            string detailTable = (typeBill == "Imported") ? "ImportedDetail" : "OrderedDetail";
            string billTable = typeBill;                // "Imported" hoặc "Ordered"
            string fk = (typeBill == "Imported") ? "ImportedID" : "OrderedID";

            string query = $@"
                SELECT
                    p.Name                          AS ItemName,
                    p.TypeProduct,
                    SUM(d.Quantity)                 AS TotalQty,
                    SUM(d.Quantity * d.Price)       AS TotalPrice
                FROM {detailTable} d
                INNER JOIN {billTable} b ON d.{fk}     = b.ID
                INNER JOIN Product     p ON d.ProductID = p.ID
                WHERE CAST(b.DateCreate AS DATE)
                      BETWEEN @StartDate AND @EndDate
                GROUP BY p.Name, p.TypeProduct
                ORDER BY TotalQty DESC";

            return DataProvider.Instance.ExecuteQuery(
                query,
                CommandType.Text,
                new SqlParameter("@StartDate", startDate.Date),
                new SqlParameter("@EndDate", endDate.Date));
        }

        // ════════════════════════════════════════════════════════
        //  HÀM MỚI: Tổng hợp theo LOẠI sản phẩm trong khoảng ngày
        // ════════════════════════════════════════════════════════
        /// <summary>
        /// Trả về DataTable gồm: TypeProduct, TotalQty, TotalPrice
        /// </summary>
        public DataTable GetItemsByTypeSummaryByDateRange(DateTime startDate, DateTime endDate)
        {
            string detailTable = (typeBill == "Imported") ? "ImportedDetail" : "OrderedDetail";
            string billTable = typeBill;
            string fk = (typeBill == "Imported") ? "ImportedID" : "OrderedID";

            string query = $@"
                SELECT
                    p.TypeProduct,
                    SUM(d.Quantity)           AS TotalQty,
                    SUM(d.Quantity * d.Price) AS TotalPrice
                FROM {detailTable} d
                INNER JOIN {billTable} b ON d.{fk}     = b.ID
                INNER JOIN Product     p ON d.ProductID = p.ID
                WHERE CAST(b.DateCreate AS DATE)
                      BETWEEN @StartDate AND @EndDate
                GROUP BY p.TypeProduct
                ORDER BY TotalQty DESC";

            return DataProvider.Instance.ExecuteQuery(
                query,
                CommandType.Text,
                new SqlParameter("@StartDate", startDate.Date),
                new SqlParameter("@EndDate", endDate.Date));
        }

        // ════════════════════════════════════════════════════════
        //  Các hàm thống kê tổng giá trị (giữ nguyên)
        // ════════════════════════════════════════════════════════
        public double? GetValueOfAllBills()
        {
            object res = DataProvider.Instance.ExecuteScalar(
                $"SELECT SUM(Value) FROM {typeBill}", CommandType.Text, null);
            return (res == DBNull.Value) ? 0 : System.Convert.ToDouble(res);
        }

        public double? GetValueOfAllBills_Day(DateTime date)
        {
            string funcName = (typeBill == "Imported") ? "func_TotalBuyOfDay" : "func_TotalSellOfDay";
            object value = DataProvider.Instance.ExecuteScalar(
                $"SELECT dbo.{funcName}('{GetFormatString.GetDateString(date)}')", CommandType.Text);
            return (value == null || value.ToString() == "") ? 0 : System.Convert.ToDouble(value);
        }

        public double? GetValueOfAllBills_Month(DateTime date)
        {
            string funcName = (typeBill == "Imported") ? "func_TotalBuyOfMonth" : "func_TotalSellOfMonth";
            object value = DataProvider.Instance.ExecuteScalar(
                $"SELECT dbo.{funcName}({date.Month}, {date.Year})", CommandType.Text);
            return (value == null || value.ToString() == "") ? 0 : System.Convert.ToDouble(value);
        }

        public Dictionary<string, int> GetTopSellingProducts()
        {
            var result = new Dictionary<string, int>();
            string query = @"
                SELECT TOP 10 p.Name, SUM(od.Quantity) AS TotalSold
                FROM OrderedDetail od
                INNER JOIN Product p ON od.ProductID = p.ID
                GROUP BY p.Name
                ORDER BY SUM(od.Quantity) DESC";

            DataTable dt = DataProvider.Instance.ExecuteQuery(query, CommandType.Text);
            foreach (DataRow row in dt.Rows)
                result.Add(row["Name"].ToString(), System.Convert.ToInt32(row["TotalSold"]));
            return result;
        }
    }
}