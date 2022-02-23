using System.Collections.Generic;
using SkuPriceCalculatorApi.Models;

namespace SkuPriceCalculatorApi.Modules
{
    public abstract class PromotionType
    {
        public abstract void UpdateTotalPrice(List<Item> items, ref decimal totalPrice);

    }
}
