using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class deletesomefields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "PersonId1",
            table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
