using System.Collections.Generic;
using System.Linq;
using CoreWebCrawlerAPI.Interfaces;
using CoreWebCrawlerAPI.Models;
namespace CoreWebCrawlerAPI.Services
{
    public class Trinkets : ITrinkets
    {
        private List<Trinket> _trinket;

        public Trinkets()
        {
            InitializeData();
        }

        public IEnumerable<Trinkets> All
        {
            get { return _trinket; }
        }

        public bool DoesItemExist(string id)
        {
            return _trinket.Any(t => t.TrinketId == id);
        }

        public Trinket Find(string id)
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

        public void Delete(string id)
        {
            _trinket.Remove(this.Find(id));
        }

        private void InitializeData()
        {
            _trinket = new List<Trinket>();

            var trinket1 = new Trinket
            {
                TrinketId = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                ProductName = "Prod1",
                ProductLink = "http://prod1.html",
                ProductPrice = 16000,
                ProductDiscount = "5%",
                Done = true
            };

            var trinket2 = new Trinket
            {
                TrinketId = "6bb8a868-dba1-4f1a-93b7-24ebce87e244",
                ProductName = "Prod2",
                ProductLink = "http://prod2.html",
                ProductPrice = 17000,
                ProductDiscount = "10%",
                Done = true
            };

            var trinket3 = new Trinket
            {
                TrinketId = "6bb8a868-dba1-4f1a-93b7-24ebce87e245",
                ProductName = "Prod3",
                ProductLink = "http://prod3.html",
                ProductPrice = 18000,
                ProductDiscount = "15%",
                Done = true
            };
            _trinket.Add(trinket1);
            _trinket.Add(trinket2);
            _trinket.Add(trinket3);

        }
    }
}
