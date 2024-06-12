using LojaDeRoupasMVC.Banco;
using LojaDeRoupasMVC.Models;
using LojaDeRoupasMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LojaDeRoupasMVC;

    public class CamisetaRepository : ICamisetaRepository
{
    private readonly AppDbContext _context;

    public CamisetaRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Camiseta> Camisetas => _context.Camisetas.Include(c => c.Categoria);



    public Camiseta GetCamisetaById(int id)
    {
        return _context.Camisetas.FirstOrDefault( c=> c.CamisetaId == id);
    }
}

