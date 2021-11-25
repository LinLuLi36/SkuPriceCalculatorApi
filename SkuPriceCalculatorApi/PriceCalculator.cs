using System;
using System.Collections.Generic;
using System.Linq;
using SkuPriceCalculatorApi.Model;
using static SkuPriceCalculatorApi.Module.PromotionTypes;

namespace SkuPriceCalculatorApi
{
    /// <summary>
    /// This class contains price calculation engine
    /// </summary>
    public static class PriceCalculation
    {
        private delegate void PromotionProcessor(List<Item> items, ref decimal totalPrice);

        /// <summary>
        /// The method calls all the promotion calculation methods and return the total price
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private static decimal PriceCalculator(List<Item> items)
        {
            decimal totalPrice = 0;

            PromotionProcessor p = PromotionType1;
            p += PromotionType2;
            p += PromotionType3;
            p += PriceForRestOfItems;

            p(items, ref totalPrice);

            return totalPrice;
        }

        /// <summary>
        /// Method parse the input itemListString validate it and send it to PromotionProcessor
        /// </summary>
        /// <param name="itemListInput"></param>
        /// <returns></returns>
        public static decimal CalculateTotalPrice(string itemListInput)
        {
            try
            {
                var itemStringList = itemListInput.Split(";");

                if (itemStringList.Length == 0)
                {
                    return 0;
                }

                var items = itemStringList
                    .Select(item =>
                    {
                        var itemString = item.Split(",");

                        if (!Enum.TryParse(itemString[0], out SkuId itemSkuId))
                        {
                            throw new Exception($"SKUId: {itemString[0]} is not registered in our system");
                        }

                        if (!int.TryParse(itemString[1], out var itemAmount))
                        {
                            throw new Exception($"The amount of the item {itemString[0]}, {itemString[1]} must be a decimal value.");
                        }

                        return new Item(itemSkuId, itemAmount);
                    })
                    .ToList();

                return PriceCalculator(items);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
