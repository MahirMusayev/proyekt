using AmoebaPractica.Models;
using AmoebaPractica.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace AmoebaPractica.Controllers
{
	public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : Controller
	{
		public async Task<IActionResult> Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterVm vm)
		{
			if (!ModelState.IsValid) { return BadRequest(); }
			AppUser app1 = new AppUser
			{
				Name = vm.Name,
				Email = vm.Email,
				Surname = vm.Surname,
				UserName = vm.UserName,
			};
			IdentityResult result = await userManager.CreateAsync(app1, vm.Password);
			if (!result.Succeeded)
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
				return View(vm);
			}
			return RedirectToAction(nameof(Login));
		}
		public async Task<IActionResult> Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginVm vm)
		{
			if (!ModelState.IsValid) return BadRequest();
			AppUser user1 = await userManager.FindByNameAsync(vm.UserOrEmail);
			if (user1 == null)
			{
				user1 = await userManager.FindByEmailAsync(vm.UserOrEmail);
				if (user1 == null)
				{
					ModelState.AddModelError("", "isdifadeci adi ve yaa email yanlisdir");
				}
				return View(vm);
			}
			var ab = await signInManager.PasswordSignInAsync(user1, vm.Password, true, true);
			if (ab.Succeeded)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				return BadRequest();
			}
		}
		public async Task<IActionResult> Logout()
		{
			signInManager.SignOutAsync();
			return RedirectToAction("Index" ,"Home");
		}

	}
}
