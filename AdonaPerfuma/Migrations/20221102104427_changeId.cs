using AdonaPerfuma.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class changeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Employee>(
                name: "Id",
                table: "Employees",
                nullable:false,
                type:"int",
                defaultValue:0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employees",
                column: "Id");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Employee>(
                name: "Id",
                table: "Employees",
                nullable: false,
                type: "int",
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employees",
                column: "Id");


        }
    }
}
