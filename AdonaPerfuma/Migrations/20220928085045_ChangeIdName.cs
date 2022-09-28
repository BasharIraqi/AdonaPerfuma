using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class ChangeIdName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

           

          
          

        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        

          

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

         

          

        
        }
    }
}
