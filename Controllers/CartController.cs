﻿using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
	public class CartController : Controller
	{
		private readonly IProducts _product;
		private readonly Cart _cart;

		public CartController(IProducts product, Cart cart)
		{
			_product = product;
			_cart = cart;
		}

		public ViewResult Index() 
		{
			var items = _cart.GetCartItems();
			_cart.cartItems = items;

			var obj = new CartViewModel {
				cart = _cart,
			};

			return View(obj);
		}

		public RedirectToActionResult AddToCart(int id)
		{
			var item = _product.products.FirstOrDefault(i => i.id == id);

			if (item != null) 
			{
				_cart.AddToCart(item);
			}

			return RedirectToAction("Index");
		}

        public RedirectToActionResult RemoveFromCart(int id)
        {
            var item = _cart.GetCartItems().FirstOrDefault(i => i.id == id);

            if (item != null)
            {
                _cart.RemoveFromCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
