using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiahsJewels.Mvc.Migrations
{
    public partial class modifyconsumermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumers_Addresses_AddressId",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropIndex(
                name: "IX_Consumers_AddressId",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.RenameColumn(
                name: "MobileNumber",
                schema: "dbo",
                table: "Consumers",
                newName: "SecondaryContactNumer");

            migrationBuilder.AddColumn<DateTime>(
                name: "AccountDateCreated",
                schema: "dbo",
                table: "Consumers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PrimaryContactNumber",
                schema: "dbo",
                table: "Consumers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecondaryAddress",
                schema: "dbo",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConsumerId",
                schema: "dbo",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ConsumerId",
                schema: "dbo",
                table: "Addresses",
                column: "ConsumerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Consumers_ConsumerId",
                schema: "dbo",
                table: "Addresses",
                column: "ConsumerId",
                principalSchema: "dbo",
                principalTable: "Consumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Consumers_ConsumerId",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ConsumerId",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AccountDateCreated",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "PrimaryContactNumber",
                schema: "dbo",
                table: "Consumers");

            migrationBuilder.DropColumn(
                name: "ConsumerId",
                schema: "dbo",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "SecondaryContactNumer",
                schema: "dbo",
                table: "Consumers",
                newName: "MobileNumber");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                schema: "dbo",
                table: "Consumers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SecondaryAddress",
                schema: "dbo",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
