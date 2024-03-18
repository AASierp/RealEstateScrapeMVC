using HtmlAgilityPack;
using RES.DAL.Entities;



namespace Scraper
{
    internal interface IHtmlHandling
    {
        public HtmlDocument CreateHtmlDoc(string content);

        public List<string> ParseHtmlForListingUrls(HtmlDocument htmlDocument);

        public PropertyModel ParseIndividualListingInfo(HtmlDocument htmlDocument);

    }
}
