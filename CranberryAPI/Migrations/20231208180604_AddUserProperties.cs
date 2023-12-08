using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CranberryAPI.Migrations
{
    public partial class AddUserProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvgSmokedDaily",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CigsPerPack",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PricePerPack",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "QuitDate",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgSmokedDaily",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CigsPerPack",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PricePerPack",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "QuitDate",
                table: "AspNetUsers");
        }
    }
}
