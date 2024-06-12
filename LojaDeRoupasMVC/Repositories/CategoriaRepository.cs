using LojaDeRoupasMVC.Banco;
using LojaDeRoupasMVC.Models;
using LojaDeRoupasMVC.Repositories.Interfaces;

namespace LojaDeRoupasMVC.Repositories;
public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Categoria> Categorias => _context.Categorias;


}

