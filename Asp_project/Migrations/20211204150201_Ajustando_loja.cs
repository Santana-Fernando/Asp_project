using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_project.Migrations
{
    public partial class Ajustando_loja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cnpj",
                table: "Loja");

            migrationBuilder.AddColumn<string>(
                name: "cpf_cnpj",
                table: "Loja",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "fotoLoja",
                table: "Loja",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cpf_cnpj",
                table: "Loja");

            migrationBuilder.DropColumn(
                name: "fotoLoja",
                table: "Loja");

            migrationBuilder.AddColumn<string>(
                name: "cnpj",
                table: "Loja",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
