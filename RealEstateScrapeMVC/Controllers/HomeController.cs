using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using RealEstateScrapeMVC.Models;
using System.Diagnostics;


namespace RealEstateScrapeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PropertyContext _propertyContext;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _propertyContext = new PropertyContext();
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

        [HttpPost]
        public IActionResult Create(PropertySearchModel propertySearchModel)
        {
			if (string.IsNullOrEmpty(propertySearchModel.County) || string.IsNullOrEmpty(propertySearchModel.UserPriceRange)
				|| string.IsNullOrEmpty(propertySearchModel.UserSqft) || string.IsNullOrEmpty(propertySearchModel.UserLotSize))
			{
				return RedirectToAction("SearchResults");
			}

			PropertyRepository propertyRepository = new PropertyRepository(_propertyContext);
            var searchResults = propertyRepository.SearchPropertiesAsync(propertySearchModel).Result;

			return View("SearchResults", searchResults);
        }


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
