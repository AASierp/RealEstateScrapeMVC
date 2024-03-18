using DataAccessLayer;
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

        public async Task<IEnumerable<PropertyModel>> SearchPropertiesByCountyAsync(PropertySearchModel propertySearchModel)
        {
            string selectedCounty = propertySearchModel.County;

            IQueryable<PropertyModel> queryCounty = _propertyContext.PropertyModels.Where(x => x.County == selectedCounty);

            return await queryCounty.ToListAsync();
        }

        public async Task<IEnumerable<PropertyModel>> SearchPropertiesByPriceAsync(PropertySearchModel propertySearchModel)
        {

            string selectedPriceRange = propertySearchModel.UserPriceRange;

            string[] priceBoundaries = selectedPriceRange.Split(" - ");
            int minPrice = int.Parse(priceBoundaries[0]);
            int maxPrice = int.Parse(priceBoundaries[1]);

            IQueryable<PropertyModel> queryPrice = _propertyContext.PropertyModels
            .Where(x => x.Price >= minPrice && x.Price <= maxPrice);

            return await queryPrice.ToListAsync();

        }

        public async Task<IEnumerable<PropertyModel>> SearchPropertiesBySqftAsync(PropertySearchModel propertySearchModel)
        {
            string selectedSqft = propertySearchModel.UserSqft;
            string[] sqftBoundaries = selectedSqft.Split(" - ");
            int minSqft = int.Parse(sqftBoundaries[0]);
            int maxSqft = int.Parse(sqftBoundaries[1]);

            IQueryable<PropertyModel> querySqft = _propertyContext.PropertyModels.Where(x => x.SquareFeet >= minSqft && x.SquareFeet <= maxSqft);

            return await querySqft.ToListAsync();
        }

        public async Task<IEnumerable<PropertyModel>> SearchPropertiesByLotSizeAsync(PropertySearchModel propertySearchModel)
        {
            string selectedLotSize = propertySearchModel.UserLotSize;
            string[] lotSizeBoundaries = selectedLotSize.Split(" - ");
            double minLotsize = double.Parse(lotSizeBoundaries[0]);
            double maxLotSize = double.Parse(lotSizeBoundaries[1]);

            IQueryable<PropertyModel> queryLotSize = _propertyContext.PropertyModels.Where(x => x.LotSize >= minLotsize && x.LotSize <= maxLotSize);

            return await queryLotSize.ToListAsync();
        }

        public async Task<IEnumerable<PropertyModel>> SearchPropertiesAsync(PropertySearchModel propertySearchModel)
        {
            // Extract selected options from the propertySearchModel
            string selectedCounty = propertySearchModel.County;
            string selectedPriceRange = propertySearchModel.UserPriceRange;
            string selectedSqft = propertySearchModel.UserSqft;
            string selectedLotSize = propertySearchModel.UserLotSize;

            // Parse selected price range, sqft range, and lot size range
            string[] priceBoundaries = selectedPriceRange.Split(" - ");
            int minPrice = int.Parse(priceBoundaries[0]);
            int maxPrice = int.Parse(priceBoundaries[1]);

            string[] sqftBoundaries = selectedSqft.Split(" - ");
            int minSqft = int.Parse(sqftBoundaries[0]);
            int maxSqft = int.Parse(sqftBoundaries[1]);

            string[] lotSizeBoundaries = selectedLotSize.Split(" - ");
            int minLotSize = int.Parse(lotSizeBoundaries[0]);
            int maxLotSize = int.Parse(lotSizeBoundaries[1]);

            // Construct query to filter properties based on all criteria
            IQueryable<PropertyModel> query = _propertyContext.PropertyModels
                .Where(x => x.County == selectedCounty &&
                            x.Price >= minPrice && x.Price <= maxPrice &&
                            x.SquareFeet >= minSqft && x.SquareFeet <= maxSqft &&
                            x.LotSize >= minLotSize && x.LotSize <= maxLotSize)
                .OrderBy(x =>x.Price);

            // Execute the query to retrieve filtered properties
            return await query.ToListAsync();
        }

    }
}
