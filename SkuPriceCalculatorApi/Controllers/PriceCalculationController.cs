using Microsoft.AspNetCore.Mvc;

namespace SkuPriceCalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceCalculationController : ControllerBase
    {
        /// <summary>
        /// The itemString can e.g. be A,5;B,5;C,1;D,1
        /// A is SKUId and 5 is number of this SKU unit 
        /// </summary>
        /// <param name="itemsString"></param>
        /// <returns></returns>
        [HttpGet]
        public decimal Get(string itemsString)
        {
            return PriceCalculation.CalculateTotalPrice(itemsString);
        }
    }
}
