using LojaDeRoupasMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeRoupasMVC.Components;

public class CategoriaMenu : ViewComponent
{
    private readonly ICategoriaRepository categoriaRepository;

    public CategoriaMenu(ICategoriaRepository categoriaRepository)
    {
        this.categoriaRepository = categoriaRepository;
    }

    public IViewComponentResult Invoke ()
    {
        var categorias = categoriaRepository.Categorias.OrderBy(c => c.CategoriaNome);
        return View(categorias);
    }


}
