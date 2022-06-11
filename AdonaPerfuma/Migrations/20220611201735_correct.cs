using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class correct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CrediCards_PaymentNumber",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "CrediCards");

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cvv = table.Column<int>(type: "int", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPayments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Number);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CreditCards_PaymentNumber",
                table: "Customers",
                column: "PaymentNumber",
                principalTable: "CreditCards",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CreditCards_PaymentNumber",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.CreateTable(
                name: "CrediCards",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cvv = table.Column<int>(type: "int", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPayments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrediCards", x => x.Number);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CrediCards_PaymentNumber",
                table: "Customers",
                column: "PaymentNumber",
                principalTable: "CrediCards",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
