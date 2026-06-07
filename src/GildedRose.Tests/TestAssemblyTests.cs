using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests;

public class TestAssemblyTests
{
    [Fact]
    public void Normal_Item_Degrades_By_One()
    {
        var app = new Program
        {
            Items = new List<Item>
            {
                new Item
                {
                    Name = "Normal Item",
                    SellIn = 10,
                    Quality = 20
                }
            }
        };

        app.UpdateQuality();

        Assert.Equal(19, app.Items[0].Quality);
        Assert.Equal(9, app.Items[0].SellIn);
    }

    [Fact]
    public void Aged_Brie_Increases_In_Quality()
    {
        var app = new Program
        {
            Items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 2,
                    Quality = 0
                }
            }
        };

        app.UpdateQuality();

        Assert.Equal(1, app.Items[0].Quality);
    }

    [Fact]
    public void Sulfuras_Never_Changes()
    {
        var app = new Program
        {
            Items = new List<Item>
            {
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 0,
                    Quality = 80
                }
            }
        };

        app.UpdateQuality();

        Assert.Equal(80, app.Items[0].Quality);
        Assert.Equal(0, app.Items[0].SellIn);
    }

    [Fact]
    public void Conjured_Items_Degrade_Twice_As_Fast()
    {
        var app = new Program
        {
            Items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 3,
                    Quality = 6
                }
            }
        };

        app.UpdateQuality();

        Assert.Equal(4, app.Items[0].Quality);
        Assert.Equal(2, app.Items[0].SellIn);
    }

    [Fact]
    public void Expired_Conjured_Items_Degrade_By_Four()
    {
        var app = new Program
        {
            Items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 0,
                    Quality = 10
                }
            }
        };

        app.UpdateQuality();

        Assert.Equal(6, app.Items[0].Quality);
    }

    [Fact]
    public void Quality_Never_Negative()
    {
        var app = new Program
        {
            Items = new List<Item>
            {
                new Item
                {
                    Name = "Normal Item",
                    SellIn = 5,
                    Quality = 0
                }
            }
        };

        app.UpdateQuality();

        Assert.Equal(0, app.Items[0].Quality);
    }

    [Fact]
    public void Backstage_Passes_Drop_To_Zero_After_Concert()
    {
        var app = new Program
        {
            Items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 20
                }
            }
        };

        app.UpdateQuality();

        Assert.Equal(0, app.Items[0].Quality);
    }

    [Fact]
    public void Quality_Never_Exceeds_Fifty()
    {
        var app = new Program
        {
            Items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 2,
                    Quality = 50
                }
            }
        };

        app.UpdateQuality();

        Assert.Equal(50, app.Items[0].Quality);
    }
}