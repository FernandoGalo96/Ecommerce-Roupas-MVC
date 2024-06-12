using LojaDeRoupasMVC.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeRoupasMVC.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<IdentityUser> _signinManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(SignInManager<IdentityUser> signinManager, UserManager<IdentityUser> userManager)
    {
        _signinManager = signinManager;
        _userManager = userManager;
    }

    public IActionResult Login ()
    {
        return View();
    }

    [HttpPost]

    public async Task<IActionResult> Login (LoginViewModel loginVM)
    {
        if (!ModelState.IsValid)
            return View(loginVM);

        var user = await _userManager.FindByNameAsync(loginVM.UserName);

        if (user != null)
        {
            var register = await _signinManager.PasswordSignInAsync(user, loginVM.Password,false,false);

            if (register.Succeeded) 
            {
                if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");   
                }
                return Redirect(loginVM.ReturnUrl);
            }
        }

        ModelState.AddModelError("", "Falha ao realizar o Login");
        return View(loginVM);

    }

    public IActionResult Register ()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Register (LoginViewModel loginVM)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = loginVM.UserName };
            var register = await _userManager.CreateAsync(user, loginVM.Password);

            if (register.Succeeded)
            {
                return RedirectToAction("Login","Account");
            }
            else
            {
                this.ModelState.AddModelError("Registro", "Falha ao registrar usuário");
            }
        }
        return View (loginVM);
    }

    [HttpPost]

    public async Task<IActionResult> Logout ()
    {
        HttpContext.Session.Clear();
        HttpContext.User = null;

        await _signinManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    
}
