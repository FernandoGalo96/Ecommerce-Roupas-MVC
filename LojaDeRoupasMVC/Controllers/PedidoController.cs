using LojaDeRoupasMVC.Models;
using LojaDeRoupasMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace LojaDeRoupasMVC.Controllers;

public class PedidoController : Controller
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
    {
        _pedidoRepository = pedidoRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet] 

    public IActionResult Checkout ()
    {
        return View();
    }

    [HttpPost]

    public IActionResult Checkout (Pedido Pedido)
    {
        int totalItensPedido = 0;
        decimal precoTotalPedido = 0.0m;

        //Obtém os itens do carrinho de compra

        List<CarrinhoCompraItem> items = _carrinhoCompra.GetCarrinhoCompraItems();
        _carrinhoCompra.CarrinhoCompraItems = items;

        // verificando se o item existe

        if (_carrinhoCompra.CarrinhoCompraItems.Count == 0)
        {
            ModelState.AddModelError("", "O carrinho está vazio.");
        }

        //calcular o total de itens e o total do pedido

        foreach (var item in items)
        {
            totalItensPedido += item.Quantidade;
            precoTotalPedido += (item.Camiseta.Preco * item.Quantidade);
             
        }

        //atribuindo  os valores ao pedido

        Pedido.TotalItensPedido = totalItensPedido;
        Pedido.PedidoTotal = precoTotalPedido;

        //validando os dados

        if (ModelState.IsValid)
        {
            _pedidoRepository.CriarPedido(Pedido);

            ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido.";
            ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

            _carrinhoCompra.LimparCarrinho();

            return View("~/Views/Pedido/CheckoutCompleto.cshtml", Pedido);
        }

        return View(Pedido);
    }
}
