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
            return  Name != "Aged Brie" &&
                    Name != "Backstage passes to a TAFKAL80ETC concert" &&
                    Name != "Sulfuras, Hand of Ragnaros";
        }

        public void OneDayMore() {
            if (this.IsANormalItem()) {
                if (this.Quality > 0) {
                    this.DecreasesQuality();
                }
            }
            if (this.Name == "Aged Brie") {
                if (this.Quality < 50) {
                    this.IncreaseQuality();
                }
            }
            if (this.Name == "Backstage passes to a TAFKAL80ETC concert") {
                if (this.Quality < 50) {
                    this.IncreaseQuality();
                    if (this.SellIn < 11) {
                        if (this.Quality < 50) {
                            this.IncreaseQuality();
                        }
                    }

                    if (this.SellIn < 6) {
                        if (this.Quality < 50) {
                            this.IncreaseQuality();
                        }
                    }
                }
            }
        }
    }
}
