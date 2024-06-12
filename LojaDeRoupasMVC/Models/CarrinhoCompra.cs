using LojaDeRoupasMVC.Banco;
using Microsoft.EntityFrameworkCore;

namespace LojaDeRoupasMVC.Models;

public class CarrinhoCompra
{
    private readonly AppDbContext _context;

    public CarrinhoCompra(AppDbContext context)
    {
        _context = context;
    }

    public string CarrinhoCompraId {  get; set; }
    public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

    public static CarrinhoCompra GetCarrinho (IServiceProvider serviceProvider)
    {
        ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = serviceProvider.GetRequiredService<AppDbContext>();

        string carrinhoId = session.GetString("CarrinhoId")??Guid.NewGuid().ToString();

        session.SetString("CarrinhoId", carrinhoId);

        return new CarrinhoCompra(context)
        {
            CarrinhoCompraId = carrinhoId,
        };
    }

    public void AdicionarAoCarrinho(Camiseta camiseta)
    {
        var carrinhoCompra = _context.CarrinhoCompraItens.SingleOrDefault(c => c.Camiseta.CamisetaId == camiseta.CamisetaId
         && c.CarrinhoCompraId == CarrinhoCompraId);

        if (carrinhoCompra == null)
        {
            carrinhoCompra = new CarrinhoCompraItem
            {
                CarrinhoCompraId = CarrinhoCompraId,
                Camiseta = camiseta,
                Quantidade = 1

            };

            _context.CarrinhoCompraItens.Add(carrinhoCompra);
        } else
        {
            carrinhoCompra.Quantidade++;
        }

        _context.SaveChanges();

    }

    public int RemoverDoCarrinho (Camiseta camiseta)
    {
        var carrinhoCompra = _context.CarrinhoCompraItens.SingleOrDefault(c => c.Camiseta.CamisetaId == camiseta.CamisetaId
         && c.CarrinhoCompraId == CarrinhoCompraId);

        var quantidadeLocal = 0;

        if (carrinhoCompra != null)
        {
            if (carrinhoCompra.Quantidade > 1)
            {
                carrinhoCompra.Quantidade--;
                quantidadeLocal = carrinhoCompra.Quantidade;
            } 

        } else
        {
            _context.CarrinhoCompraItens.Remove(carrinhoCompra);
        }

        _context.SaveChanges ();
        return quantidadeLocal;

    }

    public List<CarrinhoCompraItem> GetCarrinhoCompraItems ()
    {
        return CarrinhoCompraItems ?? (CarrinhoCompraItems = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId ==
        CarrinhoCompraId).Include(c => c.Camiseta).ToList());

    }

    public void LimparCarrinho()
    {
        var carrinhoItens = _context.CarrinhoCompraItens.Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

        _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);

        _context.SaveChanges();
    }

    public decimal GetCarrinhoCompraTotal ()
    {
        var total = _context.CarrinhoCompraItens.Where( c => c.CarrinhoCompraId == CarrinhoCompraId)
            .Select( c => c.Camiseta.Preco * c.Quantidade).Sum();
        return total;
    }
}
