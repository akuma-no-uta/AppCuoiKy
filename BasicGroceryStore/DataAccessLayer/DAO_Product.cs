using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace BasicGroceryStore
{
    internal class DAO_Product : IControl<Product>, IProductServices
    {
        public bool Create(Product product)
        {
            return (DataProvider.Instance.ExecuteNonQuery("sp_InsertProduct",
                    CommandType.StoredProcedure,
                    new SqlParameter("@ID", product.ID),
                    new SqlParameter("@Name", product.Name),
                    new SqlParameter("@TypeProduct", product.TypeProduct),
                    new SqlParameter("@Unit", product.Unit),
                    new SqlParameter("@Quantity", product.Quantity),
                    new SqlParameter("@Image", Convert.ImageToByteArray(product.Image)),
                    new SqlParameter("@Note", product.Note),
                    new SqlParameter("@Price", product.Price),
                    new SqlParameter("@SupplierID", product.SupplierID)) > 0);
        }

        public bool ReduceStock(string productID, int quantity)
        {
            string query = @"
                UPDATE Product
                SET Quantity = Quantity - @Quantity
                WHERE ID = @ID AND Quantity >= @Quantity";
            return DataProvider.Instance.ExecuteNonQuery(query, CommandType.Text,
                new SqlParameter("@ID", productID),
                new SqlParameter("@Quantity", quantity)) > 0;
        }

        public bool Update(Product product)
        {
            return (DataProvider.Instance.ExecuteNonQuery("sp_UpdateProduct",
                    CommandType.StoredProcedure,
                    new SqlParameter("@ID", product.ID),
                    new SqlParameter("@Name", product.Name),
                    new SqlParameter("@TypeProduct", product.TypeProduct),
                    new SqlParameter("@Unit", product.Unit),
                    new SqlParameter("@Quantity", product.Quantity),
                    new SqlParameter("@Image", Convert.ImageToByteArray(product.Image)),
                    new SqlParameter("@Note", product.Note),
                    new SqlParameter("@Price", product.Price),
                    new SqlParameter("@SupplierID", product.SupplierID)) > 0);
        }

        public bool Delete(Product product)
        {
            return (DataProvider.Instance.ExecuteNonQuery("sp_DeleteProduct",
                    CommandType.StoredProcedure,
                    new SqlParameter("@id", product.ID)) > 0);
        }

        public DataTable GetAllProduct()
        {
            return DataProvider.Instance.ExecuteQuery(
                "sp_GetAllProduct", CommandType.StoredProcedure, null);
        }

        public Product GetProduct(string product_id)
        {
            if (product_id == "") return null;

            DataTable dt = DataProvider.Instance.ExecuteQuery(
                $"select * from Product where Id='{product_id}'", CommandType.Text, null);
            DataRow row = dt.Rows[0];

            Image image = null;
            if (row[5] != DBNull.Value)
                image = Convert.ByteArrayToImage((byte[])row[5]);

            return new Product(
                iD: row[0].ToString(),
                name: row[1].ToString(),
                typeProduct: row[2].ToString(),
                unit: row[3].ToString(),
                quantity: int.Parse(row[4].ToString()),
                image: image,
                note: row[6].ToString(),
                price: float.Parse(row[7].ToString()),
                supplierID: row[8].ToString());
        }

        public DataTable GetProductOfSupplier(string supplier_id)
        {
            return DataProvider.Instance.ExecuteQuery(
                "select * from Product where SupplierID = @sup_id",
                CommandType.Text,
                new SqlParameter("@sup_id", supplier_id));
        }

        public List<string> GetAllTypeOfProduct()
        {
            var list = new List<string>();
            DataTable tb = DataProvider.Instance.ExecuteQuery(
                "select distinct TypeProduct from Product", CommandType.Text);
            foreach (DataRow r in tb.Rows) list.Add(r[0].ToString());
            return list;
        }

        public List<string> GetAllUnit()
        {
            var list = new List<string>();
            DataTable tb = DataProvider.Instance.ExecuteQuery(
                "select distinct Unit from Product", CommandType.Text);
            foreach (DataRow r in tb.Rows) list.Add(r[0].ToString());
            return list;
        }

        public int GetNumberOfProduct_depot()
        {
            return (int)DataProvider.Instance.ExecuteScalar(
                "select dbo.func_NumberOfProduct_depot()", CommandType.Text);
        }

        public bool CheckStock(string productID, int quantity)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery(
                "SELECT Quantity FROM Product WHERE ID = @ID",
                CommandType.Text,
                new SqlParameter("@ID", productID));

            if (dt.Rows.Count == 0) return false;
            return int.Parse(dt.Rows[0][0].ToString()) >= quantity;
        }

        public DataTable FindProductByTypeProduct(string typeProduct)
        {
            return DataProvider.Instance.ExecuteQuery(
                $"select * from dbo.func_FindProductByTypeProduct(N'{typeProduct}')",
                CommandType.Text);
        }

        public DataTable FindProductByName(string name)
        {
            return DataProvider.Instance.ExecuteQuery(
                $"select * from dbo.func_FindProductByName(N'{name}')",
                CommandType.Text);
        }

        public DataTable FindProductByPriceRange(float from, float to)
        {
            return DataProvider.Instance.ExecuteQuery(
                $"select * from dbo.func_FindProductByPriceRange({from}, {to})",
                CommandType.Text);
        }

        public DataTable FindProductBySupplier(string supplierName)
        {
            return DataProvider.Instance.ExecuteQuery(
                $"select * from dbo.func_FindProductBySupplier(N'{supplierName}')",
                CommandType.Text);
        }

        // ════════════════════════════════════════════════════════
        //  HÀM MỚI: Lấy danh sách sản phẩm tồn kho thấp
        // ════════════════════════════════════════════════════════

        /// <summary>
        /// Trả về DataTable gồm: ID, Name, TypeProduct, Unit, Quantity, Price, SupplierID
        /// cho tất cả sản phẩm có Quantity &lt;= threshold.
        /// Sắp xếp tăng dần theo Quantity (hàng nguy hiểm nhất lên đầu).
        /// </summary>
        public DataTable GetLowStockProducts(int threshold = 10)
        {
            string query = @"
                SELECT
                    p.ID,
                    p.Name,
                    p.TypeProduct,
                    p.Unit,
                    p.Quantity,
                    p.Price,
                    p.SupplierID,
                    s.Name AS SupplierName
                FROM Product p
                LEFT JOIN Supplier s ON p.SupplierID = s.ID
                WHERE p.Quantity <= @Threshold
                ORDER BY p.Quantity ASC";

            return DataProvider.Instance.ExecuteQuery(
                query,
                CommandType.Text,
                new SqlParameter("@Threshold", threshold));
        }

        /// <summary>
        /// Trả về số lượng sản phẩm đang hết hàng hoàn toàn (Quantity = 0).
        /// </summary>
        public int GetOutOfStockCount()
        {
            object result = DataProvider.Instance.ExecuteScalar(
                "SELECT COUNT(*) FROM Product WHERE Quantity = 0",
                CommandType.Text);
            return result == DBNull.Value ? 0 : System.Convert.ToInt32(result);
        }
    }
}