namespace csharp {
    public class SulfurasItem:GildedRoseItem {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public void UpdateQuality() {
            
        }

        public bool IsANormalItem() {
            return false;
        }
    }
}