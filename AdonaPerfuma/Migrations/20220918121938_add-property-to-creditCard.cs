using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class addpropertytocreditCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpiredDate",
                table: "CreditCards",
                newName: "ExpiredYear");

            migrationBuilder.AddColumn<string>(
                name: "ExpiredMonth",
                table: "CreditCards",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiredMonth",
                table: "CreditCards");

            migrationBuilder.RenameColumn(
                name: "ExpiredYear",
                table: "CreditCards",
                newName: "ExpiredDate");
        }
    }
}
