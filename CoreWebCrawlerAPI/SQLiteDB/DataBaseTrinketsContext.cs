using Microsoft.EntityFrameworkCore;

namespace CoreWebCrawlerAPI.SQLiteDB
{
    public class DataBaseTrinketsContext : DbContext
    {
        public DbSet<DataBaseTrinket> TrinketsDataBase { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.sqlite");
        }
    }
}
