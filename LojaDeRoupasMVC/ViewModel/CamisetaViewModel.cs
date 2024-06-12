using LojaDeRoupasMVC.Models;

namespace LojaDeRoupasMVC.ViewModel;

public class CamisetaViewModel
{
    public IEnumerable<Camiseta> Camisetas { get; set; }

    public string CategoriaAtual { get; set; }

}
