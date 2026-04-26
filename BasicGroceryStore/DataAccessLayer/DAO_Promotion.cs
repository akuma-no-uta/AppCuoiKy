using BasicGroceryStore.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BasicGroceryStore.DataAccessLayer
{
    internal class DAO_Promotion
    {
        // ══════════════════════════════════════════════════════
        // CRUD
        // ══════════════════════════════════════════════════════

        public bool Create(Promotion p)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(
                    "sp_InsertPromotion",
                    CommandType.StoredProcedure,
                    new SqlParameter("@ID", p.ID),
                    new SqlParameter("@PromotionName", p.PromotionName),
                    new SqlParameter("@DiscountPercent", p.DiscountPercent),
                    new SqlParameter("@StartDate", p.StartDate),
                    new SqlParameter("@EndDate", p.EndDate)
                ) > 0;
            }
            catch
            {
                return DataProvider.Instance.ExecuteNonQuery(
                    @"INSERT INTO Promotion(ID, PromotionName, DiscountPercent, StartDate, EndDate)
                      VALUES (@ID, @PromotionName, @DiscountPercent, @StartDate, @EndDate)",
                    CommandType.Text,
                    new SqlParameter("@ID", p.ID),
                    new SqlParameter("@PromotionName", p.PromotionName),
                    new SqlParameter("@DiscountPercent", p.DiscountPercent),
                    new SqlParameter("@StartDate", p.StartDate),
                    new SqlParameter("@EndDate", p.EndDate)
                ) > 0;
            }
        }

        public bool Update(Promotion p)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(
                    "sp_UpdatePromotion",
                    CommandType.StoredProcedure,
                    new SqlParameter("@ID", p.ID),
                    new SqlParameter("@PromotionName", p.PromotionName),
                    new SqlParameter("@DiscountPercent", p.DiscountPercent),
                    new SqlParameter("@StartDate", p.StartDate),
                    new SqlParameter("@EndDate", p.EndDate)
                ) > 0;
            }
            catch
            {
                return DataProvider.Instance.ExecuteNonQuery(
                    @"UPDATE Promotion
                      SET PromotionName    = @PromotionName,
                          DiscountPercent = @DiscountPercent,
                          StartDate       = @StartDate,
                          EndDate         = @EndDate
                      WHERE ID = @ID",
                    CommandType.Text,
                    new SqlParameter("@ID", p.ID),
                    new SqlParameter("@PromotionName", p.PromotionName),
                    new SqlParameter("@DiscountPercent", p.DiscountPercent),
                    new SqlParameter("@StartDate", p.StartDate),
                    new SqlParameter("@EndDate", p.EndDate)
                ) > 0;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(
                    "sp_DeletePromotion",
                    CommandType.StoredProcedure,
                    new SqlParameter("@ID", id)
                ) > 0;
            }
            catch
            {
                return DataProvider.Instance.ExecuteNonQuery(
                    "DELETE FROM Promotion WHERE ID = @ID",
                    CommandType.Text,
                    new SqlParameter("@ID", id)
                ) > 0;
            }
        }

        public DataTable GetAllPromotion()
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery(
                    "sp_GetAllPromotion",
                    CommandType.StoredProcedure
                );
            }
            catch
            {
                return DataProvider.Instance.ExecuteQuery(
                    "SELECT * FROM Promotion ORDER BY StartDate DESC",
                    CommandType.Text
                );
            }
        }

        // ══════════════════════════════════════════════════════
        // PRODUCT MAPPING
        // ══════════════════════════════════════════════════════

        /// <summary>Sản phẩm đang có trong khuyến mãi (kèm giá gốc, giá sau giảm)</summary>
        public DataTable GetProductByPromotion(string promotionID)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery(
                    "sp_GetProductByPromotion",
                    CommandType.StoredProcedure,
                    new SqlParameter("@PromotionID", promotionID)
                );
            }
            catch
            {
                return DataProvider.Instance.ExecuteQuery(
                    @"SELECT p.ID, p.Name, p.Price,
                             (p.Price - p.Price * pr.DiscountPercent / 100) AS SalePrice
                      FROM Product p
                      INNER JOIN Promotion_Product pp ON p.ID = pp.ProductID
                      INNER JOIN Promotion pr ON pp.PromotionID = pr.ID
                      WHERE pp.PromotionID = @PromotionID",
                    CommandType.Text,
                    new SqlParameter("@PromotionID", promotionID)
                );
            }
        }

        /// <summary>Sản phẩm CHƯA có trong khuyến mãi (để chọn thêm)</summary>
        public DataTable GetProductsNotInPromotion(string promotionID)
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery(
                    "sp_GetProductsNotInPromotion",
                    CommandType.StoredProcedure,
                    new SqlParameter("@PromotionID", promotionID)
                );
            }
            catch
            {
                return DataProvider.Instance.ExecuteQuery(
                    @"SELECT p.ID, p.Name, p.Price
                      FROM Product p
                      WHERE p.ID NOT IN (
                          SELECT ProductID FROM Promotion_Product
                          WHERE PromotionID = @PromotionID
                      )",
                    CommandType.Text,
                    new SqlParameter("@PromotionID", promotionID)
                );
            }
        }

        /// <summary>Thêm sản phẩm vào khuyến mãi</summary>
        public bool AddProductToPromotion(string promotionID, string productID)
        {
            return DataProvider.Instance.ExecuteNonQuery(
                @"INSERT INTO Promotion_Product(PromotionID, ProductID)
                  VALUES (@PID, @PrID)",
                CommandType.Text,
                new SqlParameter("@PID", promotionID),
                new SqlParameter("@PrID", productID)
            ) > 0;
        }

        /// <summary>Xóa sản phẩm khỏi khuyến mãi</summary>
        public bool RemoveProductFromPromotion(string promotionID, string productID)
        {
            try
            {
                return DataProvider.Instance.ExecuteNonQuery(
                    "sp_RemoveProductFromPromotion",
                    CommandType.StoredProcedure,
                    new SqlParameter("@PromotionID", promotionID),
                    new SqlParameter("@ProductID", productID)
                ) > 0;
            }
            catch
            {
                return DataProvider.Instance.ExecuteNonQuery(
                    @"DELETE FROM Promotion_Product
                      WHERE PromotionID = @PromotionID AND ProductID = @ProductID",
                    CommandType.Text,
                    new SqlParameter("@PromotionID", promotionID),
                    new SqlParameter("@ProductID", productID)
                ) > 0;
            }
        }

        /// <summary>Lấy % giảm của 1 sản phẩm cụ thể (KM còn hiệu lực)</summary>
        public float GetDiscountByProduct(string productID)
        {
            float discount = 0;
            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery(
                    @"SELECT TOP 1 pr.DiscountPercent
              FROM Promotion pr
              INNER JOIN Promotion_Product pp ON pr.ID = pp.PromotionID
              WHERE pp.ProductID = @ProductID
              AND CAST(GETDATE() AS DATE) BETWEEN pr.StartDate AND pr.EndDate",
                    CommandType.Text,
                    new SqlParameter("@ProductID", productID)
                );

                if (dt.Rows.Count > 0)
                    discount = Convert.ToSingle(dt.Rows[0]["DiscountPercent"]);
            }
            catch
            {
                discount = 0;
            }
            return discount;
        }

        // ══════════════════════════════════════════════════════
        // CHART
        // ══════════════════════════════════════════════════════

        /// <summary>Tổng tiền tiết kiệm theo từng KM – dùng cho chart</summary>
        public DataTable GetTotalSavedByPromotion()
        {
            try
            {
                return DataProvider.Instance.ExecuteQuery(
                    "sp_GetTotalSavedByPromotion",
                    CommandType.StoredProcedure
                );
            }
            catch
            {
                return DataProvider.Instance.ExecuteQuery(
                    @"SELECT pr.PromotionName,
                             ISNULL(SUM(od.Quantity * od.Price * pr.DiscountPercent / 100), 0) AS TotalSaved
                      FROM Promotion pr
                      LEFT JOIN Promotion_Product pp ON pr.ID = pp.PromotionID
                      LEFT JOIN OrderedDetail od ON pp.ProductID = od.ProductID
                      LEFT JOIN Ordered o ON od.OrderedID = o.ID
                          AND o.DateCreate BETWEEN pr.StartDate AND pr.EndDate
                      GROUP BY pr.PromotionName",
                    CommandType.Text
                );
            }
        }
    }
}