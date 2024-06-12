using LojaDeRoupasMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LojaDeRoupasMVC.Banco;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
   public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Camiseta> Camisetas { get; set; }

    public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }

    public DbSet<PedidoDetalhe> PedidosDetalhes { get; set; }

}


