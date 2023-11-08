using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiahsJewels.Mvc.Migrations
{
    public partial class AddedshoppingCartandordersmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                schema: "dbo",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerId = table.Column<int>(type: "int", nullable: false),
                    ConsumerContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddressId = table.Column<int>(type: "int", nullable: true),
                    ModeOfPayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalSchema: "dbo",
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCartId",
                schema: "dbo",
                table: "Products",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                schema: "dbo",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                schema: "dbo",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAddressId",
                schema: "dbo",
                table: "Orders",
                column: "DeliveryAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCarts_ShoppingCartId",
                schema: "dbo",
                table: "Products",
                column: "ShoppingCartId",
                principalSchema: "dbo",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCarts_ShoppingCartId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShoppingCarts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingCartId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                schema: "dbo",
                table: "Products");
        }
    }
}
