﻿// <auto-generated />
using System;
using LojaDeRoupasMVC.Banco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LojaDeRoupasMVC.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240523203104_AdicionandoCarrinho")]
    partial class AdicionandoCarrinho
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LojaDeRoupasMVC.Models.Camiseta", b =>
                {
                    b.Property<int>("CamisetaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int")
                        .HasColumnName("CategoriaId");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("EmEstoque")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("CamisetaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Camisetas");
                });

            modelBuilder.Entity("LojaDeRoupasMVC.Models.CarrinhoCompraItem", b =>
                {
                    b.Property<int>("CarrinhoCompraItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CamisetaId")
                        .HasColumnType("int");

                    b.Property<int>("CarrinhoCompraId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("CarrinhoCompraItemId");

                    b.HasIndex("CamisetaId");

                    b.ToTable("CarrinhoCompraItens");
                });

            modelBuilder.Entity("LojaDeRoupasMVC.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoriaNome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("LojaDeRoupasMVC.Models.Camiseta", b =>
                {
                    b.HasOne("LojaDeRoupasMVC.Models.Categoria", "Categoria")
                        .WithMany("Camisetas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("LojaDeRoupasMVC.Models.CarrinhoCompraItem", b =>
                {
                    b.HasOne("LojaDeRoupasMVC.Models.Camiseta", "Camiseta")
                        .WithMany()
                        .HasForeignKey("CamisetaId");

                    b.Navigation("Camiseta");
                });

            modelBuilder.Entity("LojaDeRoupasMVC.Models.Categoria", b =>
                {
                    b.Navigation("Camisetas");
                });
#pragma warning restore 612, 618
        }
    }
}
