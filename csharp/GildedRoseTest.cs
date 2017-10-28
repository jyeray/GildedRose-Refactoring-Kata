using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;

namespace csharp {
    [TestFixture]
    public class GildedRoseTest {

        [Test]
        public void sellIn_decreases() {
            const int sellIn = 10;
            const int quality = 10;
            var item = AnItemWith(sellIn, quality, "foo");
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.SellIn.Should().Be(9);
        }

        [Test]
        public void Quality_decreases() {
            const int sellIn = 10;
            const int quality = 10;
            var item = AnItemWith(sellIn, quality, "foo");
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(9);
        }

        [Test]
        public void Quality_decreased_twice_when_sellIn_has_passed() {
            const int sellIn = 0;
            const int quality = 10;
            var item = AnItemWith(sellIn, quality, "foo");
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(8);
        }

        [Test]
        public void Quality_is_never_negative() {
            const int sellIn = 10;
            const int quality = 0;
            var item = AnItemWith(sellIn, quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.SellIn.Should().Be(9);
            item.Quality.Should().Be(0);
        }

        [Test]
        public void AgeBrie_increases_quality_older_its_gets() {
            const int sellIn = 10;
            const int quality = 5;
            var item = AnAgedBrieItem(sellIn, quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.SellIn.Should().Be(9);
            item.Quality.Should().Be(6);
        }

        [Test]
        public void quality_is_never_more_than_50() {
            const int sellIn = 10;
            const int maxQualityOfAnItem = 50;
            var item = AnAgedBrieItem(sellIn, maxQualityOfAnItem);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(maxQualityOfAnItem);
        }

        [Test]
        public void Sulfuras_never_has_to_be_sold() {
            const int sellIn = 10;
            const int quality = 20;
            var item = ASulfrurasItem(sellIn, quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(quality);
            item.SellIn.Should().Be(sellIn);
        }

        [Test]
        public void Backstage_passes_increases_quality_when_day_passes() {
            const int sellIn = 15;
            const int quality = 20;
            var item = ABackstagePasses(sellIn, quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(quality + 1);
            item.SellIn.Should().Be(sellIn - 1);
        }

        private Item ABackstagePasses(int sellIn, int quality) {
            return AnItemWith(sellIn, quality, "Backstage passes to a TAFKAL80ETC concert");
        }

        private Item ASulfrurasItem(int sellIn, int quality) {
            return AnItemWith(sellIn, quality, "Sulfuras, Hand of Ragnaros");
        }

        private Item AnAgedBrieItem(int sellIn, int quality) {
            return AnItemWith(sellIn, quality,"Aged Brie");
        }

        private GildedRose GivenAGildedRoseWith(Item item) {
            return new GildedRose(new List<Item> {item});
        }

        private Item AnItemWith(int sellIn, int quality, string name = "foo") {
            return new Item { Name = name, SellIn = sellIn, Quality = quality };
        }
    }
}
