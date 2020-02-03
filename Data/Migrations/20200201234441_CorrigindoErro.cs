using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_de_supermercado_com_aspnet_core.Data.Migrations
{
    public partial class CorrigindoErro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PrecoDeVenda",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "PrecoDeCusto",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoDeVenda",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoDeCusto",
                table: "Produtos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
