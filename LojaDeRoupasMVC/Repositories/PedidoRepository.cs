using LojaDeRoupasMVC.Banco;
using LojaDeRoupasMVC.Models;
using LojaDeRoupasMVC.Repositories.Interfaces;

namespace LojaDeRoupasMVC.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoRepository(AppDbContext context, CarrinhoCompra carrinhoCompra)
    {
        _context = context;
        _carrinhoCompra = carrinhoCompra;
    }

    public void CriarPedido(Pedido pedido)
    {

        pedido.PedidoEnviado = DateTime.Now;
        _context.Add(pedido);
        _context.SaveChanges();

        var carrinhoCompras = _carrinhoCompra.GetCarrinhoCompraItems();

        foreach (var carrinho in carrinhoCompras)
        {
            var pedidoDetail = new PedidoDetalhe
            {
                Quantidade = carrinho.Quantidade,
                CamisetaId = carrinho.Camiseta.CamisetaId,
                PedidoId = pedido.PedidoId,
                Preco = carrinho.Camiseta.Preco

            };
            _context.PedidosDetalhes.Add(pedidoDetail);
        }

        _context.SaveChanges();

        
    }
}
