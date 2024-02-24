/*using HtmlAgilityPack;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace RealEstateScrapeMVC.Models
{
    public class ClientRequest
    {
        private static readonly string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36";

        public static async Task<string> MakeHttpRequestAsync(string link)
        {
           
            string completeLink = $"https://www.joehaydenrealtor.com/{link}-county-ky/";

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);

            HttpResponseMessage httpResponse = await httpClient.GetAsync(completeLink);

            string htmlContent = await httpResponse.Content.ReadAsStringAsync();

            return htmlContent;
        }        
    }
}*/
