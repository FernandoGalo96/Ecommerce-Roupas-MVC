using LojaDeRoupasMVC.Models;
using LojaDeRoupasMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeRoupasMVC.Components;

public class CarrinhoCompraResumo : ViewComponent
{
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
    {
        _carrinhoCompra = carrinhoCompra;
    }

    public IViewComponentResult Invoke()
    {
        var itens = _carrinhoCompra.GetCarrinhoCompraItems();
        _carrinhoCompra.CarrinhoCompraItems = itens;

        var carrinhoVM = new CarrinhoCompraViewModel
        {
            CarrinhoCompra = _carrinhoCompra,
            CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
        };

        return View(carrinhoVM);
    }
}