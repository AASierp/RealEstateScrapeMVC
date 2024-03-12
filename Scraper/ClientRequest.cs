﻿using HtmlAgilityPack;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Scraper
{
    public class ClientRequest
    {
        private static readonly string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36";

        public static async Task<string> MakeHttpRequestAsync(string url)
        {   
            Random rand = new Random();

            int randomDelayMiliseconds = rand.Next(100, 1000);

            await Task.Delay(randomDelayMiliseconds);
            
            using HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);

            HttpResponseMessage httpResponse = await httpClient.GetAsync(url);

            string htmlContent = await httpResponse.Content.ReadAsStringAsync();

            return htmlContent;
        }       
    }
}
