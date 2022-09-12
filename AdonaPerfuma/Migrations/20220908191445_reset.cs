using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCards_Customers_CustomerId",
                table: "CreditCards");

            migrationBuilder.DropIndex(
                name: "IX_CreditCards_CustomerId",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CreditCards");

            migrationBuilder.AddColumn<long>(
                name: "CreditCardNumber",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreditCardNumber",
                table: "Customers",
                column: "CreditCardNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CreditCards_CreditCardNumber",
                table: "Customers",
                column: "CreditCardNumber",
                principalTable: "CreditCards",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CreditCards_CreditCardNumber",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CreditCardNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreditCardNumber",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CreditCards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_CustomerId",
                table: "CreditCards",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCards_Customers_CustomerId",
                table: "CreditCards",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
