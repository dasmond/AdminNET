using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.NET.Database.Migrations.Migrations.DefaultDb
{
    public partial class v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LowCodeId",
                table: "sys_code_gen",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowCodeId",
                table: "sys_code_gen");
        }
    }
}
