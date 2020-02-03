using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_de_supermercado_com_aspnet_core.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promocaos_Produtos_ProdutoId",
                table: "Promocaos");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Promocaos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Promocaos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoDeVenda",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoDeCusto",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddForeignKey(
                name: "FK_Promocaos_Produtos_ProdutoId",
                table: "Promocaos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promocaos_Produtos_ProdutoId",
                table: "Promocaos");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Promocaos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Promocaos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "PrecoDeVenda",
                table: "Produtos",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<float>(
                name: "PrecoDeCusto",
                table: "Produtos",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddForeignKey(
                name: "FK_Promocaos_Produtos_ProdutoId",
                table: "Promocaos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
