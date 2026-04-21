using BasicGroceryStore.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BasicGroceryStore.DataAccessLayer
{
    internal class DAO_Promotion
    {
        public bool Create(Promotion p)
        {
            return DataProvider.Instance.ExecuteNonQuery(
                "sp_InsertPromotion",
                CommandType.StoredProcedure,
                new SqlParameter("@ID", p.ID),
                new SqlParameter("@PromotionName", p.PromotionName),
                new SqlParameter("@Category", p.Category),
                new SqlParameter("@DiscountPercent", p.DiscountPercent),
                new SqlParameter("@StartDate", p.StartDate),
                new SqlParameter("@EndDate", p.EndDate)
            ) > 0;
        }

        public bool Update(Promotion p)
        {
            return DataProvider.Instance.ExecuteNonQuery(
                "sp_UpdatePromotion",
                CommandType.StoredProcedure,
                new SqlParameter("@ID", p.ID),
                new SqlParameter("@PromotionName", p.PromotionName),
                new SqlParameter("@Category", p.Category),
                new SqlParameter("@DiscountPercent", p.DiscountPercent),
                new SqlParameter("@StartDate", p.StartDate),
                new SqlParameter("@EndDate", p.EndDate)
            ) > 0;
        }

        public bool Delete(string id)
        {
            return DataProvider.Instance.ExecuteNonQuery(
                "sp_DeletePromotion",
                CommandType.StoredProcedure,
                new SqlParameter("@ID", id)
            ) > 0;
        }

        public DataTable GetAllPromotion()
        {
            return DataProvider.Instance.ExecuteQuery(
                "sp_GetAllPromotion",
                CommandType.StoredProcedure
            );
        }

        // 🔥 QUAN TRỌNG: LẤY DISCOUNT THEO CATEGORY
        public float GetDiscountByCategory(string category)
        {
            float discount = 0;

            try
            {
                DataTable dt = DataProvider.Instance.ExecuteQuery(
                    @"SELECT TOP 1 DiscountPercent
                      FROM Promotion
                      WHERE LOWER(Category) = LOWER(@Category)
                      AND GETDATE() BETWEEN StartDate AND EndDate",
                    CommandType.Text,
                    new SqlParameter("@Category", category.Trim())
                );

                if (dt.Rows.Count > 0)
                {
                    discount = Convert.ToSingle(dt.Rows[0]["DiscountPercent"]);
                }
            }
            catch
            {
                discount = 0;
            }

            return discount;
        }

        // 🔥 LẤY PRODUCT THEO PROMOTION
        public DataTable GetProductByPromotion(string promotionID)
        {
            return DataProvider.Instance.ExecuteQuery(
                @"SELECT p.ID, p.Name, p.Price, pr.DiscountPercent
                  FROM Product p
                  INNER JOIN Promotion_Product pp ON p.ID = pp.ProductID
                  INNER JOIN Promotion pr ON pr.ID = pp.PromotionID
                  WHERE pr.ID = @ID",
                CommandType.Text,
                new SqlParameter("@ID", promotionID.Trim())
            );
        }

        // 🔥 MAP PRODUCT ↔ PROMOTION
        public void InsertPromotionProduct(string promotionID, string productID)
        {
            DataProvider.Instance.ExecuteNonQuery(
                @"INSERT INTO Promotion_Product(PromotionID, ProductID)
                  VALUES (@PID, @PrID)",
                CommandType.Text,
                new SqlParameter("@PID", promotionID),
                new SqlParameter("@PrID", productID)
            );
        }
    }
}