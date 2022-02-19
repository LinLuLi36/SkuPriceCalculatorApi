using Microsoft.Extensions.DependencyInjection;
using SkuPriceCalculatorApi.Interfaces.Calculators;
using Xunit;

namespace PromotionEngine.Test.Calculators
{
    public class TotalPriceCalculatorTest
    {
        private readonly string _itemString;
        private readonly ServiceProvider _serviceProvider;

        public TotalPriceCalculatorTest()
        {
            _serviceProvider = new DependencySetupFixture().ServiceProvider;
            _itemString = "A,5;B,5;C,1;D,2";
        }

        /// <summary>
        /// This unit test tests the promotion type 1*C + 1*D for 30
        /// After this promotion is applied, promotion price 30 is added to the total price which is now 250.
        /// Number of SKU C and D units which should be paid individually are 1-1=0 and 2-1=1.
        /// The rest of the items cost 2*50+30+15=145. The total price for all items after promotions are applied is 250+145=395.
        /// </summary>
        [Fact]
        public void TotalPriceCalculationTest()
        {
            using var scope = _serviceProvider.CreateScope();
            var totalPriceCalculator = scope.ServiceProvider.GetService<ITotalPriceCalculator>();
            if (totalPriceCalculator != null)
            {
                var totalPrice = totalPriceCalculator.Calculate(_itemString);
                Assert.Equal(395, totalPrice);
            }
        }
    }
}