using System.Collections.Generic;
using SkuPriceCalculatorApi.Models;

namespace SkuPriceCalculatorApi.Modules.Utilities
{
    public static class PromotionLoader
    {
        /// <summary>
        /// Load promotions to a List
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<PromotionType> LoadPromotions()
        {
            return ReflectiveEnumerator.GetEnumerableOfType<PromotionType>();
        }
    }
}
