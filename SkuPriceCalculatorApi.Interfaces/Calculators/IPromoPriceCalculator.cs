using System.Collections.Generic;
using SkuPriceCalculatorApi.Models;
using SkuPriceCalculatorApi.Modules;

namespace SkuPriceCalculatorApi.Interfaces.Calculators
{
    public interface IPromoPriceCalculator
    {
        public decimal Calculate(List<Item> items, List<PromotionType> promotionList);
    }
}