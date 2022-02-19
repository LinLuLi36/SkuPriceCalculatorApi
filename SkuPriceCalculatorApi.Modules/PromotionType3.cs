using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;
using SkuPriceCalculatorApi.Models;
using SkuPriceCalculatorApi.Modules.Utilities;

namespace SkuPriceCalculatorApi.Modules
{
    public class PromotionType3 : PromotionType
    {
        /// <summary>
        /// 1*C + 1*D for 30
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalPrice"></param>
        public override void UpdateTotalPrice(List<Item> items, ref decimal totalPrice)
        {
            var skuId1 = SkuId.C;
            var skuId2 = SkuId.D;
            var numberMin = 1;
            var promotionPrice = 30;

            var itemsSelected = items.Where(i => i.SkuId == skuId1 || i.SkuId == skuId2).DistinctBy(a => a.SkuId).ToList();

            if (itemsSelected.Count >= 2 && !itemsSelected.Any(i => i.Number < numberMin))
            {
                totalPrice += promotionPrice;

                foreach (var item in itemsSelected)
                {
                    UpdateItemNumber.Update(items, numberMin, item);
                }
            }
        }
    }
}
