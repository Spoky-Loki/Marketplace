using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Models;
using Shop.ViewModels;
using System.Diagnostics;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

		private readonly IProducts _product;

		public HomeController(ILogger<HomeController> logger, IProducts product)
        {
            _logger = logger;
			_product = product;
		}

        public IActionResult Index()
        {
            var homeProducts = new HomeViewModel{ favouriteProducts = _product.favouriteProducts };

            return View(homeProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}