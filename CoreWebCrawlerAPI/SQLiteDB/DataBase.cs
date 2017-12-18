using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CoreWebCrawlerAPI.Models;

namespace CoreWebCrawlerAPI.SQLiteDB
{
    public static class DataBase
    {
        public static void SeedDataBase()
        {
            using (var db = new TrinketsContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public static void WriteToDataBase(string productName, string productLink, double productPrice, string productDiscount)
        {
            using (var db = new TrinketsContext())
            {
                db.TrinketsDataBase.Add(new Trinket() { ProductName = productName, ProductLink = productLink, ProductPrice = productPrice, ProductDiscount = productDiscount });
                db.SaveChanges();
            }
        }

        public static List<Trinket> readFromDataBaseToList()
        {
            using (var db = new TrinketsContext())
            {
                return db.TrinketsDataBase.ToList();
            }
        }

        public static void ReadFromDataBase()
        {
            using (var db = new TrinketsContext())
            {
                foreach (var t in db.TrinketsDataBase)
                    Console.WriteLine(string.Format("Name: {0, -230} Price: JPY {1, -15:N} Discount: {2, -15}", t.ProductName, t.ProductPrice, t.ProductDiscount));
            }
        }

        public static void ReadFromDataBaseFiltered()
        {
            using (var db = new TrinketsContext())
            {
                var trinkets = db.TrinketsDataBase.Where(b => b.ProductName.Contains("Bunny"));
                foreach (var t in trinkets)
                    Console.WriteLine(string.Format("Name: {0, -230} Price: JPY {1, -15:N} Discount: {2, -15}", t.ProductName, t.ProductPrice, t.ProductDiscount));
            }
        }

        public static void DeleteDataBase()
        {
            File.Delete("db.sqlite");
        }
    }
}
