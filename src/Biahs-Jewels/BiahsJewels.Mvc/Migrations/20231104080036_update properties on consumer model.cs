using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiahsJewels.Mvc.Migrations
{
    public partial class updatepropertiesonconsumermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileProfilePath",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicturePath",
                schema: "dbo",
                table: "Consumers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicturePath",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.AddColumn<string>(
                name: "ProfileProfilePath",
                schema: "dbo",
                table: "Consumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
