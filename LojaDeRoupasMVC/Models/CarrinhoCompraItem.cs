namespace LojaDeRoupasMVC.Models;

public class CarrinhoCompraItem
{
    public int CarrinhoCompraItemId { get; set; }
    public Camiseta Camiseta { get; set; }

    public int Quantidade { get; set; }

    public string CarrinhoCompraId { get; set; }

}
