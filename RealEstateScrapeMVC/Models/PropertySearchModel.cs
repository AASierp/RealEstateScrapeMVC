using Microsoft.AspNetCore.Mvc.Rendering;

namespace RealEstateScrapeMVC.Models
{
    public class PropertySearchModel
    {
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

        public int UserPriceRange { get; set; }

        public const int MinPriceOne = 0;
        public const int MaxPriceOne = 250000;
        public const int MaxPriceTwo = 450000;
        public const int MaxPriceThree = 650000;
        public const int MaxPriceFour = 850000;
        public const int MaxPriceFive = 1000000;

        public const int PriceOptionOne = 0;
        public const int PriceOptionTwo = 1;
        public const int PriceOptionThree = 2;
        public const int PriceOptionFour = 3;
        public const int PriceOptionFive = 4;

        public List<SelectListItem> PriceRanges = new List<SelectListItem>()
        {
            new SelectListItem {Value = $"{PriceOptionOne}", Text = $"$0 - $250,000"},
            new SelectListItem {Value = $"{PriceOptionTwo}", Text = "$250,000 - $450,000"},
            new SelectListItem {Value = $"{PriceOptionThree}", Text = "$450,000 - $650,000"},
            new SelectListItem {Value = $"{PriceOptionFour}", Text = "$650,000 - $850,000"},
            new SelectListItem {Value = $"{PriceOptionFive}", Text = "$850,000 - $1,000,000"},
        };


        public int UserSqft { get; set; }

        public const int MinSqftOne = 0;
        public const int MaxSqftOne = 1000;
        public const int MaxSqftTwo = 2000;
        public const int MaxSqftThree = 3000;
        public const int MaxSqftFour = 4000;
        public const int MaxSqftFive = 5000;

        public const int SqftOptionOne = 0;
        public const int SqftOptionTwo = 1;
        public const int SqftOptionThree = 2;
        public const int SqftOptionFour = 3;
        public const int SqftOptionFive = 4;


        public List<SelectListItem> SqftRanges = new List<SelectListItem>()
        {
            new SelectListItem { Value = $"{SqftOptionOne}", Text = "0 - 1,000 sqft"},
            new SelectListItem { Value = $"{SqftOptionTwo}", Text = "1,000 - 2,000 sqft"},
            new SelectListItem { Value = $"{SqftOptionThree}", Text = "2,000 - 3,000 sqft" },
            new SelectListItem { Value = $"{SqftOptionFour}", Text = "3,000 - 4,000 sqft" },
            new SelectListItem { Value = $"{SqftOptionFive}", Text = "4,000 - 5,000 sqft" },
        };

        public int UserLotSize { get; set; }

        public const double MinLotSizeOne = 0;
        public const double MaxLotSizeOne = 2;
        public const double MaxLotSizeTwo = 5;
        public const double MaxLotSizeThree = 10;
        public const double MaxLotSizeFour = 100;

        public const int LotSizeOptionOne = 0;
        public const int LotSizeOptionTwo = 1;
        public const int LotSizeOptionThree = 2;
        public const int LotSizeOptionFour = 3;

        public List<SelectListItem> LotSizeRanges = new List<SelectListItem>()
        {
            new SelectListItem {Value = $"{LotSizeOptionOne}", Text = "0 - 2 acres"},
            new SelectListItem {Value = $"{LotSizeOptionTwo}", Text = "2 - 5 acres"},
            new SelectListItem {Value = $"{LotSizeOptionThree}", Text = "5 - 10 acres"},
            new SelectListItem {Value = $"{LotSizeOptionFour}", Text = "10 - 100 acres"},
        };
    }
}

//new SelectListItem { Value = $"{minPriceOne} - {maxPriceOne}", Text = $"$0 - $250,000" },