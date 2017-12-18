using System.Collections.Generic;
using CoreWebCrawlerAPI.Models;
using CoreWebCrawlerAPI.SQLiteDB;

namespace CoreWebCrawlerAPI.Interfaces
{
    public interface ITrinkets
    {
        bool DoesTrinketExist(int id);

        List<Trinket> All { get; }

        Trinket Find(int id);

        void Insert(Trinket trinket);

        void Update(Trinket trinked);

        void Delete(int id);
    }
}
