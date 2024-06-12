using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaDeRoupasMVC.Migrations
{
    /// <inheritdoc />
    public partial class PopularCamiseta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Camisetas (Nome,Tamanho,Descricao,Preco,ImagemUrl,EmEstoque,CategoriaId)" +
                "VALUES ('Camiseta Preta','G','linda camiseta preta masculina',60,'https://cdn.awsli.com.br/2500x2500/1636/1636598/produto/62562812/camiseta-masculina-soldier-preta-belica-f83ae963.jpg'," +
                "1,1)");
            migrationBuilder.Sql("INSERT INTO Camisetas (Nome,Tamanho,Descricao,Preco,ImagemUrl,EmEstoque,CategoriaId)" +
                "VALUES ('Camiseta Branca','G','linda camiseta branca masculina',66,'https://atacadodecamisetas.com.br/216-large_default/camiseta-branca-masculina.jpg'," +
                "1,1)");
            migrationBuilder.Sql("INSERT INTO Camisetas (Nome,Tamanho,Descricao,Preco,ImagemUrl,EmEstoque,CategoriaId)" +
               "VALUES ('Camiseta Rosa','G','linda camiseta rosa masculina',100,'https://superestampas.com.br/wp-content/uploads/2018/09/Camiseta-de-algod%C3%A3o-masculina-rosa-pink-gola-redonda.jpg'," +
               "1,1)");
            migrationBuilder.Sql("INSERT INTO Camisetas (Nome,Tamanho,Descricao,Preco,ImagemUrl,EmEstoque,CategoriaId)" +
               "VALUES ('Regata Preta','G','linda camiseta regata preta masculina',100,'https://loja.pluriforme.com.br/media/catalog/product/cache/2/image/9df78eab33525d08d6e5fb8d27136e95/C/a/Camiseta_Regata_Algodao_Canelada_Preta_1.jpg'," +
               "1,2)");
            migrationBuilder.Sql("INSERT INTO Camisetas (Nome,Tamanho,Descricao,Preco,ImagemUrl,EmEstoque,CategoriaId)" +
               "VALUES ('Regata Branca','G','linda camiseta regata branca masculina',90,'https://cdn.awsli.com.br/2500x2500/695/695336/produto/33710470/6090bffb05.jpg'," +
               "1,2)");
            migrationBuilder.Sql("INSERT INTO Camisetas (Nome,Tamanho,Descricao,Preco,ImagemUrl,EmEstoque,CategoriaId)" +
               "VALUES ('Regata Rosa','G','linda camiseta regata rosa masculina',90,'https://static.ferju.com.br/public/ferju/imagens/produtos/regata-masculina-adulto-basica-com-detalhe-logo-13-06-0611-gangster-rosa-6419e40285a67.jpg'," +
               "1,2)");





        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
