using LojaDeRoupasMVC.Models;

namespace LojaDeRoupasMVC.Repositories.Interfaces;

public interface ICategoriaRepository
{
   IEnumerable<Categoria> Categorias { get;  }
}
