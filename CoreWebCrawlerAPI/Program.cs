using System.IO;
using CoreWebCrawlerAPI.CrawlEngine;
using CoreWebCrawlerAPI.SQLiteDB;
using Microsoft.AspNetCore.Hosting;

namespace CoreWebCrawlerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://*:5000")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            
            host.Run();

        }
    }
}
