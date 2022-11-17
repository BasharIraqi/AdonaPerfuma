using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class done : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FirstName", "ImagePath", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { 2, "Pmmm1111@", "Manager1@perfuma.com", "Manager 1", null, "Perfuma", "Pmmm1111@", 1 },
                    { 3, "Pmmm2222@", "Manager2@perfuma.com", "Manager 2", null, "Perfuma", "Pmmm2222@", 1 },
                    { 4, "Pmmm3333@", "Manager3@perfuma.com", "Manager 3", null, "Perfuma", "Pmmm3333@", 1 },
                    { 5, "Pggg111$", "General1@perfuma.com", "Employee 1", null, "Perfuma", "Pggg111$", 2 },
                    { 6, "Pggg222$", "General2@perfuma.com", "Employee 2", null, "Perfuma", "Pggg222$", 2 },
                    { 7, "Pggg333$", "General3@perfuma.com", "Employee 3", null, "Perfuma", "Pggg333$", 2 }
                });
        }
    }
}
