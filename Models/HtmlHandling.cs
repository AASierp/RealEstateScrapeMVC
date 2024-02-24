using HtmlAgilityPack;
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

        public static string ParseHtmlDoc(HtmlDocument htmlDocument)
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

            string address = listingInfoTrimmed[0];
            string price = listingInfoTrimmed[1];
            string date = listingInfoTrimmed[2];
            string sqft = listingInfoTrimmed[3];
            string lot = listingInfoTrimmed[4];
            string description = listingInfoTrimmed[5];

            string targetWord = "Sq. Feet:";
            string pattern = $@"\b{Regex.Escape(targetWord)}\b(.+$)\b(.+?)\b(.+?)\b";

            string targetWord2 = "Lot Size:";
            string pattern2 = $@"\b{Regex.Escape(targetWord2)}\b(.+?)\b(.+?)\b(.+?)\b";

            Match match = Regex.Match(sqft, pattern);
            sqft = match.Groups[0].Value;

            Match match2 = Regex.Match(lot, pattern2);
            lot = match2.Groups[0].Value;

            string completeListing = (address + "\n" + price + "\n" + sqft + "\n" + lot + "\n" + date + "\n\n" + description + "\n\n");

            return completeListing;

        }
    }
}
