using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using SkuPriceCalculatorApi.Interfaces.Calculators;
using SkuPriceCalculatorApi.Models;
using Xunit;

namespace PromotionEngine.Test.Calculators
{
    public class NormalPriceCalculatorTest
    {
        private readonly List<Item> _items;
        private readonly ServiceProvider _serviceProvider;

        public NormalPriceCalculatorTest()
        {
            _serviceProvider = new DependencySetupFixture().ServiceProvider;
            _items = new List<Item>()
                {new (SkuId.A, 5), new (SkuId.B, 5), new (SkuId.C, 1), new (SkuId.D, 2)};
        }

        
        [Fact]
        public void NormalPriceCalculationTest()
        {
            using var scope = _serviceProvider.CreateScope();
            var normalPriceCalculator = scope.ServiceProvider.GetService<INormalPriceCalculator>();
            if (normalPriceCalculator != null)
            {
                var price = normalPriceCalculator.Calculate(_items);

                var correctAnswer = ItemPrice.PriceFinder(SkuId.A) * 5
                                    + ItemPrice.PriceFinder(SkuId.B) * 5
                                    + ItemPrice.PriceFinder(SkuId.C) * 1
                                    + ItemPrice.PriceFinder(SkuId.D) * 2;

                Assert.Equal(correctAnswer, price);
            }
        }
    }
}
