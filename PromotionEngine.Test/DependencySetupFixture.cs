using Microsoft.Extensions.DependencyInjection;
using SkuPriceCalculatorApi.Calculators;
using SkuPriceCalculatorApi.Interfaces.Calculators;

namespace PromotionEngine.Test
{
    public class DependencySetupFixture
    {
        /// <summary>
        /// This class is made for dependency registration
        /// </summary>
        public DependencySetupFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<INormalPriceCalculator, NormalPriceCalculator>();
            serviceCollection.AddTransient<IPromoPriceCalculator, PromoPriceCalculator>();
            serviceCollection.AddTransient<ITotalPriceCalculator, TotalPriceCalculator>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; }
    }
}
