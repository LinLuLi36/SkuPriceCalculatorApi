using System;
using System.Linq;
using SkuPriceCalculatorApi.Interfaces.Calculators;
using SkuPriceCalculatorApi.Models;
using SkuPriceCalculatorApi.Modules.Utilities;

namespace SkuPriceCalculatorApi.Calculators
{
    /// <summary>
    /// This class contains price calculation engine
    /// </summary>
    public class TotalPriceCalculator : ITotalPriceCalculator
    {
        private readonly INormalPriceCalculator _normalPriceCalculator;
        private readonly IPromoPriceCalculator _promoPriceCalculator;

        public TotalPriceCalculator(INormalPriceCalculator normalPriceCalculator,
            IPromoPriceCalculator promoPriceCalculator)
        {
            _normalPriceCalculator = normalPriceCalculator;
            _promoPriceCalculator = promoPriceCalculator;
        }

        /// <summary>
        /// Method parse the input itemListString validate it and send it to PromotionProcessor
        /// </summary>
        /// <param name="itemListInput"></param>
        /// <returns></returns>
        public decimal Calculate(string itemListInput)
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

                        if (!int.TryParse(itemString[1], out var itemNumber))
                        {
                            throw new Exception($"Number of the item {itemString[0]}, {itemString[1]} must be a decimal value.");
                        }

                        return new Item(itemSkuId, itemNumber);
                    })
                    .ToList();

                var promotions = PromotionLoader.LoadPromotions().ToList();

                var totalPrice = _promoPriceCalculator.Calculate(items, promotions) +
                                 _normalPriceCalculator.Calculate(items);

                return totalPrice;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
