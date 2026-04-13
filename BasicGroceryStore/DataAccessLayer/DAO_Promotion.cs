using BasicGroceryStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public float GetDiscountByCategory(string category)
        {
            object result = DataProvider.Instance.ExecuteScalar(
                $"SELECT TOP 1 DiscountPercent " +
                $"FROM Promotion " +
                $"WHERE (Category = N'{category}' OR Category = N'Tất cả') " +
                $"AND GETDATE() BETWEEN StartDate AND EndDate " +
                $"ORDER BY DiscountPercent DESC",
                CommandType.Text
            );

            if (result == null || result == DBNull.Value)
                return 0;

            return float.Parse(result.ToString());
        }
    }
}