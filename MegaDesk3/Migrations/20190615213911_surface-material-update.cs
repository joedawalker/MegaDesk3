using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDesk3.Migrations
{
    public partial class surfacematerialupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SurfaceMaterials",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SurfaceMaterials");
        }
    }
}
