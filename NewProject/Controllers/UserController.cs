using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewProject.Models;
using NewProject.ViewModel;

namespace NewProject.Controllers;

public class UserController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public UserController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(AppUserViewModel appUserViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(appUserViewModel);
        }

        AppUser appUser = new AppUser 
        { 
            UserName = appUserViewModel.UserName,
            Fullname = appUserViewModel.FullName,
            Email = appUserViewModel.Email

        };

        IdentityResult identityResult = await _userManager.CreateAsync(appUser, appUserViewModel.Pasword);
        if (!identityResult.Succeeded)
        {
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        return RedirectToAction("Index","Home");
    }
}
