using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace ClassLibrary1
{
    public class NewsItem
    {
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? Date { get; set; }
        public string Title { get; set; }
    }
    public class ScoopManager
    {
        public List<NewsItem> ScrapeLS()
        {
            var html = GetScoopHtml();
            return GetItems(html);
        }
        public string GetScoopHtml()
        {
            var assembly = typeof(ScoopManager).Assembly;
            Stream resource = assembly.GetManifestResourceStream("ClassLibrary1.scoophtml.html");
            using (var reader = new StreamReader(resource))
            {
                return reader.ReadToEnd();
            }
        }
        public List<NewsItem> GetItems(string html)
        {
            var parser = new HtmlParser();
            IHtmlDocument document = parser.ParseDocument(html);
            var itemDivs = document.QuerySelectorAll(".post");
            List<NewsItem> items = new List<NewsItem>();
            foreach(var div in itemDivs)
            {
                NewsItem item = new NewsItem();
                var href = div.QuerySelectorAll("h2 a").First();
                item.Title = href.TextContent.Trim();
                item.Url = href.Attributes["href"].Value;
                var image = div.QuerySelector("img");
                item.ImageUrl = image.Attributes["src"].Value;
                var date = div.QuerySelector("small");
                if(!string.IsNullOrEmpty(date.TextContent))
                {
                    item.Date = DateTime.Parse(date.TextContent.Trim());
                }
                else
                {
                    item.Date = null;
                }
               
                items.Add(item);
            }
            return items;
        }
    }
}
