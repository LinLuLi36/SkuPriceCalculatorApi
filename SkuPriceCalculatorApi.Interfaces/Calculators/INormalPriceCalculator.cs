using System.Collections.Generic;
using SkuPriceCalculatorApi.Models;

namespace SkuPriceCalculatorApi.Interfaces.Calculators
{
    public interface INormalPriceCalculator
    {
        public decimal Calculate(List<Item> items);
    }
}