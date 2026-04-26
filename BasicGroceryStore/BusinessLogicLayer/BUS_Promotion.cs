using BasicGroceryStore.DataAccessLayer;
using BasicGroceryStore.DTO;
using System.Data;

namespace BasicGroceryStore.BusinessLogicLayer
{
    internal class BUS_Promotion
    {
        private readonly DAO_Promotion dao = new DAO_Promotion();

        public bool Create(Promotion p) => dao.Create(p);
        public bool Update(Promotion p) => dao.Update(p);
        public bool Delete(string id) => dao.Delete(id);
        public DataTable GetAllPromotion() => dao.GetAllPromotion();
        public DataTable GetTotalSavedByPromotion() => dao.GetTotalSavedByPromotion();

        public DataTable GetProductByPromotion(string promoID)
            => dao.GetProductByPromotion(promoID);

        public DataTable GetProductsNotInPromotion(string promoID)
            => dao.GetProductsNotInPromotion(promoID);

        public bool AddProductToPromotion(string promoID, string productID)
            => dao.AddProductToPromotion(promoID, productID);

        public bool RemoveProductFromPromotion(string promoID, string productID)
            => dao.RemoveProductFromPromotion(promoID, productID);

        /// <summary>Lấy % giảm giá của 1 sản phẩm cụ thể (dùng khi tính tiền)</summary>
        public float GetDiscountByProduct(string productID)
            => dao.GetDiscountByProduct(productID);
    }
}