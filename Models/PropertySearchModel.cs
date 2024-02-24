using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RealEstateScrapeMVC.Models
{
    public class PropertySearchModel
    {
        [Key]
        public int Id { get; set; }

        [BindProperty]
        public string County { get; set; }

        [BindProperty]
        public string UserPriceRange { get; set; }

        public List<SelectListItem> PriceRanges = new List<SelectListItem>()
        {
            new SelectListItem {Value = "0 - 250,000", Text = "$0 - $250,000"},
            new SelectListItem {Value = "250,000 - 450,000", Text = "$250,000 - $450,000"},
            new SelectListItem {Value = "450,000 - 650,000", Text = "$450,000 - $650,000"},
            new SelectListItem {Value = "650,000 - 850,000", Text = "$650,000 - $850,000"},
            new SelectListItem {Value = "850,000 - 1,000,000", Text = "$850,000 - $1,000,000"},
        };

        [BindProperty]
        public string UserSqft{ get; set; }

        public List<SelectListItem> SqftRanges { get; set; }

        [BindProperty]
        public string UserLotSize {  get; set; }

        public List<SelectListItem > LotSizeRanges { get; set;}
    }
}
