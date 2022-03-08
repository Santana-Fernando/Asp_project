using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp_project.Migrations
{
    public partial class deixandoPossibilidadeDeValorNulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Usuario_Uid_usuario",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_Uid_usuario",
                table: "Endereco");

            migrationBuilder.AlterColumn<int>(
                name: "Uid_usuario",
                table: "Endereco",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Uid_usuario",
                table: "Endereco",
                column: "Uid_usuario",
                unique: true,
                filter: "[Uid_usuario] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Usuario_Uid_usuario",
                table: "Endereco",
                column: "Uid_usuario",
                principalTable: "Usuario",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Usuario_Uid_usuario",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_Uid_usuario",
                table: "Endereco");

            migrationBuilder.AlterColumn<int>(
                name: "Uid_usuario",
                table: "Endereco",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Uid_usuario",
                table: "Endereco",
                column: "Uid_usuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Usuario_Uid_usuario",
                table: "Endereco",
                column: "Uid_usuario",
                principalTable: "Usuario",
                principalColumn: "id_usuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
