using GildedRoseKata;

public class ConjureItemUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        item.Quality -= 2;
        item.SellIn -= 1;
    }
}

public class BackstagePassUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }

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

public class AgedBrieUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }
    }
}

public class RegularItemUpdater : IItemUpdater
{
    public void Update(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }
    }
}

