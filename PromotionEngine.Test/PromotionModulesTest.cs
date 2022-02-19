using System.Collections.Generic;
using System.Linq;
using SkuPriceCalculatorApi.Models;
using SkuPriceCalculatorApi.Modules;
using Xunit;

namespace PromotionEngine.Test
{
    public class PromotionModulesTest
    {
        private readonly List<Item> _items;
        private decimal _priceWithPromotion;
        private readonly PromotionType1 _promotionType1;
        private readonly PromotionType2 _promotionType2;
        private readonly PromotionType3 _promotionType3;

        public PromotionModulesTest()
        {
            _priceWithPromotion = 0;
            _promotionType1 = new PromotionType1();
            _promotionType2 = new PromotionType2();
            _promotionType3 = new PromotionType3();
            _items = new List<Item>()
                {new (SkuId.A, 5), new (SkuId.B, 5), new (SkuId.C, 1), new (SkuId.D, 2)};
        }

        /// <summary>
        /// This unit test tests the promotion type 1: 2 of A's for 130
        /// After this promotion is applied, promotion price 130 is added to the total price.
        /// Number of SKU A units which should be payed individually is 5-3=2. 
        /// </summary>
        [Fact]
        public void PromotionType1Test()
        {
            _promotionType1.UpdateTotalPrice(_items, ref _priceWithPromotion);

            var skuIdA = _items.FirstOrDefault(i => i.SkuId == SkuId.A);
            Assert.Equal(skuIdA?.Number, 5 - 3);
            Assert.Equal(130, _priceWithPromotion);
        }

        /// <summary>
        /// This unit test tests the promotion type 1: 2 of B's for 45
        /// After this promotion is applied, promotion price 45+45 is added to the total price which is now 220.
        /// Number of SKU B units which should be paid individually is 5-4=1. 
        /// </summary>
        [Fact]
        public void PromotionType2Test()
        {
            _promotionType1.UpdateTotalPrice(_items, ref _priceWithPromotion);
            _promotionType2.UpdateTotalPrice(_items, ref _priceWithPromotion);

            var skuIdB = _items.FirstOrDefault(i => i.SkuId == SkuId.B);
            Assert.Equal(skuIdB?.Number, 5 - 4);
            Assert.Equal(220, _priceWithPromotion);
        }

        /// <summary>
        /// This unit test tests the promotion type 1*C + 1*D for 30
        /// After this promotion is applied, promotion price 30 is added to the total price which is now 250.
        /// Number of SKU C and D units which should be paid individually are 1-1=0 and 2-1=1. 
        /// </summary>
        [Fact]
        public void PromotionType3Test()
        {
            _promotionType1.UpdateTotalPrice(_items, ref _priceWithPromotion);
            _promotionType2.UpdateTotalPrice(_items, ref _priceWithPromotion);
            _promotionType3.UpdateTotalPrice(_items, ref _priceWithPromotion);

            var skuIdC = _items.FirstOrDefault(i => i.SkuId == SkuId.C);
            Assert.Equal(skuIdC?.Number, 1 - 1);

            var skuIdD = _items.FirstOrDefault(i => i.SkuId == SkuId.D);
            Assert.Equal(skuIdD?.Number, 2 - 1);

            Assert.Equal(250, _priceWithPromotion);
        }
    }
}
