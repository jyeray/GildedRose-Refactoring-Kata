using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;

namespace csharp {
    [TestFixture]
    public class GildedRoseTest {

        [Test]
        public void sellIn_decreases() {
            var item = new Item {Name = "foo", SellIn = 10, Quality = 10};
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.SellIn.Should().Be(9);
        }

        [Test]
        public void Quality_decreases() {
            var item = new Item { Name = "foo", SellIn = 10, Quality = 10 };
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(9);
        }

        [Test]
        public void Quality_decreased_twice_when_sellIn_has_passed() {
            var item = new Item { Name = "foo", SellIn = 0, Quality = 10 };
            var app = GivenAGildedRoseWith(item);

            app.UpdateQuality();

            item.Quality.Should().Be(8);
        }

        

        private GildedRose GivenAGildedRoseWith(Item item) {
            return new GildedRose(new List<Item> {item});
        }
    }
}
