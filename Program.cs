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
            string ticker;
            do
            {
            Console.WriteLine("Enter the ticker to find its current price: ");
            ticker = Console.ReadLine();
            GetHtmlAsync(ticker);
            Console.ReadLine();
            } while(!ticker.Equals("q"));
        }

        private static async void GetHtmlAsync(string ticker)
        {
            string [] exchanges = {"NASDAQ", "NYSE"};
            foreach (string exchange in exchanges)
            {
                try
                {
                var url = $"https://www.google.com/finance/quote/{ticker}:{exchange}";
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(url);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
                var name = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='KY7mAb']").InnerText;
                var price = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='YMlKec fxKbKc']").InnerText;
                Console.WriteLine(name);
                Console.WriteLine(price);
                return;
                }
                catch (Exception)
                {

                }
            }
            Console.WriteLine("URL not found");
        }
    }
}
