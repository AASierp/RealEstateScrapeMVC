namespace Scraper
{
    internal interface IScraper
    {
        public List<string> CompleteUrl(List<string> countyList);

        public Task<List<string>> ScrapeListingUrls(List<string> completeCountyUrl);

        public Task ScrapeListingInfo(List<string> allListingUrls);

    };
}
