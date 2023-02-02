using Shop.Data.Interfaces;
using Shop.Models;

namespace Shop.Data.Repository
{
	public class CategoryRepository : ICategories
	{
		private readonly ApplicationContext _context;

		public CategoryRepository(ApplicationContext context)
		{
			_context = context;
		}

		public IEnumerable<Category> categories => _context.categories;
	}
}
