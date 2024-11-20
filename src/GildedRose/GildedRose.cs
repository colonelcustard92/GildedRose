using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private IList<Item> Items;
        private Dictionary<string, IItemUpdater> _itemUpdaters;

        public GildedRose(IList<Item> items)
        {
            Items = items;
            _itemUpdaters = new Dictionary<string, IItemUpdater>
        {
            { "Conjured", new ConjureItemUpdater() },
            { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassUpdater() },
            { "Aged Brie", new AgedBrieUpdater() }
        };
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                IItemUpdater updater;

                // If item is Sulfuras, skip it (no update logic)
                if (item.Name == "Sulfuras" || item.Name == "Sulfuras, Hand of Ragnaros") continue;

                // Handle specific item types using the correct updater
                if (_itemUpdaters.ContainsKey(item.Name))
                {
                    updater = _itemUpdaters[item.Name];
                }
                else
                {
                    // Default to regular item logic if no special updater is found
                    updater = new RegularItemUpdater();
                }

                // Update the item
                updater.Update(item);

                // Decrease sellIn for all items
                item.SellIn -= 1;

                // Handle post-sellIn expiration logic
                if (item.SellIn < 0)
                {
                    // If item is Aged Brie or Backstage passes, increase quality more
                    if (item.Name == "Aged Brie" && item.Quality < 50)
                    {
                        item.Quality += 1;
                    }

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        item.Quality = 0; // Quality becomes 0 after the event
                    }
                    else if (item.Quality > 0)
                    {
                        item.Quality -= 1;
                    }
                }

                // Ensure quality does not go below 0
                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }

}
