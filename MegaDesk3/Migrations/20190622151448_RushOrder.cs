using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDesk3.Migrations
{
    public partial class RushOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RushOrderTypes",
                columns: table => new
                {
                    RushOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RushOrderName = table.Column<string>(nullable: true),
                    TierOnePrice = table.Column<decimal>(nullable: false),
                    TierTwoPrice = table.Column<decimal>(nullable: false),
                    TierThreePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RushOrderTypes", x => x.RushOrderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RushOrderTypes");
        }
    }
}
