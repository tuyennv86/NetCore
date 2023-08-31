using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreApp.Data.EF.Migrations
{
    public partial class tourdateedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "TourDates");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TourDates");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "TourDates");

            migrationBuilder.DropColumn(
                name: "EditById",
                table: "TourDates");

            migrationBuilder.DropColumn(
                name: "SeoAlias",
                table: "TourDates");

            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "TourDates");

            migrationBuilder.DropColumn(
                name: "SeoKeywords",
                table: "TourDates");

            migrationBuilder.DropColumn(
                name: "SeoPageTitle",
                table: "TourDates");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateById",
                table: "TourDates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "TourDates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "TourDates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditById",
                table: "TourDates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoAlias",
                table: "TourDates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "TourDates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoKeywords",
                table: "TourDates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoPageTitle",
                table: "TourDates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
