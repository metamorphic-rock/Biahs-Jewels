using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiahsJewels.Mvc.Migrations
{
    public partial class addnewfieldsinshoppingcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCarts_ShoppingCartId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingCartId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                schema: "dbo",
                table: "Products");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                schema: "dbo",
                table: "ShoppingCarts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductInCarts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInCarts_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalSchema: "dbo",
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCarts_ProductId",
                schema: "dbo",
                table: "ProductInCarts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCarts_ShoppingCartId",
                schema: "dbo",
                table: "ProductInCarts",
                column: "ShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInCarts",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "dbo",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                schema: "dbo",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCartId",
                schema: "dbo",
                table: "Products",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCarts_ShoppingCartId",
                schema: "dbo",
                table: "Products",
                column: "ShoppingCartId",
                principalSchema: "dbo",
                principalTable: "ShoppingCarts",
                principalColumn: "Id");
        }
    }
}
