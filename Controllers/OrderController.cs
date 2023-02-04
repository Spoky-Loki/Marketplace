using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Models;
using System.Diagnostics;

namespace Shop.Controllers
{
	public class OrderController : Controller
	{
		private readonly IAllOrders _allOrders;

		private readonly Cart _cart;

		public OrderController(IAllOrders allOrders, Cart cart)
		{
			_allOrders = allOrders;
			_cart = cart;
		}

		public ActionResult Checkout() 
		{
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
