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
            PropertySearchModel propertySearchModel = new PropertySearchModel();

            return View(propertySearchModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Create(PropertySearchModel propertySearchModel)
        {
           /* using (PropertyContext db = new PropertyContext())
            {
                db.Add(county);
                db.SaveChanges();
            }*/

            return View();
        }
    }
}
