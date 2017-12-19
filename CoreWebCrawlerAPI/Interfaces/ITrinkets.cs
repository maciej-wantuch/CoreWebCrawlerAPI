using System.Collections.Generic;
using CoreWebCrawlerAPI.Models;
using CoreWebCrawlerAPI.SQLiteDB;

namespace CoreWebCrawlerAPI.Interfaces
{
    public interface ITrinkets
    {
        List<Trinket> All { get; }

        List<Trinket> Search();
    }
}
