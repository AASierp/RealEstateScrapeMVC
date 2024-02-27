using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace RealEstateScrapeMVC.Models
{
    public class ScrapingLogic
    {
        List<string> countyList = new List<string>()
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
        
        public static async Task Scrape(List<string> countyList)
        {
            using (PropertyContext propertyContext = new PropertyContext())
            {
                foreach (string county in countyList)
                {
                    string htmlContent = await ClientRequest.MakeHttpRequestAsync(county);

                    HtmlDocument htmlDocument = HtmlHandling.CreateHtmlDoc(htmlContent);

                    PropertyModel propertyModel = HtmlHandling.ParseHtmlDoc(htmlDocument);

                    propertyContext.PropertyModels.Add(propertyModel);
                }

                await propertyContext.SaveChangesAsync();
            }
        }
    }
}
