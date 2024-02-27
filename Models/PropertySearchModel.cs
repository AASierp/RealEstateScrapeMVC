using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RealEstateScrapeMVC.Models
{
    public class PropertySearchModel
    {
        [Key]
        public int Id { get; set; }
        public string County { get; set; }

        public static int MinPriceOne = 0;
        public static int MaxPriceOne = 250000;
        public static int MaxPriceTwo = 450000;
        public static int MaxPriceThree = 650000;
        public static int MaxPriceFour = 850000;
        public static int MaxPriceFive = 1000000;


        public List<SelectListItem> CountyList = new List<SelectListItem>()
        {
            new SelectListItem {Value = "Adair", Text = "Adair"},
            new SelectListItem {Value = "Allen", Text = "Allen"},
            new SelectListItem {Value = "Anderson", Text = "Anderson"},
            new SelectListItem {Value = "Ballard", Text = "Ballard"},
            new SelectListItem {Value = "Barren", Text = "Barren"},
            new SelectListItem {Value = "Bath", Text = "Bath"},
            new SelectListItem {Value = "Bell", Text = "Bell"},
            new SelectListItem {Value = "Boone", Text = "Boone"},
            new SelectListItem {Value = "Bourbon", Text = "Bourbon"},
            new SelectListItem {Value = "Boyd", Text = "Boyd"},
            new SelectListItem {Value = "Boyle", Text = "Boyle"},
            new SelectListItem {Value = "Bracken", Text = "Bracken"},
            new SelectListItem {Value = "Breathitt", Text = "Breathitt"},
            new SelectListItem {Value = "Breckinridge", Text = "Breckinridge"},
            new SelectListItem {Value = "Bullitt", Text = "Bullitt"},
            new SelectListItem {Value = "Butler", Text = "Butler"},
            new SelectListItem {Value = "Caldwell", Text = "Caldwell"},
            new SelectListItem {Value = "Calloway", Text = "Calloway"},
            new SelectListItem {Value = "Campbell", Text = "Campbell"},
            new SelectListItem {Value = "Carlisle", Text = "Carlisle"},
            new SelectListItem {Value = "Carroll", Text = "Carroll"},
            new SelectListItem {Value = "Carter", Text = "Carter"},
            new SelectListItem {Value = "Casey", Text = "Casey"},
            new SelectListItem {Value = "Christian", Text = "Christian"},
            new SelectListItem {Value = "Clark", Text = "Clark"},
            new SelectListItem {Value = "Clay", Text = "Clay"},
            new SelectListItem {Value = "Clinton", Text = "Clinton"},
            new SelectListItem {Value = "Crittenden", Text = "Crittenden"},
            new SelectListItem {Value = "Cumberland", Text = "Cumberland"},
            new SelectListItem {Value = "Daviess", Text = "Daviess"},
            new SelectListItem {Value = "Edmonson", Text = "Edmonson"},
            new SelectListItem {Value = "Elliott", Text = "Elliott"},
            new SelectListItem {Value = "Estill", Text = "Estill"},
            new SelectListItem {Value = "Fayette", Text = "Fayette"},
            new SelectListItem {Value = "Fleming", Text = "Fleming"},
            new SelectListItem {Value = "Floyd", Text = "Floyd"},
            new SelectListItem {Value = "Franklin", Text = "Franklin"},
            new SelectListItem {Value = "Fulton", Text = "Fulton"},
            new SelectListItem {Value = "Gallatin", Text = "Gallatin"},
            new SelectListItem {Value = "Garrard", Text = "Garrard"},
            new SelectListItem {Value = "Grant", Text = "Grant"},
            new SelectListItem {Value = "Graves", Text = "Graves"},
            new SelectListItem {Value = "Grayson", Text = "Grayson"},
            new SelectListItem {Value = "Green", Text = "Green"},
            new SelectListItem {Value = "Greenup", Text = "Greenup"},
            new SelectListItem {Value = "Hancock", Text = "Hancock"},
            new SelectListItem {Value = "Hardin", Text = "Hardin"},
            new SelectListItem {Value = "Harlan", Text = "Harlan"},
            new SelectListItem {Value = "Harrison", Text = "Harrison"},
            new SelectListItem {Value = "Hart", Text = "Hart"},
            new SelectListItem {Value = "Henderson", Text = "Henderson"},
            new SelectListItem {Value = "Henry", Text = "Henry"},
            new SelectListItem {Value = "Hickman", Text = "Hickman"},
            new SelectListItem {Value = "Hopkins", Text = "Hopkins"},
            new SelectListItem {Value = "Jackson", Text = "Jackson"},
            new SelectListItem {Value = "Jefferson", Text = "Jefferson"},
            new SelectListItem {Value = "Jessamine", Text = "Jessamine"},
            new SelectListItem {Value = "Johnson", Text = "Johnson"},
            new SelectListItem {Value = "Kenton", Text = "Kenton"},
            new SelectListItem {Value = "Knott", Text = "Knott"},
            new SelectListItem {Value = "Knox", Text = "Knox"},
            new SelectListItem {Value = "Larue", Text = "Larue"},
            new SelectListItem {Value = "Laurel", Text = "Laurel"},
            new SelectListItem {Value = "Lawrence", Text = "Lawrence"},
            new SelectListItem {Value = "Lee", Text = "Lee"},
            new SelectListItem {Value = "Leslie", Text = "Leslie"},
            new SelectListItem {Value = "Letcher", Text = "Letcher"},
            new SelectListItem {Value = "Lewis", Text = "Lewis"},
            new SelectListItem {Value = "Lincoln", Text = "Lincoln"},
            new SelectListItem {Value = "Livingston", Text = "Livingston"},
            new SelectListItem {Value = "Logan", Text = "Logan"},
            new SelectListItem {Value = "Lyon", Text = "Lyon"},
            new SelectListItem {Value = "McCracken", Text = "McCracken"},
            new SelectListItem {Value = "McCreary", Text = "McCreary"},
            new SelectListItem {Value = "McLean", Text = "McLean"},
            new SelectListItem {Value = "Madison", Text = "Madison"},
            new SelectListItem {Value = "Magoffin", Text = "Magoffin"},
            new SelectListItem {Value = "Marion", Text = "Marion"},
            new SelectListItem {Value = "Marshall", Text = "Marshall"},
            new SelectListItem {Value = "Martin", Text = "Martin"},
            new SelectListItem {Value = "Mason", Text = "Mason"},
            new SelectListItem {Value = "Meade", Text = "Meade"},
            new SelectListItem {Value = "Menifee", Text = "Menifee"},
            new SelectListItem {Value = "Mercer", Text = "Mercer"},
            new SelectListItem {Value = "Metcalfe", Text = "Metcalfe"},
            new SelectListItem {Value = "Monroe", Text = "Monroe"},
            new SelectListItem {Value = "Montgomery", Text = "Montgomery"},
            new SelectListItem {Value = "Morgan", Text = "Morgan"},
            new SelectListItem {Value = "Muhlenberg", Text = "Muhlenberg"},
            new SelectListItem {Value = "Nelson", Text = "Nelson"},
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
    }
}

