using Shop.Models;

namespace Shop.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> products { get; }

        IEnumerable<Product> favouriteProducts { get; set; }

        Product GetProduct(int id);
    }
}
