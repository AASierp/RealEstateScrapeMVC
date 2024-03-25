using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RealEstateScrapeMVC.Models
{
	public class PropertySearchModel
	{
		[Required(ErrorMessage = "Please select a county.")]
		public string? County { get; set; }

		public List<SelectListItem> CountyList = new List<SelectListItem>()
		{
			new SelectListItem {Value = "All", Text = "All"},
			new SelectListItem {Value = "Anderson", Text = "Anderson"},
			new SelectListItem {Value = "Bourbon", Text = "Bourbon"},
			new SelectListItem {Value = "Boyle", Text = "Boyle"},
			new SelectListItem {Value = "Clark", Text = "Clark"},
			new SelectListItem {Value = "Estill", Text = "Estill"},
			new SelectListItem {Value = "Fayette", Text = "Fayette"},
			new SelectListItem {Value = "Franklin", Text = "Franklin"},
			new SelectListItem {Value = "Garrard", Text = "Garrard"},
			new SelectListItem {Value = "Harrison", Text = "Harrison"},
			new SelectListItem {Value = "Jessamine", Text = "Jessamine"},
			new SelectListItem {Value = "Madison", Text = "Madison"},
			new SelectListItem {Value = "Mercer", Text = "Mercer"},
			new SelectListItem {Value = "Montgomery", Text = "Montgomery"},
			new SelectListItem {Value = "Scott", Text = "Scott"},
			new SelectListItem {Value = "Woodford", Text = "Woodford"},

		};

		[Required(ErrorMessage = "Please select a price range.")]
		public string? UserPriceRange { get; set; }

		public List<SelectListItem> PriceRanges = new List<SelectListItem>()
		{
			new SelectListItem {Value = "0 - 99999999", Text = "Any" },
			new SelectListItem {Value = "0 - 250000", Text = "$0 - $250,000"},
			new SelectListItem {Value = "250000 - 450000", Text = "$250,000 - $450,000"},
			new SelectListItem {Value = "450000 - 650000", Text = "$450,000 - $650,000"},
			new SelectListItem {Value = "650000 - 850000", Text = "$650,000 - $850,000"},
			new SelectListItem {Value = "850000 - 1000000", Text = "$850,000 - $1,000,000"},
		};

		[Required(ErrorMessage = "Please select a square footage range.")]
		public string? UserSqft { get; set; }

		public List<SelectListItem> SqftRanges = new List<SelectListItem>()
		{
			new SelectListItem {Value = "0 - 99999999", Text = "Any" },
			new SelectListItem { Value = "0 - 1000", Text = "0 - 1,000 sqft"},
			new SelectListItem { Value = "1000 - 2000", Text = "1,000 - 2,000 sqft"},
			new SelectListItem { Value = "2000 - 3000", Text = "2,000 - 3,000 sqft" },
			new SelectListItem { Value = "3000 - 4000", Text = "3,000 - 4,000 sqft" },
			new SelectListItem { Value = "4000 - 5000", Text = "4,000 - 5,000 sqft" },
		};

		[Required(ErrorMessage = "Please select a lot size range.")]
		public string? UserLotSize { get; set; }

		public List<SelectListItem> LotSizeRanges = new List<SelectListItem>()
		{
			 new SelectListItem {Value = "0 - 99999999", Text = "Any" },
			 new SelectListItem {Value =  "0 - 2", Text = "0 - 2 acres"},
			 new SelectListItem {Value =  "2 - 5", Text = "2 - 5 acres"},
			 new SelectListItem {Value =  "5 - 10", Text = "5 - 10 acres"},
			 new SelectListItem {Value = "10 - 100", Text = "10 - 100 acres"},
		};
	}
}

