using RES.DAL.Entities;

namespace RealEstateScrapeMVC.Models
{
	public class SearchResultViewModel
	{
		public IEnumerable<PropertyModel> SearchResults { get; set; }
		public double? SearchSumResults { get; set; }
	}
}
