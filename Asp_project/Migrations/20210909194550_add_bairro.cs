using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_project.Migrations
{
    public partial class add_bairro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pedido_Uid_usuario",
                table: "Pedido");

            migrationBuilder.AddColumn<string>(
                name: "bairro",
                table: "Endereco",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Uid_usuario",
                table: "Pedido",
                column: "Uid_usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pedido_Uid_usuario",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "bairro",
                table: "Endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Uid_usuario",
                table: "Pedido",
                column: "Uid_usuario",
                unique: true);
        }
    }
}
