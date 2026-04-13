using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGroceryStore.DTO
{
    public class Promotion
    {
        public string ID { get; set; }
        public string PromotionName { get; set; }
        public string Category { get; set; }
        public float DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Promotion()
        {
            ID = GetFormatString.MakingIDNow();
        }
    }
}
