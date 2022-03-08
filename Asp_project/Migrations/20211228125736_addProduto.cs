using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_project.Migrations
{
    public partial class addProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Lid_loja",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_loja",
                table: "Produto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Lid_loja",
                table: "Produto",
                column: "Lid_loja");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Loja_Lid_loja",
                table: "Produto",
                column: "Lid_loja",
                principalTable: "Loja",
                principalColumn: "id_loja",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Loja_Lid_loja",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_Lid_loja",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Lid_loja",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "id_loja",
                table: "Produto");
        }
    }
}
