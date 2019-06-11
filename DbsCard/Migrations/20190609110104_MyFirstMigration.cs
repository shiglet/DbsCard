using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbsCard.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Cards",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsLeader",
                table: "Cards",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPR",
                table: "Cards",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSideCard",
                table: "Cards",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsLeader",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsPR",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsSideCard",
                table: "Cards");
        }
    }
}
