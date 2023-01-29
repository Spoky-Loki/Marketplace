using Shop.Models;

namespace Shop.Interfaces
{
    public interface IDrinksCategory
    {
        IEnumerable<Category> categories { get; }
    }
}
