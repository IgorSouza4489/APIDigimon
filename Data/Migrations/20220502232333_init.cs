using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Digimon",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    img = table.Column<string>(nullable: true),
                    level = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Digimon", x => x.name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Digimon");
        }
    }
}
