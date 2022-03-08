using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_project.Migrations
{
    public partial class addLoja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Loja_Lid_loja",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "id_loja",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "Lid_loja",
                table: "Produto",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Loja_Lid_loja",
                table: "Produto",
                column: "Lid_loja",
                principalTable: "Loja",
                principalColumn: "id_loja",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Loja_Lid_loja",
                table: "Produto");

            migrationBuilder.AlterColumn<int>(
                name: "Lid_loja",
                table: "Produto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "id_loja",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Loja_Lid_loja",
                table: "Produto",
                column: "Lid_loja",
                principalTable: "Loja",
                principalColumn: "id_loja",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
