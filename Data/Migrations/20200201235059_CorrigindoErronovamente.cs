using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_de_supermercado_com_aspnet_core.Data.Migrations
{
    public partial class CorrigindoErronovamente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Porcentagem",
                table: "Promocaos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Porcentagem",
                table: "Promocaos",
                type: "int",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
