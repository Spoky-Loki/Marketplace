using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Models;

namespace Shop.Controllers
{
	public class OrderController : Controller
	{
		private readonly ApplicationContext _context;

		private readonly IAllOrders _allOrders;

		private readonly Cart _cart;

		public OrderController(IAllOrders allOrders, Cart cart, ApplicationContext context)
		{
			_allOrders = allOrders;
			_cart = cart;
			_context = context;
		}

		public ActionResult Checkout() 
		{
			if(User.Identity.IsAuthenticated)
			{
				User? user = _context.users.FirstOrDefault(u => u.Email == User.Claims.First().Value.ToString());
				Order model = new Order
				{
					name = user.Name,
					surname = user.Surname,
					adress = user.Address,
					phone = user.Phone,
					email = user.Email,
				};
				return View(model);
			}
			else
				return View();
		}

		[HttpPost]
		public ActionResult Checkout(Order order)
		{
			_cart.cartItems = _cart.GetCartItems();
			if (_cart.cartItems.Count == 0 ) 
			{
				ModelState.AddModelError("", "У вас должны быть товары в корзине!");
			}

			if (ModelState.IsValid)
			{
				_allOrders.createOrder(order);
				return RedirectToAction("Complete");
			}

			return View(order);
		}

		public IActionResult Complete() 
		{
			ViewBag.Message = "Заказ успешно обработан!";

			return View();
		}
	}
}
