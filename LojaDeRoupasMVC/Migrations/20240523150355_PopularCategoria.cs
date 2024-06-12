using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaDeRoupasMVC.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaNome,Descricao)" +
                "VALUES ('Camiseta Normal','Camiseta normal,confortável, feita de algodão')");
            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaNome,Descricao)" +
                "VALUES ('Camiseta Regata','Camiseta regata,confortável, feita de algodão')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
