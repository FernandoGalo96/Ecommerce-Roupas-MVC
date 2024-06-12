using LojaDeRoupasMVC.Models;
using LojaDeRoupasMVC.Repositories.Interfaces;
using LojaDeRoupasMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace LANCHESMVC.Controllers;

public class CamisetaController : Controller
{
    private readonly ICamisetaRepository _camisetaRepository;

    public CamisetaController(ICamisetaRepository camisetaRepository)
    {
        _camisetaRepository = camisetaRepository;
    }

    public IActionResult List(string categoria)
    {
        IEnumerable<Camiseta> camisetas;
        string categoriaAtual = string.Empty;

        if (string.IsNullOrEmpty(categoria))
        {
            camisetas = _camisetaRepository.Camisetas.OrderBy(l => l.CamisetaId);
            categoriaAtual = "Todas as camisetas";
        }
        else
        {
            if (string.Equals("Camiseta Normal", categoria, StringComparison.OrdinalIgnoreCase))
            {
                camisetas = _camisetaRepository.Camisetas
                    .Where(l => l.Categoria.CategoriaNome.Equals("Camiseta Normal"))
                    .OrderBy(l => l.Nome);
            }
            else
            {
                camisetas = _camisetaRepository.Camisetas
                   .Where(l => l.Categoria.CategoriaNome.Equals("Camiseta Regata"))
                   .OrderBy(l => l.Nome);
            }
            categoriaAtual = categoria;
        }

        var camisetaVM = new CamisetaViewModel
        {
            Camisetas = camisetas,
            CategoriaAtual = categoriaAtual
        };

        return View(camisetaVM);
    }

    public IActionResult Details (int camisetaId)
    {
        var camisetas = _camisetaRepository.Camisetas.FirstOrDefault(c => c.CamisetaId == camisetaId);
        return View (camisetas);
    }

    public IActionResult Search(string searchString)
    {
        IEnumerable<Camiseta> camisetas;
        string categoriaAtual = string.Empty;

        if (string.IsNullOrEmpty(searchString))
        {
           camisetas = _camisetaRepository.Camisetas.OrderBy(c => c.CamisetaId);
            categoriaAtual = "Todas as camisetas";

        }
        else
        {
            camisetas = _camisetaRepository.Camisetas.Where(c => c.Nome.ToLower().Contains(searchString.ToLower()));

            if(camisetas.Any())
            {
                categoriaAtual = "Camisetas";
            }
            else
            {
                categoriaAtual = "Nenhuma camiseta encontrada!";
            }
        } 
        return View("~/Views/Camiseta/List.cshtml", new CamisetaViewModel
        {
            Camisetas = camisetas,
            CategoriaAtual = categoriaAtual
        });
    }

}

