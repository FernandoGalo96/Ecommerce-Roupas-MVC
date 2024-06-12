using LojaDeRoupasMVC.Models;
using LojaDeRoupasMVC.Repositories.Interfaces;
using LojaDeRoupasMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeRoupasMVC.Controllers;

public class CarrinhoCompraController : Controller
{
   private readonly ICamisetaRepository _camisetaRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraController(ICamisetaRepository camisetaRepository, CarrinhoCompra carrinhoCompra)
    {
        _camisetaRepository = camisetaRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    public IActionResult Index()
    {
        var itens = _carrinhoCompra.GetCarrinhoCompraItems();
        _carrinhoCompra.CarrinhoCompraItems = itens;

        var carrinhoCompraVM = new CarrinhoCompraViewModel 
        {
            CarrinhoCompra = _carrinhoCompra,
            CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
        };



        return View(carrinhoCompraVM);
    }

    public RedirectToActionResult AdicionarItemNoCarrinhoCompra (int camisetaId)
    {
        var camisetaSelecionada = _camisetaRepository.Camisetas.FirstOrDefault(c => c.CamisetaId == camisetaId);

        if (camisetaSelecionada !=  null)
        {
            _carrinhoCompra.AdicionarAoCarrinho(camisetaSelecionada);
        }
        return RedirectToAction("Index");

    }

    public RedirectToActionResult RemoverItemDoCarrinhoCompra(int camisetaId)
    {
        var camisetaSelecionada = _camisetaRepository.Camisetas.FirstOrDefault(c => c.CamisetaId == camisetaId);

        if (camisetaSelecionada != null)
        {
            _carrinhoCompra.RemoverDoCarrinho(camisetaSelecionada);
        }
        return RedirectToAction("Index");

    }



}
