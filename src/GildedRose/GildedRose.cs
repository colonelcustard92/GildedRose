using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private bool updateConjured(Item item)
        {
            if (item.Name.ToLower().Contains("conjured"))
            {
                item.Quality -= 2;
                item.SellIn -= 1;
                return true;
            }

            return false;

        }

        private void checkBackStagePasses(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 11)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }

                    if (item.SellIn < 6)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name == "Sulfuras" || item.Name == "Sulfuras, Hand of Ragnaros" || updateConjured(item)) continue;

                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Quality > 0) item.Quality -= 1;

                else checkBackStagePasses(item);

                item.SellIn -= 1;


                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    item.Quality -= 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }

                    if (Items[0].Quality < 0) Items[0].Quality = 0;
                }
            }
        }
    }
}
