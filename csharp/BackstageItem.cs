namespace csharp {
    public class BackstageItem : GildedRoseItem{
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public void UpdateQuality() {
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

        public bool IsANormalItem() {
            return false;
        }

        private void IncreaseQuality() {
            Quality++;
        }
    }
}