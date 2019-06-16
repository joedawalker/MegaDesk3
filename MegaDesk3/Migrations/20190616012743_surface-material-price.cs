using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDesk3.Migrations
{
    public partial class surfacematerialprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuotes_Desks_DeskId",
                table: "DeskQuotes");

            migrationBuilder.RenameColumn(
                name: "PriceRate",
                table: "SurfaceMaterials",
                newName: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "DeskId",
                table: "DeskQuotes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "DeskQuotes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuotes_Desks_DeskId",
                table: "DeskQuotes",
                column: "DeskId",
                principalTable: "Desks",
                principalColumn: "DeskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuotes_Desks_DeskId",
                table: "DeskQuotes");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "SurfaceMaterials",
                newName: "PriceRate");

            migrationBuilder.AlterColumn<int>(
                name: "DeskId",
                table: "DeskQuotes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "DeskQuotes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuotes_Desks_DeskId",
                table: "DeskQuotes",
                column: "DeskId",
                principalTable: "Desks",
                principalColumn: "DeskId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
