using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class fixed_field_names_in_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BankAccounts_bankAccountAccountNumber",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "bankAccountAccountNumber",
                table: "Employees",
                newName: "BankAccountAccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_bankAccountAccountNumber",
                table: "Employees",
                newName: "IX_Employees_BankAccountAccountNumber");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Addresses_AddressId",
                table: "Employees",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BankAccounts_BankAccountAccountNumber",
                table: "Employees",
                column: "BankAccountAccountNumber",
                principalTable: "BankAccounts",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Addresses_AddressId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_BankAccounts_BankAccountAccountNumber",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AddressId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "BankAccountAccountNumber",
                table: "Employees",
                newName: "bankAccountAccountNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_BankAccountAccountNumber",
                table: "Employees",
                newName: "IX_Employees_bankAccountAccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_BankAccounts_bankAccountAccountNumber",
                table: "Employees",
                column: "bankAccountAccountNumber",
                principalTable: "BankAccounts",
                principalColumn: "AccountNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
