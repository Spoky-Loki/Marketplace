using Shop.Interfaces;
using Shop.Models;

namespace Shop.Mocks
{
    public class MockProduct : IProducts
    {
        private readonly ICategories _categories = new MockCategory();

        public IEnumerable<Product> products 
        { 
            get
            {
                return new List<Product> { new Product { name = "Сок апельсиновый", shortDescription = "",
                    longDescription = "", image = "", price = 99, isFavourite = true, available = true, 
                    Category = _categories.categories.ElementAt(1)}, 
                };
            }
        }

        public IEnumerable<Product> favouriteProducts { get; set; }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
