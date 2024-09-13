using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroMvc.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeTestId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeTeste",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NomeTestId",
                table: "AspNetUsers",
                column: "NomeTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_NomeTestId",
                table: "AspNetUsers",
                column: "NomeTestId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_NomeTestId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NomeTestId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NomeTestId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NomeTeste",
                table: "AspNetUsers");
        }
    }
}
