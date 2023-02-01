using Shop.Data.Interfaces;
using Shop.Models;

namespace Shop.Data.Mocks
{
    public class MockProduct : IProducts
    {
        private readonly ICategories _categories = new MockCategory();

        public IEnumerable<Product> products
        {
            get
            {
                return new List<Product> {
                    new Product { name = "Сок апельсиновый",
                        shortDescription = "Апельсиновый сок — продукт, получаемый из мякоти апельсинов.",
                        longDescription = "Апельсиновый сок — источник витамина С (аскорбиновой кислоты), калия, фолиевой кислоты (Витамин B9). " +
                            "Апельсиновый сок также содержит флавоноиды, которые благотворно влияют на здоровье человека.",
                        image = "/img/orange.jpg",
                        price = 99, isFavourite = true, available = true,
                        Category = _categories.categories.ElementAt(1)},

                    new Product { name = "Сок яблочный",
                        shortDescription = "Яблочный сок —  сок, выжатый из яблок.",
                        longDescription = "Яблочный сок — сок, выжатый из яблок. " +
                            "Сладкий вкус обусловлен содержанием в яблоках натурального сахара.",
                        image = "/img/apple.jpg",
                        price = 99, isFavourite = true, available = true,
                        Category = _categories.categories.ElementAt(1)},

                    new Product { name = "Пиво",
                        shortDescription = "Пиво — слабоалкогольный напиток.",
                        longDescription = "Пиво — слабоалкогольный напиток, получаемый спиртовым брожением солодового сусла " +
                            "(чаще всего на основе ячменя) с помощью пивных дрожжей, обычно с добавлением хмеля.",
                        image = "/img/beer.jpg",
                        price = 89, isFavourite = true, available = true,
                        Category = _categories.categories.ElementAt(0)},

                    new Product { name = "Саке",
                        shortDescription = "Саке — один из традиционных японских алкогольных напитков",
                        longDescription = "Саке — один из традиционных японских алкогольных напитков, получаемый путём сбраживания сусла на основе риса и пропаренного рисового солода.",
                        image = "/img/sake.jpg",
                        price = 599, isFavourite = false, available = true,
                        Category = _categories.categories.ElementAt(0)},

                    new Product { name = "Молоко",
                        shortDescription = "Ультрапастеризованное молоко изготавливается из молока высшего сорта с собственных ферм.",
                        longDescription = "Продукт обладает всеми свойствами натурального молока, при этом он прошел высокотемпературную обработку, " +
                            "поэтому может храниться длительное время в закрытом состоянии даже без холодильника при температуре до +24°C. Следует отметить, " +
                            "что ультрапастеризованное молоко 3,2% содержит легкоусвояемый молочный белок и кальций, полезные микроэлементы: медь, йод, стронций и др.",
                        image = "/img/milk.jpg",
                        price = 79, isFavourite = true, available = true,
                        Category = _categories.categories.ElementAt(2)},

                    new Product { name = "Сметана",
                        shortDescription = "Сметана — вкусный кисломолочный продукт из закваски и сливок.",
                        longDescription = "Сметана — жидкий кисломолочный продукт белого цвета густой консистенции, " +
                            "получаемый из сливок и закваски.",
                        image = "/img/sour_cream.jpg",
                        price = 119, isFavourite = true, available = true,
                        Category = _categories.categories.ElementAt(2)},
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
