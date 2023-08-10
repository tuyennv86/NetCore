using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreApp.Data.EF.Migrations
{
    public partial class editcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreateById",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.Empty);

            migrationBuilder.AddColumn<Guid>(
                name: "EditById",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: Guid.Empty);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateById",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "EditById",
                table: "Categories");
        }
    }
}
