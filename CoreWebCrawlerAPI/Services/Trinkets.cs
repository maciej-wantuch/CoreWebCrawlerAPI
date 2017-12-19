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

        public bool DoesTrinketExist(int id)
        {
            return _trinket.Any(t => t.TrinketId == id);
        }

        public Trinket Find(int id)
        {
            return _trinket.FirstOrDefault(t => t.TrinketId == id);
        }

        public void Insert(Trinket item)
        {
            _trinket.Add(item);
        }

        public void Update(Trinket item)
        {
            var todoItem = this.Find(item.TrinketId);
            var index = _trinket.IndexOf(todoItem);
            _trinket.RemoveAt(index);
            _trinket.Insert(index, item);
        }

        public void Delete(int id)
        {
            _trinket.Remove(this.Find(id));
        }
    }
}
