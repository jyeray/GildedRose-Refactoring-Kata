namespace csharp {
    public class AgedBrieItem: GildedRoseItem {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public void UpdateQuality() {
            if (this.Quality < 50) {
                this.IncreaseQuality();
            }
        }

        public bool IsANormalItem() {
            return false;
        }

        public void DecreaseSellIn() {
            SellIn--;
        }

        private void IncreaseQuality() {
            Quality++;
        }
    }
}