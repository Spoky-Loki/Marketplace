using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Profile()
        {
			if (User.Identity.IsAuthenticated)
			{
                User? user = _context.users.FirstOrDefault(u => u.Email == User.Claims.First().Value.ToString());
                ProfileViewModel model = new ProfileViewModel
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Address = user.Address,
                    Phone = user.Phone,
                    Email = user.Email,
                };
                return View(model);
			}
			else
				return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<ActionResult> Profile(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                User? user = await _context.users.FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user.Password == model.Password)
                {
					if (model.Name != null)
						user.Name = model.Name;
					if (model.Surname != null)
						user.Surname = model.Surname;
					if (model.Address != null)
						user.Address = model.Address;
					if (model.Phone != null)
						user.Phone = model.Phone;
					if (model.newEmail != null)
						user.Email = model.newEmail;
                    if (model.newPassword != null)
                        user.Password = model.newPassword;

                    _context.users.Update(user);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Profile", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            }
            return View(model);
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
				User? user = await _context.users.
					Include(u => u.Role).
					FirstOrDefaultAsync(u => u.Email == model.Email &&u.Password == model.Password);
				if (user != null) 
				{
					await Authenticate(user);

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
                    user = new User { Email = model.Email, Password = model.Password };
                    Role? userRole = await _context.roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    _context.users.Add(user);
					await _context.SaveChangesAsync();

					await Authenticate(user);

					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Некорректные логин и(или) пароль");
				}
			}
			return View(model);
		}

		private async Task Authenticate(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
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
