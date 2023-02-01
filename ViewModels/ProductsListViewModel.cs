using Shop.Models;

namespace Shop.ViewModels
{
	public class ProductsListViewModel
	{
		public IEnumerable<Product> products { get; set; }
		public string currentCategory { get; set; }


	}
}
