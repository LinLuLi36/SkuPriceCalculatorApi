using System.Collections.Generic;
using System.Linq;
using MoreLinq.Extensions;
using SkuPriceCalculatorApi.Model;

namespace SkuPriceCalculatorApi.Module
{
    /// <summary>
    /// The class includes modules of promotions which can be added to the calculator
    /// </summary>
    public static class PromotionTypes
    {
        /// <summary>
        /// 3 of A's for 130
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalPrice"></param>
        public static void PromotionType1 (List<Item> items, ref decimal totalPrice)
        {
            var skuId = SkuId.A;
            var item = items.FirstOrDefault(i => i.SkuId == skuId);
            var numberMin = 3;
            var promotionPrice = 130;

            if (item != null && item.Number >= numberMin)
            {
                totalPrice += promotionPrice;
                UpdateItemNumberInItemList(items, numberMin, item);
            }
        }

        /// <summary>
        /// 2 of B's for 45
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalPrice"></param>
        public static void PromotionType2 (List<Item> items, ref decimal totalPrice)
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
                UpdateItemNumberInItemList(items, item.Number > 4 ? numberMin * 2 : numberMin, item);
            }
        }


        /// <summary>
        /// 1*C + 1*D for 30
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalPrice"></param>
        public static void PromotionType3 (List<Item> items, ref decimal totalPrice)
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
                    UpdateItemNumberInItemList(items, numberMin, item);
                }
            }
        }

        /// <summary>
        /// Total price for rest of the items which should be paid individually
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalPrice"></param>
        public static void PriceForRestOfItems(List<Item> items, ref decimal totalPrice)
        {
            totalPrice += items.Sum(i => i.Number * i.UnitPrice);
        }

        /// <summary>
        /// This method update number of the items after promotions are applied 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="numberMin"></param>
        /// <param name="replaceItem"></param>
        private static void UpdateItemNumberInItemList(List<Item> items, int numberMin, Item replaceItem)
        {
            var index = items.IndexOf(replaceItem);

            if (index != -1)
                items[index] = new Item(replaceItem.SkuId, replaceItem.Number - numberMin);
        }
    }
}
