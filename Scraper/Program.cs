namespace Scraper
{
    internal class Program
    {

        public static async Task Main(string[] args)
        {

            Scraper scraper = new Scraper();

                List<string> countyList = new List<string>()
                {
                    "Anderson", "Bourbon", "Boyle", "Clark", "Estill", "Fayette", "Franklin", "Garrard",
                    "Harrison", "Jessamine", "Madison", "Mercer", "Montgomery", "Scott", "Woodford"
                };

            List<string> completeCountyUrls = scraper.CompleteUrl(countyList);

            List<string> allListingUrls = await scraper.ScrapeListingUrls(completeCountyUrls);

            await scraper.ScrapeListingInfo(allListingUrls);
              
        }
    }
}
