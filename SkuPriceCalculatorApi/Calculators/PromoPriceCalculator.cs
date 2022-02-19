using System.Collections.Generic;
using SkuPriceCalculatorApi.Interfaces.Calculators;
using SkuPriceCalculatorApi.Models;

namespace SkuPriceCalculatorApi.Calculators
{
    public class PromoPriceCalculator : IPromoPriceCalculator
    {
        private delegate void PromotionProcessor(List<Item> items, ref decimal totalPrice);

        /// <summary>
        /// The method calls all the promotion calculation methods and return the total price
        /// </summary>
        /// <param name="items"></param>
        /// <param name="promotionList"></param>
        /// <returns></returns>
        public decimal Calculate(List<Item> items, List<PromotionType> promotionList)
        {
            decimal priceWithPromotion = 0;
            PromotionProcessor p = null;

            foreach (var promotion in promotionList)
            {
                p += promotion.UpdateTotalPrice;
            }

            if (p != null) p(items, ref priceWithPromotion);

            return priceWithPromotion;
        }
    }
}
