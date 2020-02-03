using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_de_supermercado_com_aspnet_core.Data.Migrations
{
    public partial class ModificandoVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Quantidade",
                table: "Saidas",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "VendaId",
                table: "Saidas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_VendaId",
                table: "Saidas",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Saidas_Vendas_VendaId",
                table: "Saidas",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Saidas_Vendas_VendaId",
                table: "Saidas");

            migrationBuilder.DropIndex(
                name: "IX_Saidas_VendaId",
                table: "Saidas");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Saidas");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "Saidas");
        }
    }
}
