using Shop.Interfaces;
using Shop.Models;

namespace Shop.Mocks
{
    public class MockCategory : ICategories
    {
        public IEnumerable<Category> categories
        {
            get
            {
                return new List<Category>
                {
                    new Category{ categoryName = "Алкогольные напитки",
                        categoryDescription = "Напитки содержащие алкоголь 18+"},
                    new Category { categoryName = "Безалкогольные напитки", 
                        categoryDescription = "Напитки не содержащие алкоголь"},
                    new Category { categoryName = "Молочные продукты",
                        categoryDescription = "Молокосодержащие продукты"}
                };
            }
        }
    }
}
