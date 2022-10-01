using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class changeTypeOfPostalCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<long>(
                name: "PostalCode",
                table: "Addresses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

         
               
        }
    }
}
