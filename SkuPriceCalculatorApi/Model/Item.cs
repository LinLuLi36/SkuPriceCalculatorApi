namespace SkuPriceCalculatorApi.Model
{
    public class Item
    {
        public SkuId SkuId { get; set; } 
        public int Amount { get; set; }
        public decimal UnitPrice => ItemPrice.PriceFinder(SkuId);

        public Item(SkuId skuId, int count)
        {
            SkuId = skuId;
            Amount = count;
        }
    }
}
