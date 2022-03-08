using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_project.Migrations
{
    public partial class add_imagemProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagem",
                table: "Produto");

            migrationBuilder.CreateTable(
                name: "ImagemProduto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pid_produto = table.Column<int>(nullable: true),
                    imageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagemProduto", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImagemProduto_Produto_Pid_produto",
                        column: x => x.Pid_produto,
                        principalTable: "Produto",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagemProduto_Pid_produto",
                table: "ImagemProduto",
                column: "Pid_produto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagemProduto");

            migrationBuilder.AddColumn<string>(
                name: "imagem",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
