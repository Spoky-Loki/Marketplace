namespace Shop.Models
{
	public class CartItem
	{
		public int id { get; set; }

		public Product product { get; set; }

		public int price { get; set; }

		public string cartId { get; set; }
	}
}
