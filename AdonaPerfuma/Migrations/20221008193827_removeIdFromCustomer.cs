using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class removeIdFromCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
               name: "Id",
               table: "Customers",
               type: "int",
               nullable: false,
               oldClrType: typeof(int),
               oldType: "int")
               .Annotation("SqlServer:Identity", "1, 1")
               .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customers");

            migrationBuilder.AlterColumn<long>(
             name: "Id",
             table: "Customers",
             type: "int",
             nullable: false,
             oldClrType: typeof(int),
             oldType: "int")
             .Annotation("SqlServer:Identity", "1, 1")
             .OldAnnotation("SqlServer:Identity", "1, 1");

        }
    }
}
