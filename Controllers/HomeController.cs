using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstateScrapeMVC.Models;
using System.Diagnostics;


namespace RealEstateScrapeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult SearchResults()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            PropertySearchModel propertySearchModelPrice = new PropertySearchModel();



            return View(propertySearchModelPrice);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Create([FromForm] PropertySearchModel county)
        {
           /* using (PropertyContext db = new PropertyContext())
            {
                db.Add(county);
                db.SaveChanges();
            }*/

            return View();
        }

        /*public ActionResult PopulatePriceList()
        {
            PropertySearchModel propertySearchModelPrice = new PropertySearchModel
            {
                PriceRanges = new List<SelectListItem>
                {
                    new SelectListItem {Value = "0 - 250,000", Text = "$0 - $250,000"},
                    new SelectListItem {Value = "250,000 - 450,000", Text = "$250,000 - $450,000"},
                    new SelectListItem {Value = "450,000 - 650,000", Text = "$450,000 - $650,000"},
                    new SelectListItem {Value = "650,000 - 850,000", Text = "$650,000 - $850,000"},
                    new SelectListItem {Value = "850,000 - 1,000,000", Text = "$850,000 - $1,000,000"},
                }
            };

            return View(propertySearchModelPrice);
        }

        public ActionResult PopulateSqftList()
        {
            PropertySearchModel propertySearchModelSqft = new PropertySearchModel
            {
                SqftRanges = new List<SelectListItem>
                {
                    new SelectListItem {Value = "0 - 1,000", Text = "0 - 1,000 sqft"},
                    new SelectListItem {Value = "1,000 - 2,000", Text = "1,000 - 2,000 sqft"},
                    new SelectListItem {Value = "2,000 - 3,000", Text = "2,000 - 3,000 sqft"},
                    new SelectListItem {Value = "3,000 - 4,000", Text = "3,000 - 4,000 sqft"},
                    new SelectListItem {Value = "4,000 - 5,000", Text = "4,000 - 5,000 sqft"},
                }
            };

            return View(propertySearchModelSqft);
        }

        public ActionResult PopulateLotSizeList() 
        {
            PropertySearchModel propertySearchModelLotSize = new PropertySearchModel
            {
                LotSizeRanges = new List<SelectListItem>
                {
                    new SelectListItem {Value = "0 - 2", Text = "0 - 2 acres"},
                    new SelectListItem {Value = "2 - 5", Text = "2 - 5 acres"},
                    new SelectListItem {Value = "5 - 10", Text = "5 - 10 acres"},
                    new SelectListItem {Value = "10 - 100", Text = "10 - 100 acres"},
                }
            };

            return View(propertySearchModelLotSize);*/
        //}        
    }
}
