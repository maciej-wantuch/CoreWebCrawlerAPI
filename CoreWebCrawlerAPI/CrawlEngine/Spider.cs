using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using CoreWebCrawlerAPI.SQLiteDB;
using HtmlAgilityPack;

namespace CoreWebCrawlerAPI.CrawlEngine
{
    public static class Spider
    {
        static readonly string url = "http://slist.amiami.com/top/search/list3?s_condition_flg=1&s_sortkey=preowned&pagemax=50&getcnt=0&pagecnt=";
        static readonly double maxItemsOnPage = 50;

        public static void GetContent()
        {
            int pageCount = (int)GetPageCount();

            for (int p = 1; p <= pageCount; p++)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(GetPage(p));

                HtmlNodeCollection productCollection = doc.DocumentNode.SelectNodes("//td[contains(@class, 'product_box')]");
                IEnumerable<HtmlNode> productNameCollection = productCollection.Select(c1 => c1.SelectSingleNode(".//li[contains(@class, 'product_name')]"));
                IEnumerable<HtmlNode> productLinkCollection = productCollection.Select(c1 => c1.SelectSingleNode(".//li[contains(@class, 'product_name')]/a"));
                IEnumerable<HtmlNode> productPriceCollection = productCollection.Select(c1 => c1.SelectSingleNode(".//li[contains(@class, 'product_price')]/text()[contains(., 'JPY')]"));
                IEnumerable<HtmlNode> productDiscountCollection = productCollection.Select(c1 => c1.SelectSingleNode(".//span[contains(@class, 'product_off')]"));

                int productsCount = productCollection.Count;

                string productName = string.Empty;
                string productLink = string.Empty;
                double productPrice;
                string productDiscount = string.Empty;

                for (int i = 0; i < productsCount; i++)
                {

                    productName = productNameCollection.ElementAt(i) != null ? productNameCollection.ElementAt(i).InnerText : string.Empty;
                    productLink = productLinkCollection.ElementAt(i) != null ? productLinkCollection.ElementAt(i).GetAttributeValue("href", string.Empty) : string.Empty;
                    productPrice = productPriceCollection.ElementAt(i) != null ? double.Parse(Regex.Replace(productPriceCollection.ElementAt(i).InnerText, @"\s|[^0-9,]", string.Empty)) : 0;
                    productDiscount = productDiscountCollection.ElementAt(i) != null ? productDiscountCollection.ElementAt(i).InnerText : string.Empty;

                    DataBase.WriteToDataBase(productName, productLink, productPrice, productDiscount);
                }
            }

        }

        static string GetPage(int page)
        {
            WebRequest myWebRequest;
            WebResponse myWebResponse;

            myWebRequest = WebRequest.Create(url + page);
            myWebResponse = myWebRequest.GetResponse();

            Stream streamResponse = myWebResponse.GetResponseStream();

            StreamReader sreader = new StreamReader(streamResponse ?? throw new ArgumentNullException($"404"));
            return sreader.ReadToEnd();
        }

        static double GetPageCount()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(GetPage(1));

            double itemCount = double.Parse(doc.DocumentNode.SelectSingleNode(".//p[contains(text(), 'items')]").InnerText.Remove(4));
            return Math.Ceiling(itemCount / maxItemsOnPage);
        }
    }
}