using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_project.Migrations
{
    public partial class criando_tabelas_restantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvaliacaoLoja",
                columns: table => new
                {
                    id_avaliacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nota = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lid_loja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoLoja", x => x.id_avaliacao);
                    table.ForeignKey(
                        name: "FK_AvaliacaoLoja_Loja_Lid_loja",
                        column: x => x.Lid_loja,
                        principalTable: "Loja",
                        principalColumn: "id_loja",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoProduto",
                columns: table => new
                {
                    id_avaliacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nota = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pid_produto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoProduto", x => x.id_avaliacao);
                    table.ForeignKey(
                        name: "FK_AvaliacaoProduto_Produto_Pid_produto",
                        column: x => x.Pid_produto,
                        principalTable: "Produto",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_pedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data_final = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uid_usuario = table.Column<int>(type: "int", nullable: false),
                    Lid_loja = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id_pedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Loja_Lid_loja",
                        column: x => x.Lid_loja,
                        principalTable: "Loja",
                        principalColumn: "id_loja");
                    table.ForeignKey(
                        name: "FK_Pedido_Usuario_Uid_usuario",
                        column: x => x.Uid_usuario,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "ItemPedido",
                columns: table => new
                {
                    id_item_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Proid_produto = table.Column<int>(type: "int", nullable: false),
                    Peid_pedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedido", x => x.id_item_pedido);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Pedido_Peid_pedido",
                        column: x => x.Peid_pedido,
                        principalTable: "Pedido",
                        principalColumn: "id_pedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Produto_Proid_produto",
                        column: x => x.Proid_produto,
                        principalTable: "Produto",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoLoja_Lid_loja",
                table: "AvaliacaoLoja",
                column: "Lid_loja");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoProduto_Pid_produto",
                table: "AvaliacaoProduto",
                column: "Pid_produto");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_Peid_pedido",
                table: "ItemPedido",
                column: "Peid_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_Proid_produto",
                table: "ItemPedido",
                column: "Proid_produto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Lid_loja",
                table: "Pedido",
                column: "Lid_loja");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Uid_usuario",
                table: "Pedido",
                column: "Uid_usuario",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoLoja");

            migrationBuilder.DropTable(
                name: "AvaliacaoProduto");

            migrationBuilder.DropTable(
                name: "ItemPedido");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
