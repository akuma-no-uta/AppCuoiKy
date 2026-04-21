using BasicGroceryStore.DataAccessLayer;
using BasicGroceryStore.DTO;
using System.Data;

namespace BasicGroceryStore.BusinessLogicLayer
{
    internal class BUS_Promotion
    {
        private DAO_Promotion daoPromotion;

        public BUS_Promotion()
        {
            daoPromotion = new DAO_Promotion();
        }

        public bool Create(Promotion promotion)
        {
            return daoPromotion.Create(promotion);
        }

        public bool Update(Promotion promotion)
        {
            return daoPromotion.Update(promotion);
        }
        public float GetDiscountByCategory(string category)
        {
            return daoPromotion.GetDiscountByCategory(category);
        }
        public bool Delete(string id)
        {
            return daoPromotion.Delete(id);
        }

        public DataTable GetAllPromotion()
        {
            return daoPromotion.GetAllPromotion();
        }

        // ✅ chỉ giữ 1 hàm duy nhất
        public DataTable GetProductByPromotion(string promotionID)
        {
            return daoPromotion.GetProductByPromotion(promotionID);
        }

        // ✅ thêm mapping promotion - product
        public void AddProductToPromotion(string promotionID, string productID)
        {
            daoPromotion.InsertPromotionProduct(promotionID, productID);
        }
    }
}