using LojaDeRoupasMVC.Models;

namespace LojaDeRoupasMVC.Repositories.Interfaces;

public interface ICamisetaRepository
{
    IEnumerable<Camiseta> Camisetas { get; }
   

    Camiseta GetCamisetaById(int id);

}
