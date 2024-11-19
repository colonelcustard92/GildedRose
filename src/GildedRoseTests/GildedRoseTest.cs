using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData(10,10)]
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
    }
}

