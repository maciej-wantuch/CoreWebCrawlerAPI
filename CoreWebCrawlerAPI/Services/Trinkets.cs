using System.Collections.Generic;
using System.Linq;
using CoreWebCrawlerAPI.CrawlEngine;
using CoreWebCrawlerAPI.Interfaces;
using CoreWebCrawlerAPI.Models;
using CoreWebCrawlerAPI.SQLiteDB;

namespace CoreWebCrawlerAPI.Services
{
    public class Trinkets : ITrinkets
    {
        List<Trinket> _trinket;

        public Trinkets()
        {
            //TODO First request DB seed

            //DataBase.SeedDataBase();

            //Spider.GetContent();

            _trinket = DataBase.readFromDataBaseToList();
        }

        public List<Trinket> All
        {
            get { return _trinket; }
        }

        public List<Trinket> Search()
        {
            return _trinket.FindAll(t => t.ProductName.Contains("Bunny"));
        }

    }
}
