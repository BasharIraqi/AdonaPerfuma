using Microsoft.EntityFrameworkCore.Migrations;

namespace AdonaPerfuma.Migrations
{
    public partial class reCreateOrderProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameTable(
                name: "OrdersProducts",
                newName: "OrderProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductBarcode" });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    ProductsBarcode = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersId, x.ProductsBarcode });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsBarcode",
                        column: x => x.ProductsBarcode,
                        principalTable: "Products",
                        principalColumn: "Barcode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsBarcode",
                table: "OrderProduct",
                column: "ProductsBarcode");

            migrationBuilder.CreateIndex(
               name: "IX_OrderProduct_OrderId",
               table: "OrderProduct",
               column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductBarcode",
                table: "OrderProducts",
                column: "ProductBarcode",
                principalTable: "Products",
                principalColumn: "Barcode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameTable(
                name: "OrderProducts",
                newName: "OrdersProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts",
                columns: new[] { "OrderId", "ProductBarcode" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Orders_OrderId",
                table: "OrdersProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Products_ProductBarcode",
                table: "OrdersProducts",
                column: "ProductBarcode",
                principalTable: "Products",
                principalColumn: "Barcode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
