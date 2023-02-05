using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Data.Interfaces;
using Shop.Models;
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

        [Route("Products/List")]
		[Route("Products/List/{category}")]
		public ViewResult List(string category)
        {
            IEnumerable<Product>? products = null;
            string productCategory = "";
            if (category.IsNullOrEmpty())
            {
                products = _products.products.OrderBy(i => i.id);
            }
            else
            {
                if (category.Equals("alcoholic", StringComparison.OrdinalIgnoreCase))
                {
                    products = _products.products.Where(p => p.Category.categoryName.Equals("Алкогольные напитки")).
                        OrderBy(i => i.id);
					productCategory = "Алкогольные напитки";
				}
                else if (category.Equals("noAlcoholic", StringComparison.OrdinalIgnoreCase))
                {
                    products = _products.products.Where(p => p.Category.categoryName.Equals("Безалкогольные напитки")).
                        OrderBy(i => i.id);
                    productCategory = "Безалкогольные напитки";
				}
                else if (category.Equals("milk", StringComparison.OrdinalIgnoreCase))
                {
                    products = _products.products.Where(p => p.Category.categoryName.Equals("Молочные продукты")).
                        OrderBy(i => i.id);
					productCategory = "Молочные продукты";
				}
            }

            ProductsListViewModel model = new ProductsListViewModel {
                products = products,
                currentCategory = productCategory};

            return View(model);
        }

		public ViewResult Detail(int id)
        {
			var item = _products.products.FirstOrDefault(i => i.id == id);

			return View(item);
        }
	}
}
