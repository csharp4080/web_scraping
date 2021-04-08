using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace daeyo
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHtmlAsync();

        }

        private static async void GetHtmlAsync()
        {
            var url = "https://finance.yahoo.com/quote/AAPL/";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            
        }
    }
}
