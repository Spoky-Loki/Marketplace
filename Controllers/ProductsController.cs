using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _products;
        private readonly ICategories _categories;

        public ProductsController(IProducts products, ICategories categories)
        {
            this._products = products;
            this._categories = categories;
        }

        public ViewResult list() 
        {
            ViewBag.Title = "Страница с продуктами";

            ProductsListViewModel model = new ProductsListViewModel();
            model.products = _products.products;
            model.currentCategory = "Категория";

            return View(model);
        }


    }
}
