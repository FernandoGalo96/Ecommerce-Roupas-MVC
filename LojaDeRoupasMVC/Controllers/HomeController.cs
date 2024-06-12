using LojaDeRoupasMVC.Models;
using LojaDeRoupasMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaDeRoupasMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICamisetaRepository _camisetaRepository;

        public HomeController(ICamisetaRepository camisetaRepository)
        {
            _camisetaRepository = camisetaRepository;
        }

        public IActionResult Index()
        {
            
            return View();
        }

     

        
    }
}
