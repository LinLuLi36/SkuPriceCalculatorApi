using System.Collections.Generic;
using SkuPriceCalculatorApi.Models.Models;

namespace SkuPriceCalculatorApi.Types.Templates
{
    public abstract class PromotionType
    {
        public abstract void UpdateTotalPrice(List<Item> items, ref decimal totalPrice);

    }
}
