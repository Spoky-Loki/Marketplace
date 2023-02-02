using Shop.Models;

namespace Shop.ViewModels
{
	public class HomeViewModel
	{
		public IEnumerable<Product> favouriteProducts { get; set; }
	}
}
