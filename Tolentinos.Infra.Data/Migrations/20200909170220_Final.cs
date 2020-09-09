using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tolentinos.Infra.Data.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrinho",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<long>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    IdPai = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Categoria_IdPai",
                        column: x => x.IdPai,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMarca = table.Column<long>(nullable: false),
                    IdCategoria = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 1000, nullable: false),
                    DescricaoNoHtml = table.Column<string>(maxLength: 500, nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Tamanho = table.Column<string>(maxLength: 50, nullable: false),
                    Cor = table.Column<string>(maxLength: 50, nullable: false),
                    QuantidadeDisponivel = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Marca_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagemProduto",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(maxLength: 255, nullable: false),
                    IdProduto = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagemProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagemProduto_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCarrinho",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCarrinho = table.Column<long>(nullable: false),
                    IdProduto = table.Column<long>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarrinho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCarrinho_Carrinho_IdCarrinho",
                        column: x => x.IdCarrinho,
                        principalTable: "Carrinho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCarrinho_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "IdPai", "Nome", "Ordem" },
                values: new object[] { 1L, null, "Informática", 0 });

            migrationBuilder.InsertData(
                table: "Marca",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1L, "Ubiquiti" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "IdPai", "Nome", "Ordem" },
                values: new object[] { 2L, 1L, "Equipamentos de Rede", 0 });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Cor", "Descricao", "DescricaoNoHtml", "IdCategoria", "IdMarca", "Nome", "QuantidadeDisponivel", "Tamanho", "Valor" },
                values: new object[] { 1L, "Branco", @"Funções: Access point indoor<br>
Tipo de conexão: Sem fio<br>
Velocidade wireless: 1167 Mbps<br>
Frequências: 2.4 GHz,5 GHz<br>
Tipo de freqüência: Banda dupla<br>
Quantidade total de ports: 1<br>
Padrões wireless: IEEE 802.11a / b / g / n / r / k / v / ac<br>
Peso: 170 g<br>
Altura x Largura x Profundidade: 160 mm x 160 mm x 31.45 mm<br>", @"Funções: Access point indoor
Tipo de conexão: Sem fio
Velocidade wireless: 1167 Mbps
Frequências: 2.4 GHz,
                    5 GHz
Tipo de freqüência: Banda dupla
Quantidade total de ports: 1
Padrões wireless: IEEE 802.11a / b / g / n / r / k / v / ac
Peso: 170 g
Altura x Largura x Profundidade: 160 mm x 160 mm x 31.45 mm", 2L, 1L, "Unifi Pro 5G", 10L, "Único", 769.90m });

            migrationBuilder.InsertData(
                table: "ImagemProduto",
                columns: new[] { "Id", "IdProduto", "Url" },
                values: new object[] { 1L, 1L, "https://teste-tolentinos.s3-sa-east-1.amazonaws.com/produtos/Unifi-1.png" });

            migrationBuilder.InsertData(
                table: "ImagemProduto",
                columns: new[] { "Id", "IdProduto", "Url" },
                values: new object[] { 2L, 1L, "https://teste-tolentinos.s3-sa-east-1.amazonaws.com/produtos/Unifi-2.png" });

            migrationBuilder.InsertData(
                table: "ImagemProduto",
                columns: new[] { "Id", "IdProduto", "Url" },
                values: new object[] { 3L, 1L, "https://teste-tolentinos.s3-sa-east-1.amazonaws.com/produtos/Unifi-3.png" });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_IdPai",
                table: "Categoria",
                column: "IdPai");

            migrationBuilder.CreateIndex(
                name: "IX_ImagemProduto_IdProduto",
                table: "ImagemProduto",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_IdCarrinho",
                table: "ItemCarrinho",
                column: "IdCarrinho");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_IdProduto",
                table: "ItemCarrinho",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdCategoria",
                table: "Produto",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdMarca",
                table: "Produto",
                column: "IdMarca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagemProduto");

            migrationBuilder.DropTable(
                name: "ItemCarrinho");

            migrationBuilder.DropTable(
                name: "Carrinho");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");
        }
    }
}
