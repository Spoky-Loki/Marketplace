using Microsoft.EntityFrameworkCore;
using Shop.Data;

namespace Shop.Models
{
	public class Cart
	{
		private readonly ApplicationContext _context;

		public Cart(ApplicationContext context)
		{
			_context = context;
		}

		public string cartId { get; set; }

		public List<CartItem> cartItems { get; set;}

		public static Cart GetCart(IServiceProvider service)
		{
			ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = service.GetService<ApplicationContext>();
			string cartId = session.GetString("cartId") ?? Guid.NewGuid().ToString();

			session.SetString("cartId", cartId);

			return new Cart(context) { cartId = cartId };
		}

		public void addToCart(Product product)
		{
			_context.cartItems.Add(new CartItem { 
				cartId = cartId, 
				product = product, 
				price = product.price});

			_context.SaveChanges();
		}

		public List<CartItem> GetCartItems() 
		{
			return _context.cartItems.Where(p => p.cartId == cartId).Include(s => s.product).ToList();
		}
	}
}
