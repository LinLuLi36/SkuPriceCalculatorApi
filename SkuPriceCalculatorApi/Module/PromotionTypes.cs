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
            var amountMin = 3;
            var promotionPrice = 130;

            if (item != null && item.Amount >= amountMin)
            {
                totalPrice += promotionPrice;
                UpdateItemAmountInItemList(items, amountMin, item);
            }
        }

        /// <summary>
        /// 2 of B's for 130
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalPrice"></param>
        public static void PromotionType2 (List<Item> items, ref decimal totalPrice)
        {
            var skuId = SkuId.B;
            var item = items.FirstOrDefault(i => i.SkuId == skuId);
            var amountMin = 2;
            var promotionPrice = 45;

            if (item != null && item.Amount >= amountMin)
            {
                totalPrice += item.Amount > 4 ? promotionPrice * 2 : promotionPrice;
                UpdateItemAmountInItemList(items, item.Amount > 4 ? amountMin * 2 : amountMin, item);
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
            var amountMin = 1;
            var promotionPrice = 30;

            var itemsSelected = items.Where(i => i.SkuId == skuId1 || i.SkuId == skuId2).DistinctBy(a => a.SkuId).ToList();

            if (itemsSelected.Count >= 2 && !itemsSelected.Any(i => i.Amount < amountMin))
            {
                totalPrice += promotionPrice;

                foreach (var item in itemsSelected)
                {
                    UpdateItemAmountInItemList(items, amountMin, item);
                }
            }
        }

        /// <summary>
        /// Total price for rest of the items without promotion
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalPrice"></param>
        public static void PriceForRestOfItems(List<Item> items, ref decimal totalPrice)
        {
            totalPrice += items.Sum(i => i.Amount * i.UnitPrice);
        }


        private static void UpdateItemAmountInItemList(List<Item> items, int amountMin, Item replaceItem)
        {
            var index = items.IndexOf(replaceItem);

            if (index != -1)
                items[index] = new Item(replaceItem.SkuId, replaceItem.Amount - amountMin);
        }
    }
}
