using Shop.Models;

namespace Shop.Interfaces
{
    public interface IDrinks
    {
        IEnumerable<Drink> drinks { get; set;  }

        IEnumerable<Drink> favouriteDrinks { get; set; }

        Drink GetDrink(int id);
    }
}
