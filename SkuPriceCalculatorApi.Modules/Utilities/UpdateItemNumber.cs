using System.Collections.Generic;
using SkuPriceCalculatorApi.Models;

namespace SkuPriceCalculatorApi.Modules.Utilities
{
    public static class UpdateItemNumber //: IUpdateItemNumber
    {
        /// <summary>
        /// This method update number of the items after promotions are applied 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="numberMin"></param>
        /// <param name="replaceItem"></param>
        public static void Update(List<Item> items, int numberMin, Item replaceItem)
        {
            var index = items.IndexOf(replaceItem);

            if (index != -1)
                items[index] = new Item(replaceItem.SkuId, replaceItem.Number - numberMin);
        }
    }
}
