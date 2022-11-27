using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class theend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "HouseNumber", "PostalCode", "Street" },
                values: new object[] { 1, "tira", "israel", 40, 4491500, "el zahra" });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "AccountNumber", "BranchNumber", "FirstName", "LastName", "Name", "OwnerId" },
                values: new object[] { 777777, 12, "bashar", "iraqi", 1, 999999999 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FirstName", "ImagePath", "LastName", "Password", "Role" },
                values: new object[] { 7, "Pddd2022!", "Director@perfuma.com", "Bashar", null, "Iraqi", "Pddd2022!", 0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AddressId", "Age", "BankAccountAccountNumber", "BirthDay", "BirthMonth", "BirthYear", "Email", "FirstName", "IsActivated", "JobType", "LastName", "PhoneNumber", "SalaryPerHour", "Seniority", "StartedDay", "StartedMonth", "StartedYear", "UserId" },
                values: new object[] { 999999999, 1, 23.5, 777777, "25", "7", "1999", "bashar.oroq@gmail.com", "Bashar", true, 0, "Iraqi", "0587589333", 100.5, 5.5, "18", "8", "2017", 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 999999999);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "AccountNumber",
                keyValue: 777777);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmPassword", "Email", "FirstName", "ImagePath", "LastName", "Password", "Role" },
                values: new object[] { 1, "Pddd2022!", "Director@perfuma.com", "Director", null, "Perfuma", "Pddd2022!", 0 });
        }
    }
}
