namespace SkuPriceCalculatorApi.Interfaces.Calculators
{
    public interface ITotalPriceCalculator
    {
        public decimal Calculate(string itemListInput);
    }
}
