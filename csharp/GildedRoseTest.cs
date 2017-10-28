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
            var item = AnItemWith(sellIn, quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.SellIn.Should().Be(9);
        }

        [Test]
        public void Quality_decreases() {
            const int sellIn = 10;
            const int quality = 10;
            var item = AnItemWith(sellIn, quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(9);
        }

        [Test]
        public void Quality_decreased_twice_when_sellIn_has_passed() {
            const int sellIn = 0;
            const int quality = 10;
            var item = AnItemWith(sellIn, quality);
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(8);
        }

        private GildedRose GivenAGildedRoseWith(Item item) {
            return new GildedRose(new List<Item> {item});
        }

        private Item AnItemWith(int sellIn, int quality) {
            return new Item { Name = "foo", SellIn = sellIn, Quality = quality };
        }
    }
}
