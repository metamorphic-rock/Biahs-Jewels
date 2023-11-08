using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiahsJewels.Mvc.Migrations
{
    public partial class updateproductsincartmodel20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                schema: "dbo",
                table: "ProductInCarts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                schema: "dbo",
                table: "ProductInCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
