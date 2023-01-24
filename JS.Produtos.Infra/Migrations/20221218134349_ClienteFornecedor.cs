using Microsoft.EntityFrameworkCore.Migrations;

namespace JS.Produtos.Infra.Migrations
{
    public partial class ClienteFornecedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Entrada",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Saida",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entrada",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Saida",
                table: "Produtos");
        }
    }
}
