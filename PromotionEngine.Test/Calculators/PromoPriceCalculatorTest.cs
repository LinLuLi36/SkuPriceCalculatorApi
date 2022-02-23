using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SkuPriceCalculatorApi.Interfaces.Calculators;
using SkuPriceCalculatorApi.Models;
using SkuPriceCalculatorApi.Modules;
using SkuPriceCalculatorApi.Modules.Utilities;
using Xunit;

namespace PromotionEngine.Test.Calculators
{
    public class PromoPriceCalculatorTest
    {
        private readonly List<Item> _items;
        private readonly List<PromotionType> _promotionList;
        private readonly ServiceProvider _serviceProvider;

        public PromoPriceCalculatorTest()
        {
            _serviceProvider = new DependencySetupFixture().ServiceProvider;
            _items = new List<Item>()
                {new(SkuId.A, 5), new(SkuId.B, 5), new(SkuId.C, 1), new(SkuId.D, 2)};
            _promotionList = PromotionLoader.LoadPromotions().ToList();
        }

        /// <summary>
        /// This unit test tests all the promotion types
        /// After promotions are applied, the price is now 250.
        /// </summary>
        [Fact]
        public void PromoPriceCalculationTest()
        {
            using var scope = _serviceProvider.CreateScope();
            var promoPriceCalculator = scope.ServiceProvider.GetService<IPromoPriceCalculator>();
            if (promoPriceCalculator != null)
            {
                var priceWithPromotion = promoPriceCalculator.Calculate(_items, _promotionList);
                Assert.Equal(250, priceWithPromotion);
            }
        }
    }
}