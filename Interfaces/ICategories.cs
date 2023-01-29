using Shop.Models;

namespace Shop.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Category> categories { get; }
    }
}
