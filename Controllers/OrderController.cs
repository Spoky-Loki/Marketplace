using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Models;

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
	}
}
