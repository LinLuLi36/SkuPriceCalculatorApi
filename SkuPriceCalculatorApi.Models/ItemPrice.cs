namespace SkuPriceCalculatorApi.Models
{
    public enum SkuId
    {
        A,
        B,
        C,
        D
    }

    public static class ItemPrice
    {
        public static decimal PriceFinder(SkuId skuId) =>
            skuId switch
            {
                SkuId.A => 50,
                SkuId.B => 30,
                SkuId.C => 20,
                SkuId.D => 15,
                _ => 0
            };
    }
}
