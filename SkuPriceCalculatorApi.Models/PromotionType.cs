using System.Collections.Generic;

namespace SkuPriceCalculatorApi.Models
{
    public abstract class PromotionType
    {
        public abstract void UpdateTotalPrice(List<Item> items, ref decimal totalPrice);

    }
}
