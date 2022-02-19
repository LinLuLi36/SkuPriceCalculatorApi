using Microsoft.AspNetCore.Mvc;
using SkuPriceCalculatorApi.Interfaces.Calculators;

namespace SkuPriceCalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceCalculationController : ControllerBase
    {
        private readonly ITotalPriceCalculator _priceCalculator;

        public PriceCalculationController(ITotalPriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }

        /// <summary>
        /// The itemString can e.g. be A,5;B,5;C,1;D,1
        /// A is SKUId and 5 is number of this SKU unit 
        /// </summary>
        /// <param name="itemsString"></param>
        /// <returns></returns>
        [HttpGet]
        public decimal Get(string itemsString)
        {
            return _priceCalculator.Calculate(itemsString);
        }
    }
}
