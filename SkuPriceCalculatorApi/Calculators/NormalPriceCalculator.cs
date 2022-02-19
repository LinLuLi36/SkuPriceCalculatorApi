using System.Collections.Generic;
using System.Linq;
using SkuPriceCalculatorApi.Interfaces.Calculators;
using SkuPriceCalculatorApi.Models;

namespace SkuPriceCalculatorApi.Calculators
{
    public class NormalPriceCalculator : INormalPriceCalculator
    {
        /// <summary>
        /// Total price for items without any promotion applied
        /// </summary>
        /// <param name="items"></param>
        public decimal Calculate(List<Item> items)
        {
            return items.Sum(i => i.Number * i.UnitPrice);
        }
    }
}
