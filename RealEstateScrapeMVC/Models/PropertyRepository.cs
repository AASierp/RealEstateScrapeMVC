using DataAccessLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RES.DAL.Entities;

namespace RealEstateScrapeMVC.Models
{
    public class PropertyRepository
    {
        private readonly PropertyContext _propertyContext;

        public PropertyRepository(PropertyContext propertyContext)
        {
            _propertyContext = propertyContext;
        }

        /*public async Task<IEnumerable<PropertyModel>> SearchPropertiesByCounty(PropertySearchModel propertySearchModel)
        {
            SelectListItem countyOption = propertySearchModel.CountyList.FirstOrDefault();

            if (countyOption != null)
            {

            }
        }*/

        public async Task<IEnumerable<PropertyModel>> SearchPropertiesByPriceAsync(PropertySearchModel propertySearchModel)
        {

            SelectListItem priceOption = propertySearchModel.PriceRanges.FirstOrDefault();

            // Check if a price option is available
            if (priceOption != null)
            {
                // Extract the minimum and maximum prices from the first price option
                int minPrice = GetMinPrice(priceOption.Value);
                int maxPrice = GetMaxPrice(priceOption.Value);

                // Query the database for properties within the specified price range
                IQueryable<PropertyModel> query = _propertyContext.PropertyModels
                    .Where(property => property.Price >= minPrice && property.Price <= maxPrice);

                // Execute the query and return the result
                return await query.ToListAsync();
            }
            else
            {
                // No price option available, return an empty list
                return Enumerable.Empty<PropertyModel>();
            }
        }

        // Helper method to extract the minimum price from the price option
        private int GetMinPrice(string priceOption)
        {
            switch (priceOption)
            {
                case "0":
                    return PropertySearchModel.MinPriceOne;
                case "1":
                    return PropertySearchModel.MinPriceOne + 1; // Increment by 1 to avoid overlap
                case "2":
                    return PropertySearchModel.MaxPriceOne + 1;
                case "3":
                    return PropertySearchModel.MaxPriceTwo + 1;
                case "4":
                    return PropertySearchModel.MaxPriceThree + 1;
                default:
                    return 0; // Default to 0 if option is not recognized
            }
        }

        // Helper method to extract the maximum price from the price option
        private int GetMaxPrice(string priceOption)
        {
            switch (priceOption)
            {
                case "0":
                    return PropertySearchModel.MaxPriceOne;
                case "1":
                    return PropertySearchModel.MaxPriceTwo;
                case "2":
                    return PropertySearchModel.MaxPriceThree;
                case "3":
                    return PropertySearchModel.MaxPriceFour;
                case "4":
                    return PropertySearchModel.MaxPriceFive;
                default:
                    return 0; // Default to 0 if option is not recognized
            }
        }
    }
}
