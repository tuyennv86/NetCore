using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreApp.Data.EF.Migrations
{
    public partial class editFun1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryTypeID",
                table: "Functions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsType",
                table: "Functions",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryTypeID",
                table: "Functions");

            migrationBuilder.DropColumn(
                name: "IsType",
                table: "Functions");
        }
    }
}
