using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_project.Migrations
{
    public partial class remove_descricaoLoja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descicao_funcionamento",
                table: "Loja");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descicao_funcionamento",
                table: "Loja",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
