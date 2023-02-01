using Shop.Models;

namespace Shop.Data.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> products { get; }

        IEnumerable<Product> favouriteProducts { get; set; }

        Product GetProduct(int id);
    }
}
