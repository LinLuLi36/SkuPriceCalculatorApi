namespace SkuPriceCalculatorApi.Model
{
    public class Item
    {
        public SkuId SkuId { get; set; } 
        public int Number { get; set; }
        public decimal UnitPrice => ItemPrice.PriceFinder(SkuId);

        public Item(SkuId skuId, int number)
        {
            SkuId = skuId;
            Number = number;
        }
    }
}
