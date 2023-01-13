using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Constants;
using WebShopDemo.Core.Data.Models.Account;
using WebShopDemo.Models;

namespace WebShopDemo.Controllers
{
	public class AccountController : BaseController
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly RoleManager<IdentityRole> roleManager;

		public AccountController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.roleManager = roleManager;
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register()
		{
			var model = new RegisterViewModel();

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
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

            await this.userManager
                    .AddClaimAsync(user, new System.Security.Claims.Claim(ClaimTypeConstants.FirstName, user.FirstName 
					?? user.Email));

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
		[AllowAnonymous]
		public IActionResult Login(string? returnUrl = null)
		{
			var model = new LoginViewModel()
			{
				ReturnUrl = returnUrl,
			};

			return View(model);
		}

		[HttpPost]
		[AllowAnonymous]
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

		public async Task<IActionResult> CreateRoles()
		{
			await this.roleManager.CreateAsync(new IdentityRole(RoleConstants.Manager));

			await this.roleManager.CreateAsync(new IdentityRole(RoleConstants.Supervisor));

			await this.roleManager.CreateAsync(new IdentityRole(RoleConstants.Administrator));

			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> AddUsersToRoles()
		{
			//string email1 = "stamo.petkov@gmail.com";
			string email2 = "pesho@abv.bg";

			//var user1 = await this.userManager.FindByEmailAsync(email1);
			var user2 = await this.userManager.FindByEmailAsync(email2);

			//await this.userManager.AddToRoleAsync(user1, RoleConstants.Manager);
			await this.userManager.AddToRolesAsync(user2, new string[] { RoleConstants.Supervisor,																				   RoleConstants.Manager });

			return RedirectToAction("Index", "Home");
		}
    }
}
