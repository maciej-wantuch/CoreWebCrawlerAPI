using System;
using System.IO;
using System.Linq;

namespace CoreWebCrawlerAPI.SQLiteDB
{
    public static class DataBase
    {
        public static void SeedDataBase()
        {
            using (var db = new DataBaseTrinketsContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public static void WriteToDataBase(string productName, string productLink, double productPrice, string productDiscount)
        {
            using (var db = new DataBaseTrinketsContext())
            {
                db.TrinketsDataBase.Add(new DataBaseTrinket { ProductName = productName, ProductLink = productLink, ProductPrice = productPrice, ProductDiscount = productDiscount });
                db.SaveChanges();
            }
        }

        public static void ReadFromDataBase()
        {
            using (var db = new DataBaseTrinketsContext())
            {
                foreach (var t in db.TrinketsDataBase)
                    Console.WriteLine(string.Format("Name: {0, -230} Price: JPY {1, -15:N} Discount: {2, -15}", t.ProductName, t.ProductPrice, t.ProductDiscount));
            }
        }

        public static void ReadFromDataBaseFiltered()
        {
            using (var db = new DataBaseTrinketsContext())
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
