using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_de_supermercado_com_aspnet_core.Data.Migrations
{
    public partial class CorrigindoErronovamente1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Promocaos",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Produtos",
                newName: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Promocaos",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Produtos",
                newName: "status");
        }
    }
}
