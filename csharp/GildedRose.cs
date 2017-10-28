using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<GildedRoseItem> Items;
        public GildedRose(IList<GildedRoseItem> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++) {
                var item = Items[i];
                item.UpdateQuality();

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert") {
                        item.Quality = item.Quality - item.Quality;
                    }
                    if (item.IsANormalItem()) {
                        if (item.Quality > 0) {
                            item.Quality--;
                        }
                    }
                    if (item.Name == "Aged Brie")
                    {
                        if (item.Quality < 50) {
                            item.Quality++;
                        }
                    }
                }
            }
        }
    }
}
