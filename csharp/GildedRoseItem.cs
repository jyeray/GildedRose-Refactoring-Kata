namespace csharp {
    public interface GildedRoseItem {
        string Name { get; set; }
        int SellIn { get; set; }
        int Quality { get; set; }
        void UpdateQuality();
        bool IsANormalItem();
    }
}