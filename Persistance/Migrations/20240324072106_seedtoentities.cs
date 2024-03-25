using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class seedtoentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1L, "Admin" },
                    { 2L, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Password", "UserName" },
                values: new object[,]
                {
                    { 1L, "ad1234", "Admin" },
                    { 2L, "us1234", "User" }
                });

            migrationBuilder.InsertData(
                table: "UsersInRoles",
                columns: new[] { "ID", "RoleID", "UserID" },
                values: new object[] { 1L, 1L, 1L });

            migrationBuilder.InsertData(
                table: "UsersInRoles",
                columns: new[] { "ID", "RoleID", "UserID" },
                values: new object[] { 2L, 2L, 2L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersInRoles",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UsersInRoles",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2L);
        }
    }
}
