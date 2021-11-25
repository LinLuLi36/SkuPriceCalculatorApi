using Microsoft.AspNetCore.Mvc;

namespace SkuPriceCalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceCalculationController : ControllerBase
    {
        
        [HttpGet]
        public decimal Get(string itemsString)
        {
            return PriceCalculation.CalculateTotalPrice(itemsString);
        }
    }
}
