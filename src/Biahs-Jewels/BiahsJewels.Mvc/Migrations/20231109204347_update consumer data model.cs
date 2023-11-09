using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiahsJewels.Mvc.Migrations
{
    public partial class updateconsumerdatamodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondaryContactNumer",
                schema: "dbo",
                table: "Consumers",
                newName: "SecondaryContactNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecondaryContactNumber",
                schema: "dbo",
                table: "Consumers",
                newName: "SecondaryContactNumer");
        }
    }
}
