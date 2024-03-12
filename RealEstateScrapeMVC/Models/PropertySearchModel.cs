using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace RealEstateScrapeMVC.Models
{
    public class PropertySearchModel
    {
        [Key]
        public int Id { get; set; }
        public string County { get; set; }

        public List<SelectListItem> CountyList = new List<SelectListItem>()
        {
            
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
        
        public string UserPriceRange { get; set; }

        public List<SelectListItem> PriceRanges = new List<SelectListItem>()
        {
            new SelectListItem {Value = $"{MinPriceOne} - {MaxPriceOne}", Text = $"${MinPriceOne} - ${MaxPriceOne}"},
            new SelectListItem {Value = "250,000 - 450,000", Text = "$250,000 - $450,000"},
            new SelectListItem {Value = "450,000 - 650,000", Text = "$450,000 - $650,000"},
            new SelectListItem {Value = "650,000 - 850,000", Text = "$650,000 - $850,000"},
            new SelectListItem {Value = "850,000 - 1,000,000", Text = "$850,000 - $1,000,000"},
        };

        
        public string UserSqft { get; set; }

        public List<SelectListItem> SqftRanges = new List<SelectListItem>()
        {
            new SelectListItem { Value = "0 - 1,000", Text = "0 - 1,000 sqft"},
            new SelectListItem { Value = "1,000 - 2,000", Text = "1,000 - 2,000 sqft"},
            new SelectListItem { Value = "2,000 - 3,000", Text = "2,000 - 3,000 sqft" },
            new SelectListItem { Value = "3,000 - 4,000", Text = "3,000 - 4,000 sqft" },
            new SelectListItem { Value = "4,000 - 5,000", Text = "4,000 - 5,000 sqft" },
        };

        
        public string UserLotSize { get; set; }

        public List<SelectListItem> LotSizeRanges = new List<SelectListItem>()
        {
             new SelectListItem {Value =  "0 - 2", Text = "0 - 2 acres"},
             new SelectListItem {Value =  "2 - 5", Text = "2 - 5 acres"},
             new SelectListItem {Value =  "5 - 10", Text = "5 - 10 acres"},
             new SelectListItem {Value = "10 - 100", Text = "10 - 100 acres"},
        };

        public const int MinPriceOne = 0;
        public const int MaxPriceOne = 250000;
        public const int MaxPriceTwo = 450000;
        public const int MaxPriceThree = 650000;
        public const int MaxPriceFour = 850000;
        public const int MaxPriceFive = 1000000;

    }
}

