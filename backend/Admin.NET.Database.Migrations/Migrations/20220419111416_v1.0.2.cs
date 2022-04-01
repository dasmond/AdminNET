using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.NET.Database.Migrations.Migrations
{
    public partial class v102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918778L,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918779L,
                column: "Icon",
                value: null);

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918780L,
                column: "Icon",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918778L,
                column: "Icon",
                value: "thunderbolt");

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918779L,
                column: "Icon",
                value: "thunderbolt");

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918780L,
                column: "Icon",
                value: "thunderbolt");
        }
    }
}
