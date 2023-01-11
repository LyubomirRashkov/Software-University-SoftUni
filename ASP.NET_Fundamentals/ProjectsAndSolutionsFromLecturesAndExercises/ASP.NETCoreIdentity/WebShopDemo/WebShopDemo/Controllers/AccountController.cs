using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Data.Models.Account;
using WebShopDemo.Models;

namespace WebShopDemo.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;

		public AccountController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			var model = new RegisterViewModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = new ApplicationUser()
			{
				Email = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				UserName = model.Email,
				EmailConfirmed = true,
			};

			var result = await this.userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				await this.signInManager.SignInAsync(user, isPersistent: false);

				return RedirectToAction("Index", "Home");
			}

			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);
			}

			return View(model);
		}

		[HttpGet]
		public IActionResult Login(string? returnUrl = null)
		{
			var model = new LoginViewModel()
			{
				ReturnUrl = returnUrl,
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = await this.userManager.FindByEmailAsync(model.Email);

			if (user is not null)
			{
				var result = await this.signInManager.PasswordSignInAsync(user, model.Password, false, false);

				if (result.Succeeded)
				{
					if (model.ReturnUrl is not null)
					{
						return Redirect(model.ReturnUrl);
					}

					return RedirectToAction("Index", "Home");
				}
			}

			ModelState.AddModelError("", "Invalid login!");

			return View(model);
		}

        public async Task<IActionResult> Logout()
		{
			await this.signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
        }
    }
}
