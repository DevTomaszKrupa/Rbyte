using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbyte.Persistance.MySql.Migrations
{
    public partial class AddTaxEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaxId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    TaxId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.TaxId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TaxId",
                table: "Products",
                column: "TaxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Taxes_TaxId",
                table: "Products",
                column: "TaxId",
                principalTable: "Taxes",
                principalColumn: "TaxId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Taxes_TaxId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropIndex(
                name: "IX_Products_TaxId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "Products");
        }
    }
}
