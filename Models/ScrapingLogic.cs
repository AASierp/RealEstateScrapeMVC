using HtmlAgilityPack;


namespace RealEstateScrapeMVC.Models
{
    public class ScrapingLogic
    {
        private List<string> countyList = new List<string>()
        {
            "Adair", "Allen", "Anderson", "Ballard", "Barren",
            "Bath", "Bell", "Boone", "Bourbon", "Boyd",
            "Boyle", "Bracken", "Breathitt", "Breckinridge", "Bullitt",
            "Butler", "Caldwell", "Calloway", "Campbell", "Carlisle",
            "Carroll", "Carter", "Casey", "Christian", "Clark",
            "Clay", "Clinton", "Crittenden", "Cumberland", "Daviess",
            "Edmonson", "Elliott", "Estill", "Fayette", "Fleming",
            "Floyd", "Franklin", "Fulton", "Gallatin", "Garrard",
            "Grant", "Graves", "Grayson", "Green", "Greenup",
            "Hancock", "Hardin", "Harlan", "Harrison", "Hart",
            "Henderson", "Henry", "Hickman", "Hopkins", "Jackson",
            "Jefferson", "Jessamine", "Johnson", "Kenton", "Knott",
            "Knox", "Larue", "Laurel", "Lawrence", "Lee",
            "Leslie", "Letcher", "Lewis", "Lincoln", "Livingston",
            "Logan", "Lyon", "McCracken", "McCreary", "McLean",
            "Madison", "Magoffin", "Marion", "Marshall", "Martin",
            "Mason", "Meade", "Menifee", "Mercer", "Metcalfe",
            "Monroe", "Montgomery", "Morgan", "Muhlenberg", "Nelson",
            "Nicholas", "Ohio", "Oldham", "Owen", "Owsley",
            "Pendleton", "Perry", "Pike", "Powell", "Pulaski",
            "Robertson", "Rockcastle", "Rowan", "Russell", "Scott",
            "Shelby", "Simpson", "Spencer", "Taylor", "Todd",
            "Trigg", "Trimble", "Union", "Warren", "Washington",
            "Wayne", "Webster", "Whitley", "Wolfe", "Woodford"
        };

        public async Task<List<string>> ScrapeListingUrls(List<string> countyList)
        {
            List<string> allListingUrls = new List<string>();

            foreach (string county in countyList)
            {

                string countyUrl =$"https://www.joehaydenrealtor.com/{county}-county-ky/";

                string htmlContent = await ClientRequest.MakeHttpRequestAsync(countyUrl);

                HtmlDocument htmlDocument = HtmlHandling.CreateHtmlDoc(htmlContent);

                List<string> listingUrls = HtmlHandling.ParseHtmlForListingUrls(htmlDocument);

                allListingUrls.AddRange(listingUrls);
            }

            return allListingUrls;
        }

        public async Task ScrapeListingInfo(List<string> allListingUrls)
        {
            using (PropertyContext propertyContext = new PropertyContext())

            {
                foreach (string listingUrl in allListingUrls)
                {
                    string htmlContent = await ClientRequest.MakeHttpRequestAsync(listingUrl);

                    HtmlDocument htmlDocument = HtmlHandling.CreateHtmlDoc(htmlContent);

                    PropertyModel propertyModel = HtmlHandling.ParseIndividualListingInfo(htmlDocument);

                    propertyContext.PropertyModels.Add(propertyModel);
                }

                await propertyContext.SaveChangesAsync();
            }
        }
    }
}
