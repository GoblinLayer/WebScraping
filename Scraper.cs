using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Windows.UI.Xaml.Controls;
using System.Net.Http;

namespace WebScraping
{
    public class Scraper
    {
        private ObservableCollection<string> entradas;

        public ObservableCollection<string> entradaOBJ
        {
            get { return entradas; }
            set { entradas = value; }
        }

        public async Task Crawling()
        {
            AnimeContext a = new AnimeContext();

            var url = "https://www.anitube.site";

            List<Anime> listanimes = new List<Anime>();

            var client = new HttpClient();

            var html = await client.GetStringAsync(url);

            var htmldoc = new HtmlDocument();

            htmldoc.LoadHtml(html);

            var divs = htmldoc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("epiItem")).ToList();
            
            foreach (var div in divs)
            {
                var link = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;

                var name = div.Descendants("a").FirstOrDefault().ChildAttributes("title").FirstOrDefault().Value;

                //var source = div.Descendants("a").FirstOrDefault().ChildAttributes("div").FirstOrDefault().Value;

                var anime = new Anime(name, link);
                a.animes.Add(anime);
            }
            a.SaveChanges();
        }
    }
}
