using BasicGroceryStore.DataAccessLayer;
using BasicGroceryStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGroceryStore.BusinessLogicLayer
{
    
        internal class BUS_Promotion
        {
            private DAO_Promotion daoPromotion;
        public float GetDiscountByCategory(string category)
        {
            return daoPromotion.GetDiscountByCategory(category);
        }
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

            public bool Delete(string id)
            {
                return daoPromotion.Delete(id);
            }

            public DataTable GetAllPromotion()
            {
                return daoPromotion.GetAllPromotion();
            }
        }
}
