namespace csharp {
    public class AgedBrieItem: GildedRoseItem {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void RecalculateQuality() {
            if (this.Quality < 50) {
                this.IncreaseQuality();
            }
        }

        public void DecreaseSellIn() {
            SellIn--;
        }

        private void IncreaseQuality() {
            Quality++;
        }
    }
}