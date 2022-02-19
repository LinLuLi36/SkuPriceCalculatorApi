using System.Collections.Generic;
using System.Linq;
using SkuPriceCalculatorApi.Models;
using SkuPriceCalculatorApi.Modules.Utilities;

namespace SkuPriceCalculatorApi.Modules
{
    public class PromotionType2 : PromotionType
    {
        /// <summary>
        /// 2 of B's for 45
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalPrice"></param>
        public override void UpdateTotalPrice(List<Item> items, ref decimal totalPrice)
        {
            var skuId = SkuId.B;
            var item = items.FirstOrDefault(i => i.SkuId == skuId);
            var numberMin = 2;
            var promotionPrice = 45;

            if (item != null && item.Number >= numberMin)
            {
                //the algorithm is based on the following example in the assignment:
                //Scenario B
                //...
                //5 * B 45 + 45 + 30
                //...
                totalPrice += item.Number > 4 ? promotionPrice * 2 : promotionPrice;
                UpdateItemNumber.Update(items, item.Number > 4 ? numberMin * 2 : numberMin, item);
            }
        }

    }
}
