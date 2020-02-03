using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_de_supermercado_com_aspnet_core.Data.Migrations
{
    public partial class AdcStatusNaCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Categorias",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categorias");
        }
    }
}
