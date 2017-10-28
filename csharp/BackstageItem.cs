namespace csharp {
    public class BackstageItem : GildedRoseItem{
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void RecalculateQuality() {
            if (DateHavePassed()) {
                DropQuality();
                return;
            }
            if (FiveDaysOrLess()) {
                IncreaseQualityTriple();
                return;
            }
            if (TenDaysOrLessForConcert()) {
                IncreaseQualityTwice();
                return;
            }
           IncreaseQuality();
        }

        private void IncreaseQualityTriple() {
            this.IncreaseQuality();
            this.IncreaseQuality();
            this.IncreaseQuality();
        }

        private bool FiveDaysOrLess() {
            return this.SellIn < 6;
        }

        private void IncreaseQualityTwice() {
            this.IncreaseQuality();
            this.IncreaseQuality();
        }

        private bool TenDaysOrLessForConcert() {
            return this.SellIn < 11;
        }

        private void DropQuality() {
            Quality = 0;
        }

        private bool DateHavePassed() {
            return SellIn < 0;
        }

        public void DecreaseSellIn() {
            SellIn--;
        }

        private void IncreaseQuality() {
            if (Quality < 50) {
                Quality++;
            }
        }
    }
}