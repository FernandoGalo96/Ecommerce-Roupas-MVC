using LojaDeRoupasMVC;
using LojaDeRoupasMVC.Banco;
using LojaDeRoupasMVC.Models;
using LojaDeRoupasMVC.Repositories;
using LojaDeRoupasMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Adiciona a configuração dos secrets
builder.Configuration.AddUserSecrets<Program>();

// Adiciona serviços ao contêiner.
builder.Services.AddControllersWithViews();

// Obtém a string de conexão
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddDbContext<AppDbContext>(opts =>
opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().
    AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddTransient<ICamisetaRepository, CamisetaRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));


builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "categoriaFiltro",
    pattern: "Camiseta/{action}/{categoria?}",
    defaults: new { Controller = "Camiseta", action = "List" }
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
