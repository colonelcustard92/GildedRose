using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData(10, 10)]
        public void Aged_Brie_Increases_In_Quality_With_Age(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(11, Items[0].Quality);
            Assert.Equal(9, Items[0].SellIn);
        }


        [Theory]
        [InlineData(0, 10)]
        public void Given_Item_Is_Past_Sellby_Date_Quality_Degrades_By_Double(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Bread of Doom", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(8, Items[0].Quality);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, 0)]
        public void Quality_Should_Never_Be_Less_Than_Zero(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Bone of Death", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
        [Theory]
        [InlineData(0, 50)]

        public void Quality_Should_Never_Be_More_Than_50(int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Potion of Piffle", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.True(Items[0].Quality <= 50);
        }

        [Fact]
        public void Sulfuras_Never_Decreases_In_Quality_Nor_Has_To_Be_Sold()
        {
            IList<Item> Items = new List<Item> { new Item { Name ="Sulfuras", SellIn = 20, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(80,Items[0].Quality);
            Assert.Equal(20,Items[0].SellIn);

        }

        [Fact]
        public void Backstage_Pass_Increases_In_Quality_By_2_Given_10_Or_Less_Days()
        { 
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20} };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(22, Items[0].Quality);
        }

        [Fact]
        public void Backstage_Pass_Increases_In_Quality_By_3_Given_5_Or_Less_Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(23, Items[0].Quality);
        }

        [Fact]
        public void Backstage_Pass_Quality_Goes_To_0_If_Sellin_is_0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void Conjured_Item_Degrades_Twice_As_Fast_As_A_Normal_Item()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Sausage", SellIn = 10, Quality = 18 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(16, Items[0].Quality);
        }

    }
}

