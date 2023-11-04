using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiahsJewels.Mvc.Migrations
{
    public partial class addedpropertiesonconsumermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Consumer_ConsumerId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ConsumerId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consumer",
                schema: "dbo",
                table: "Consumer");

            migrationBuilder.RenameTable(
                name: "Consumer",
                schema: "dbo",
                newName: "Consumers",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                schema: "dbo",
                table: "Consumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                schema: "dbo",
                table: "Consumers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                schema: "dbo",
                table: "Consumers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Consumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "Consumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "dbo",
                table: "Consumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                schema: "dbo",
                table: "Consumers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileProfilePath",
                schema: "dbo",
                table: "Consumers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consumers",
                schema: "dbo",
                table: "Consumers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryAddress = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ConsumerId",
                schema: "dbo",
                table: "Users",
                column: "ConsumerId",
                unique: true,
                filter: "[ConsumerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_AddressId",
                schema: "dbo",
                table: "Consumers",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumers_Addresses_AddressId",
                schema: "dbo",
                table: "Consumers",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Consumers_ConsumerId",
                schema: "dbo",
                table: "Users",
                column: "ConsumerId",
                principalSchema: "dbo",
                principalTable: "Consumers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Addresses_AddressId",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Consumers_ConsumerId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Users_ConsumerId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consumers",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropIndex(
                name: "IX_Consumers_AddressId",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "ProfileProfilePath",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.RenameTable(
                name: "Consumers",
                schema: "dbo",
                newName: "Consumer",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consumer",
                schema: "dbo",
                table: "Consumer",
                column: "Id");

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
