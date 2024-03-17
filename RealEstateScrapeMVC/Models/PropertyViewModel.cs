/*using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace RealEstateScrapeMVC.Models
{
    public class PropertyViewModel
    {
        public int Price { get; set; }

        public int Sqft { get; set; }

        public int Lot { get; set; } 

        public static explicit operator PropertyModel(PropertyViewModel model)
        {
            return new PropertyModel
            {
                Price = model.Price,
                SquareFeet = model.Sqft,
                LotSize = model.Lot
            };
        }
    }
}
*/