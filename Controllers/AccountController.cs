using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.ViewModels;
using System.Security.Claims;

namespace Shop.Controllers
{
	public class AccountController : Controller
	{
		private readonly ApplicationContext _context;

		public AccountController(ApplicationContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid) 
			{
				User? user = await _context.users.FirstOrDefaultAsync(u => u.Email == model.Email &&
					u.Password == model.Password);
				if (user != null) 
				{
					await Authenticate(model.Email);

					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError("", "Некорректные логин и(или) пароль");
			}

			return View(model);
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if(ModelState.IsValid)
			{
				User? user = await _context.users.FirstOrDefaultAsync(u => u.Email == model.Email);
				if (user == null)
				{
					_context.users.Add(new User { Email = model.Email, Password = model.Password });
					await _context.SaveChangesAsync();

					await Authenticate(model.Email);

					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Пользователь с данной электронной почтой уже зарегистрирован");
				}
			}

			return View(model);
		}

		private async Task Authenticate(string userName)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
			};

			ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie",
				ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
				new ClaimsPrincipal(id));
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login", "Account");
		}
	}
}
