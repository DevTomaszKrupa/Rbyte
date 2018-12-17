using Microsoft.EntityFrameworkCore.Migrations;

namespace Rbyte.Persistance.MSSQL.Migrations
{
    public partial class ModifyProductPricesInDbProductEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StandardPrice",
                table: "Products",
                newName: "PriceWithoutMargin");

            migrationBuilder.AddColumn<decimal>(
                name: "FullPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "PriceWithoutMargin",
                table: "Products",
                newName: "StandardPrice");
        }
    }
}
