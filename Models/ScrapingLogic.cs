/*using Microsoft.AspNetCore.Mvc;


namespace RealEstateScrapeMVC.Models
{
    public class ScrapingLogic
    {
        static void Scrape()
        {

            ClientRequest.MakeHttpRequestAsync();




        }


        List<PropertySearchModel> _properties;

        void ListAdd(PropertySearchModel property)
        {
            _properties.Add(property);
        }


        PropertySearchModel PropertySearchModel;



        public async Task<IActionResult> makeRequest()
        {
            foreach (var link in _properties)
            {
                string htmlContent = await ClientRequest.MakeHttpRequestAsync(link);
            }
        }

    }
}
*/