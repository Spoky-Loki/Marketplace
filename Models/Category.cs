namespace Shop.Models
{
    public class Category
    {
        public int id { get; set; }

        public string categoryName { get; set; }

        public string categoryDescription { get; set; }

        public List<Drink> drinks { get; set; }
    }
}
