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

        public void UpdateQuality() {
            foreach (var item in Items) {
                item.DecreaseSellIn();
                item.UpdateQuality();
            }
        }
    }
}
