using Shop.Models;

namespace Shop.Data.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Category> categories { get; }
    }
}
