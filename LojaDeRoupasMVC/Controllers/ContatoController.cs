using Microsoft.AspNetCore.Mvc;

namespace LojaDeRoupasMVC.Controllers;

public class ContatoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
