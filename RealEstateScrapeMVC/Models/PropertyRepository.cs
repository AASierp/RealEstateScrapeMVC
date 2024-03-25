using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using RES.DAL.Entities;

namespace RealEstateScrapeMVC.Models
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertyContext _propertyContext;

        public PropertyRepository(PropertyContext propertyContext)
        {
            _propertyContext = propertyContext;
        }

        

        public async Task<IEnumerable<PropertyModel>> SearchPropertiesAsync(PropertySearchModel propertySearchModel)
        {
            
            string selectedCounty = propertySearchModel.County;
            string selectedPriceRange = propertySearchModel.UserPriceRange;
            string selectedSqft = propertySearchModel.UserSqft;
            string selectedLotSize = propertySearchModel.UserLotSize;

            
            string[] priceBoundaries = selectedPriceRange.Split(" - ");
            int minPrice = int.Parse(priceBoundaries[0]);
            int maxPrice = int.Parse(priceBoundaries[1]);

            string[] sqftBoundaries = selectedSqft.Split(" - ");
            int minSqft = int.Parse(sqftBoundaries[0]);
            int maxSqft = int.Parse(sqftBoundaries[1]);

            string[] lotSizeBoundaries = selectedLotSize.Split(" - ");
            int minLotSize = int.Parse(lotSizeBoundaries[0]);
            int maxLotSize = int.Parse(lotSizeBoundaries[1]);


            IQueryable<PropertyModel> query = _propertyContext.PropertyModels;

				if (selectedCounty == "All")
			{
                query = _propertyContext.PropertyModels
                    .Where(x =>
                        x.Price >= minPrice && x.Price <= maxPrice &&
                        x.SquareFeet >= minSqft && x.SquareFeet <= maxSqft &&
                        x.LotSize >= minLotSize && x.LotSize <= maxLotSize)
                    .OrderBy(x => x.County)
                    .ThenBy(x => x.Price);
			}
			else
			{
				query = _propertyContext.PropertyModels
					.Where(x =>
						x.County == selectedCounty &&
						x.Price >= minPrice && x.Price <= maxPrice &&
						x.SquareFeet >= minSqft && x.SquareFeet <= maxSqft &&
						x.LotSize >= minLotSize && x.LotSize <= maxLotSize)
					.OrderBy(x => x.Price);
			}


			return await query.ToListAsync();
        }

        /*public async Task<double?> SearchPriceRawSql(PropertySearchModel searchModel)
        {
            // Raw Sql String
            string sqlQuery = "SELECT Price FROM PropertyModels";

            var prices = await _propertyContext.PropertyModels
                .FromSqlRaw(sqlQuery)
                .ToListAsync();

            var pricesSum = prices.Sum(x => x.Price);

            var priceAverage = pricesSum / (double)prices.Count;

            return priceAverage;
        }*/

    }
}
