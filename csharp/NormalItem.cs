namespace csharp {
    public class NormalItem : GildedRoseItem {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void UpdateQuality() {
            if (this.Quality > 0) {
                this.DecreasesQuality();
            }
            if (SellIn < 0) {
                DecreasesQuality();
            }

        }
        public void DecreaseSellIn() {
            SellIn--;
        }

        public bool IsANormalItem() {
            return true;
        }

        private void DecreasesQuality() {
            Quality--;
        }
    }
}