using DataAccessLayer;
using HtmlAgilityPack;
using RES.DAL.Entities;



namespace Scraper
{
    public class Scraper : IScraper
    {
        public List<string> CompleteUrl(List<string> countyList)
        {
            List<string> completeCountyUrl = new List<string>();

            int pageSize = 3;

            foreach (var county in countyList)
            {
                for (int pageNum = 1; pageNum <= pageSize; pageNum++)
                {

                    string countyUrl = $"https://www.joehaydenrealtor.com/{county}-county-ky/?pg={pageNum}";

                    completeCountyUrl.Add(countyUrl);

                }
            }

            return completeCountyUrl;
        }
        public async Task<List<string>> ScrapeListingUrls(List<string> completeCountyUrl)
        {
            HtmlHandling htmlHandling = new HtmlHandling();

            List<string> allListingUrls = new List<string>();

            foreach (string county in completeCountyUrl)
            {
                string htmlContent = await ClientRequest.MakeHttpRequestAsync(county);

                HtmlDocument htmlDocument = htmlHandling.CreateHtmlDoc(htmlContent);

                List<string> listingUrls = htmlHandling.ParseHtmlForListingUrls(htmlDocument);

                allListingUrls.AddRange(listingUrls);              
            }

            return allListingUrls;
        }

        public async Task ScrapeListingInfo(List<string> allListingUrls)
        {
            HtmlHandling htmlHandling = new HtmlHandling();

            using (PropertyContext propertyContext = new PropertyContext())

            {
                foreach (string listingUrl in allListingUrls)
                {
                    string htmlContent = await ClientRequest.MakeHttpRequestAsync(listingUrl);

                    HtmlDocument htmlDocument = htmlHandling.CreateHtmlDoc(htmlContent);

                    PropertyModel propertyModel = htmlHandling.ParseIndividualListingInfo(htmlDocument);

                    Console.WriteLine(propertyModel.Address);

                    var existingEntry = propertyContext.PropertyModels.Any(x => x.Url == listingUrl);

                    if (!existingEntry)
                    {
                        propertyContext.PropertyModels.Add(propertyModel);
                    }

                    await propertyContext.SaveChangesAsync();
                }             
            }
        }
    }
}
