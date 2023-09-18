using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreApp.Data.EF.Migrations
{
    public partial class updateuserrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles");

            migrationBuilder.AddColumn<int>(
                name: "HomeOrder",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HomeStatus",
                table: "Tours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "InActive",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles");

            migrationBuilder.DropColumn(
                name: "HomeOrder",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "HomeStatus",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "InActive",
                table: "Tours");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserRoles",
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" });
        }
    }
}
