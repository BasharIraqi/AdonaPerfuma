using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class recreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Number",
                table: "CreditCards",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PaymentNumber",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "CreditCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PaymentNumber",
                table: "Customers",
                column: "PaymentNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CreditCards_PaymentNumber",
                table: "Customers",
                column: "PaymentNumber",
                principalTable: "CreditCards",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
