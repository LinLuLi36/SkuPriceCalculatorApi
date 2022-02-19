using System.Collections.Generic;
using System.Linq;
using SkuPriceCalculatorApi.Models;
using SkuPriceCalculatorApi.Modules.Utilities;

namespace SkuPriceCalculatorApi.Modules
{
    public class PromotionType1 : PromotionType
    {
        /// <summary>
        /// 3 of A's for 130
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalPrice"></param>
        public override void UpdateTotalPrice(List<Item> items, ref decimal totalPrice)
        {
            var skuId = SkuId.A;
            var item = items.FirstOrDefault(i => i.SkuId == skuId);
            var numberMin = 3;
            var promotionPrice = 130;

            if (item != null && item.Number >= numberMin)
            {
                totalPrice += promotionPrice;
                UpdateItemNumber.Update(items, numberMin, item);
            }
        }
    }
}
