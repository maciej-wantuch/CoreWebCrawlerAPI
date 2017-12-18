using CoreWebCrawlerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreWebCrawlerAPI.SQLiteDB
{
    public class TrinketsContext : DbContext
    {
        public DbSet<Trinket> TrinketsDataBase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.sqlite");
        }
    }
}
