using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;

namespace csharp {
    [TestFixture]
    public class GildedRoseTest {
        private const int MaxQualityOfAnItem = 50;
        private const int SellIn = 10;
        private const int Quality = 10;

        [Test]
        public void sellIn_decreases() {
            var item = AnItemWith(SellIn, Quality, "foo");
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.SellIn.Should().Be(SellIn - 1);
        }

        [Test]
        public void Quality_decreases() {
            var item = AnItemWith(SellIn, Quality, "foo");
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(9);
        }

        [Test]
        public void Quality_decreased_twice_when_sellIn_has_passed() {
            const int noSellIn = 0;
            var item = AnItemWith(noSellIn, Quality, "foo");
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(8);
        }

        [Test]
        public void Quality_is_never_negative() {
            const int noQuality = 0;
            var item = AnItemWith(SellIn, noQuality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.SellIn.Should().Be(9);
            item.Quality.Should().Be(0);
        }

        [Test]
        public void AgeBrie_increases_quality_older_its_gets() {
            const int quality = 5;
            var item = AnAgedBrieItem(SellIn, quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.SellIn.Should().Be(9);
            item.Quality.Should().Be(6);
        }

        [Test]
        public void quality_is_never_more_than_50() {
            var item = AnAgedBrieItem(SellIn, MaxQualityOfAnItem);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(MaxQualityOfAnItem);
        }

        [Test]
        public void Sulfuras_never_has_to_be_sold() {
            var item = ASulfrurasItem(SellIn, Quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(Quality);
            item.SellIn.Should().Be(SellIn);
        }

        [Test]
        public void Backstage_passes_increases_quality_when_day_passes() {
            const int sellIn = 15;
            var item = ABackstagePasses(sellIn, Quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(Quality + 1);
            item.SellIn.Should().Be(sellIn - 1);
        }

        [Test]
        public void Backstage_passes_increases_double_quality_when_sell_in_day_ten_or_less() {
            const int sellIn = 10;
            var item = ABackstagePasses(sellIn, Quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(Quality + 2);
            item.SellIn.Should().Be(sellIn - 1);
        }

        [Test]
        public void Backstage_passes_increases_three_quality_when_sell_in_day_five_or_less() {
            const int sellIn = 5;
            var item = ABackstagePasses(sellIn, Quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(Quality + 3);
            item.SellIn.Should().Be(sellIn - 1);
        }

        [Test]
        public void Backstage_passes_drops_quality_to_zero_when_date_has_passed() {
            const int noSellIn = 0;
            var item = ABackstagePasses(noSellIn, Quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(0);
            item.SellIn.Should().Be(noSellIn - 1);
        }

        private BackstageItem ABackstagePasses(int sellIn, int quality) {
            return new BackstageItem {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = quality
            };
        }

        private SulfurasItem ASulfrurasItem(int sellIn, int quality) {
            return new SulfurasItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = quality};
        }

        private AgedBrieItem AnAgedBrieItem(int sellIn, int quality) {
            return new AgedBrieItem {Name = "Aged Brie", SellIn = sellIn, Quality = quality};
        }

        private GildedRose GivenAGildedRoseWith(GildedRoseItem item) {
            return new GildedRose(new List<GildedRoseItem> {item});
        }

        private NormalItem AnItemWith(int sellIn, int quality, string name = "foo") {
            return new NormalItem { Name = name, SellIn = sellIn, Quality = quality };
        }
    }
}
