namespace csharp
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void IncreaseQuality() {
            Quality++;
        }

        public void DecreasesQuality() {
            Quality--;
        }

        public bool IsANormalItem() {
            return  Name != "Aged Brie" || 
                    Name != "Backstage passes to a TAFKAL80ETC concert" ||
                    Name != "Sulfuras, Hand of Ragnaros";
        }
    }
}
