using DataAccessLayer;
using HtmlAgilityPack;
using RES.DAL.Entities;



namespace Scraper
{

	// This class follows Single Responsibility Principle (SRP) by focusing on one responsibility:
	// scraping real estate data. It implements IScraper for abstraction.
	public class Scraper : IScraper
    {

		// This method follows Open/Closed Principle (OCP) as it can be extended easily by adding more counties
		// without modifying the existing code. It takes a list of county names and constructs URLs to scrape data.
		// It doesn't need modification for changes like adding more counties.
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

		// This method follows Dependency Inversion Principle (DIP) by depending on abstractions (interfaces)
		// rather than concrete implementations. It accepts a list of URLs to scrape, regardless of how those URLs
		// are obtained or what kind of HTML handling or HTTP client is used.
		public async Task<List<string>> ScrapeListingUrls(List<string> completeCountyUrl)
        {
            HtmlHandling<string> htmlHandling = new HtmlHandling<string>();

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
            HtmlHandling<string> htmlHandling = new HtmlHandling<string>();

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

				Console.WriteLine("Scraping complete, all properties have beeen added to the Database... \n");
			}
        }
    }
}
