using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Models;

namespace Shop.Data.Repository
{
	public class ProductRepository : IProducts
	{
		private readonly ApplicationContext _context;

		public ProductRepository(ApplicationContext context)
		{
			_context = context;
		}

		public IEnumerable<Product> products => _context.products.Include(p => p.Category);

		public IEnumerable<Product> favouriteProducts => _context.products.Where(p => p.isFavourite).
			Include(p => p.Category);

		public Product GetProduct(int id) => _context.products.FirstOrDefault(p => p.id == id);
	}
}
