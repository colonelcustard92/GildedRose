using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private static GildedRose CreateGildedRose(IList<Item> items)
        {
            return new GildedRose(items);
        }

        [Theory]
        [InlineData(10, 10)]
        public void AgedBrie_QualityIncreasesAsItAges(int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };
            var app = CreateGildedRose(items);

            app.UpdateQuality();

            Assert.Equal(11, items[0].Quality);
            Assert.Equal(9, items[0].SellIn);
        }

        [Theory]
        [InlineData(0, 10)]
        public void ItemPastSellByDate_QualityDecreasesByTwo(int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = "Bread of Doom", SellIn = sellIn, Quality = quality } };
            var app = CreateGildedRose(items);

            app.UpdateQuality();

            Assert.Equal(8, items[0].Quality);
        }

        [Theory]
        [InlineData(0, -3)]
        public void QualityNeverLessThanZero(int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = "Bone of Death", SellIn = sellIn, Quality = quality } };
            var app = CreateGildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Theory]
        [InlineData(0, 50)]
        public void QualityNeverMoreThanFifty(int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = "Potion of Piffle", SellIn = sellIn, Quality = quality } };
            var app = CreateGildedRose(items);

            app.UpdateQuality();

            Assert.True(items[0].Quality <= 50);
        }

        [Fact]
        public void Sulfuras_NeverDecreasesInQualityNorSellIn()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras", SellIn = 20, Quality = 80 } };
            var app = CreateGildedRose(items);

            app.UpdateQuality();

            Assert.Equal(80, items[0].Quality);
            Assert.Equal(20, items[0].SellIn);
        }

        [Fact]
        public void BackstagePass_QualityIncreasesByTwoWhenSellInIsTenOrLess()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
            var app = CreateGildedRose(items);

            app.UpdateQuality();

            Assert.Equal(22, items[0].Quality);
        }

        [Fact]
        public void BackstagePass_QualityIncreasesByThreeWhenSellInIsFiveOrLess()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
            var app = CreateGildedRose(items);

            app.UpdateQuality();

            Assert.Equal(23, items[0].Quality);
        }

        [Fact]
        public void BackstagePass_QualityBecomesZeroAfterSellInDate()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            var app = CreateGildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Theory]
        [InlineData(2, 5)]
        [InlineData(0, 4)]
        [InlineData(1, 3)]
        public void SellInReducesByOneEachDay(int sellIn, int quality)
        {
            var items = new List<Item> { new Item { Name = "Sausage", SellIn = sellIn, Quality = quality } };
            var app = CreateGildedRose(items);

            int initialSellIn = items[0].SellIn;
            app.UpdateQuality();

            // Assert: Ensure SellIn decreases by 1 each day
            Assert.Equal(initialSellIn - 1, items[0].SellIn);
        }
    }
}
