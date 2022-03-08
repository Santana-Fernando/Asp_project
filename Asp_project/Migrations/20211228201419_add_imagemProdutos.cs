using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_project.Migrations
{
    public partial class add_imagemProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagens",
                table: "Produto");

            migrationBuilder.CreateTable(
                name: "ImagensProdutos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pid_produto = table.Column<int>(nullable: true),
                    imageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensProdutos", x => x.id);
                    table.ForeignKey(
                        name: "FK_ImagensProdutos_Produto_Pid_produto",
                        column: x => x.Pid_produto,
                        principalTable: "Produto",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagensProdutos_Pid_produto",
                table: "ImagensProdutos",
                column: "Pid_produto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagensProdutos");

            migrationBuilder.AddColumn<string>(
                name: "imagens",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
