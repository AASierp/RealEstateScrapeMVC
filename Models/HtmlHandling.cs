using HtmlAgilityPack;
using NuGet.Protocol.Core.Types;
using System.Net.Http;
using System.Text.RegularExpressions;


namespace RealEstateScrapeMVC.Models
{
    public class HtmlHandling
    {
        public static HtmlDocument CreateHtmlDoc(string htmlContent)
        {
            HtmlDocument htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(htmlContent);

            return htmlDocument;
        }

        public static List<string> ParseHtmlForListingUrls(HtmlDocument htmlDocument) 
        {
            //Selects nodes by Tag from HTML doc and adds them to a node list (in this case all the URLs).
            HtmlNodeCollection allPageLinks = htmlDocument.DocumentNode.SelectNodes("//div[@data-url]");

            //Isolates actual tag Value
            List<string> homeListingLinks = allPageLinks.Select(link => link.Attributes["data-url"].Value).ToList();

            //Takes top 10 listing links and concatenates them to produce a usable link.
            List<string> allListingUrls = homeListingLinks.Select(link => "https://www.joehaydenrealtor.com" + link).ToList();

            return allListingUrls;
        }

        public static PropertyModel ParseIndividualListingInfo(HtmlDocument htmlDocument)
        {
            List<HtmlNode> propertyInfoNodes = new List<HtmlNode>
        {
            htmlDocument.DocumentNode.SelectSingleNode("//div[@class='address']"),
            htmlDocument.DocumentNode.SelectSingleNode("//span[@class='si-ld-top__price']"),
            htmlDocument.DocumentNode.SelectSingleNode("//div[@class='si-idx-disclaimer']"),
            htmlDocument.DocumentNode.SelectSingleNode("//div[@class='si-ld-primary__info clearfix']"),
            htmlDocument.DocumentNode.SelectSingleNode("//div[@class='si-ld-primary__info clearfix']"),
            htmlDocument.DocumentNode.SelectSingleNode("//div[@class='si-ld-description js-listing-description']"),
        };

            List<string> listingInfoTrimmed = new List<string>();

            foreach (HtmlNode node in propertyInfoNodes)
            {
                listingInfoTrimmed.Add(node.InnerText.Trim());
            }

            PropertyModel propertyModel = new PropertyModel();

            propertyModel.Address = listingInfoTrimmed[0];
            propertyModel.Price = int.Parse(listingInfoTrimmed[1]);
            propertyModel.DateListed = listingInfoTrimmed[2];
            string sqft = listingInfoTrimmed[3];
            string lot = listingInfoTrimmed[4];
            propertyModel.Description = listingInfoTrimmed[5];

            string targetWord = "Sq. Feet:";
            string pattern = $@"{Regex.Escape(targetWord)}\s*([^\s]+)";

            string targetWord2 = "Lot Size:";
            string pattern2 = $@"\b{Regex.Escape(targetWord2)}\b(.+?)\b(.+?)\b(.+?)\b";

            Match match = Regex.Match(sqft, pattern);
            sqft = match.Groups[0].Value;

            Match match2 = Regex.Match(lot, pattern2);
            lot = match2.Groups[0].Value;

            propertyModel.SquareFeet = int.Parse(sqft);
            propertyModel.LotSize = int.Parse(lot);

            return propertyModel;

        }
    }
}
