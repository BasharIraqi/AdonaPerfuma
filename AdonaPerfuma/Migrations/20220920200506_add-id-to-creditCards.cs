using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class addidtocreditCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CreditCards",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreditCardId",
                table: "Customers",
                column: "CreditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CreditCards_CreditCardId",
                table: "Customers",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CreditCards_CreditCardId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CreditCardId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CreditCards");

            migrationBuilder.AddColumn<long>(
                name: "CreditCardNumber",
                table: "Customers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Number",
                table: "CreditCards",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards",
                column: "Number");

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
    }
}
