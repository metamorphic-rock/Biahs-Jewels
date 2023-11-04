using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiahsJewels.Mvc.Migrations
{
    public partial class modifyapplicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Consumer_ConsumerId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Consumer",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Users_ConsumerId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConsumerId",
                schema: "dbo",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsumerId",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Consumer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ConsumerId",
                schema: "dbo",
                table: "Users",
                column: "ConsumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Consumer_ConsumerId",
                schema: "dbo",
                table: "Users",
                column: "ConsumerId",
                principalSchema: "dbo",
                principalTable: "Consumer",
                principalColumn: "Id");
        }
    }
}
