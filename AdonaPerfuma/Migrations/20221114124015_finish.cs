using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class finish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "BankAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OrderDate",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ArrivalDate",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "BankAccounts",
                type: "int",
                maxLength: 9,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConfirmPassword", "Email", "FirstName", "Password" },
                values: new object[] { "Pmmm1111@", "Manager1@perfuma.com", "Manager 1", "Pmmm1111@" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConfirmPassword", "Email", "FirstName", "Password", "Role" },
                values: new object[] { "Pmmm2222@", "Manager2@perfuma.com", "Manager 2", "Pmmm2222@", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FirstName", "ImagePath", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { 4, "Pmmm3333@", "Manager3@perfuma.com", "Manager 3", null, "Perfuma", "Pmmm3333@", 1 },
                    { 5, "Pggg111$", "General1@perfuma.com", "Employee 1", null, "Perfuma", "Pggg111$", 2 },
                    { 6, "Pggg222$", "General2@perfuma.com", "Employee 2", null, "Perfuma", "Pggg222$", 2 },
                    { 7, "Pggg333$", "General3@perfuma.com", "Employee 3", null, "Perfuma", "Pggg333$", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "BankAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "OrderDate",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ArrivalDate",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConfirmPassword", "Email", "FirstName", "Password" },
                values: new object[] { "Pmmm987458", "Manager@perfuma.com", "Manager", "Pmmm987458" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConfirmPassword", "Email", "FirstName", "Password", "Role" },
                values: new object[] { "Pggg7458", "General@perfuma.com", "Employee", "Pggg7458", 2 });
        }
    }
}
