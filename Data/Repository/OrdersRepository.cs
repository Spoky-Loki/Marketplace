using Shop.Data.Interfaces;
using Shop.Models;

namespace Shop.Data.Repository
{
	public class OrdersRepository : IAllOrders
	{
		private readonly ApplicationContext _context;

		private readonly Cart _cart;

		public OrdersRepository(ApplicationContext context, Cart cart)
		{
			_context = context;
			_cart = cart;
		}

		public void createOrder(Order order)
		{
			order.orderTime = DateTime.Now;
			_context.orders.Add(order);

			var products = _cart.cartItems;
			foreach (var product in products)
			{
				var orderDetail = new OrderDetail
				{
					productId = product.product.id,
					orderId = order.id,
					price = product.product.price
				};
				_context.OrderDetails.Add(orderDetail);
			}

			_context.SaveChanges();
		}
	}
}
