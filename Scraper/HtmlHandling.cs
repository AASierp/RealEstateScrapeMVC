﻿using HtmlAgilityPack;
using RES.DAL.Entities;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Scraper
{
    public class HtmlHandling<T> : IHtmlHandling
    {
        public HtmlDocument CreateHtmlDoc(string htmlContent)
        {
            HtmlDocument htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(htmlContent);

            return htmlDocument;
        }

        public List<string> ParseHtmlForListingUrls(HtmlDocument htmlDocument)
        {

            //Selects nodes by Tag from HTML doc and adds them to a node list (in this case all the URLs).
            HtmlNodeCollection allPageLinks = htmlDocument.DocumentNode.SelectNodes("//div[@data-url]");

            //Isolates actual tag Value
            List<string> homeListingLinks = allPageLinks.Select(link => link.Attributes["data-url"].Value).ToList();

            //concatenates url to make a usable link.
            List<string> allListingUrls = homeListingLinks.Select(link => "https://www.joehaydenrealtor.com" + link).ToList();

            return allListingUrls;
        }

        public PropertyModel ParseIndividualListingInfo(HtmlDocument htmlDocument)
        {
            List<HtmlNode> propertyInfoNodes = new List<HtmlNode>
        {
            htmlDocument.DocumentNode.SelectSingleNode("//div[@class='address']"),
            htmlDocument.DocumentNode.SelectSingleNode("//span[@class='si-ld-top__price']"),
            htmlDocument.DocumentNode.SelectSingleNode("//div[@class='si-idx-disclaimer']"),
            htmlDocument.DocumentNode.SelectSingleNode("//div[@class='si-ld-primary__info clearfix']"),
            htmlDocument.DocumentNode.SelectSingleNode("//div[@class='si-ld-primary__info clearfix']"),
            htmlDocument.DocumentNode.SelectSingleNode("//div[@class='si-ld-description js-listing-description']"),
            htmlDocument.DocumentNode.SelectSingleNode("//div[@class='si-ld-primary__info clearfix']")
        };

            PropertyModel propertyModel = new PropertyModel();

            List<string> listingInfoTrimmed = new List<string>();

            foreach (HtmlNode node in propertyInfoNodes)
            {
                if (node != null)
                {
                    listingInfoTrimmed.Add(node.InnerText.Trim());
                }
            }

            if (listingInfoTrimmed.Count >= 7)
            {
                propertyModel.Address = listingInfoTrimmed[0];
                string price = listingInfoTrimmed[1];
                propertyModel.DateListed = listingInfoTrimmed[2];
                string sqft = listingInfoTrimmed[3];
                string lot = listingInfoTrimmed[4];
                propertyModel.Description = listingInfoTrimmed[5];
                string county = listingInfoTrimmed[6];

                string priceNoComma;
                string priceNoDollar;

                if (!string.IsNullOrEmpty(price))
                {
                    priceNoComma = price.Replace(",", "");
                    priceNoDollar = priceNoComma.Replace("$", "");

                    if (int.TryParse(priceNoDollar, out int priceRaw))
                    {
                        propertyModel.Price = priceRaw;
                    }
                    else
                    {
                        propertyModel.Price = 0;
                    }
                }

                HtmlNode urlNode = htmlDocument.DocumentNode.SelectSingleNode("//link[@rel='canonical']");
                string url = urlNode.GetAttributeValue("href", "");

                propertyModel.Url = url;

                string targetWord = "Sq. Feet:";
                string pattern = $@"{Regex.Escape(targetWord)}\s*([^\s]+)";

                string targetWord2 = "Lot Size:";
                string pattern2 = $@"\b{Regex.Escape(targetWord2)}\s*([^\s]+)";

                string targetWord3 = "County:";
                string pattern3 = $@"{Regex.Escape(targetWord3)}\s*([^\s]+)";

                Match match = Regex.Match(sqft, pattern);
                sqft = match.Groups[1].Value;

                Match match2 = Regex.Match(lot, pattern2);
                lot = match2.Groups[1].Value;

                Match match3 = Regex.Match(county, pattern3);
                county = match3.Groups[1].Value;

                if (double.TryParse(lot, out double lotDouble))
                {
                    propertyModel.LotSize = lotDouble;
                }
                else
                {
                    propertyModel.LotSize = 0;
                }

                string sqftNoComma;

                if (!string.IsNullOrEmpty(sqft))
                {
                    sqftNoComma = sqft.Replace(",", "");

                    if (int.TryParse(sqftNoComma, out int sqftInt))
                    {
                        propertyModel.SquareFeet = sqftInt;
                    }
                }
                else
                {
                    propertyModel.SquareFeet = 0;
                }

                propertyModel.County = county;
                propertyModel.Url = url;
            }
            return propertyModel;
        }
    }
}
