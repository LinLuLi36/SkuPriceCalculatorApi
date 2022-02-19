using System.Collections.Generic;
using SkuPriceCalculatorApi.Models;

namespace SkuPriceCalculatorApi.Interfaces.Utilities
{
    public interface IUpdateItemNumber
    {
        public void Update(List<Item> items, int numberMin, Item replaceItem);
    }
}
