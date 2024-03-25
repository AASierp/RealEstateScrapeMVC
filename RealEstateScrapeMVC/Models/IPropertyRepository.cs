using RES.DAL.Entities;

namespace RealEstateScrapeMVC.Models
{
    public interface IPropertyRepository
    {
		public Task<IEnumerable<PropertyModel>> SearchPropertiesAsync(PropertySearchModel propertySearchModel);

		//public Task<double?> SearchPriceRawSql(PropertySearchModel searchModel);

	}
}
