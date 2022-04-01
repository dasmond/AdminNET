using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.NET.Database.Migrations.Migrations
{
    public partial class v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918776L,
                columns: new[] { "Component", "Router", "Type" },
                values: new object[] { "PageView", "/codeGenerate", 0 });

            migrationBuilder.InsertData(
                table: "sys_menu",
                columns: new[] { "Id", "Application", "Code", "Component", "CreatedTime", "CreatedUserId", "CreatedUserName", "Icon", "IsDeleted", "Link", "Name", "OpenType", "Permission", "Pid", "Pids", "Redirect", "Remark", "Router", "Sort", "Status", "Type", "UpdatedTime", "UpdatedUserId", "UpdatedUserName", "Visible", "Weight" },
                values: new object[,]
                {
                    { 142307070918778L, "system", "code_gen_gen", "gen/codeGenerate/index", null, null, null, "thunderbolt", false, null, "代码生成", 0, null, 142307070918776L, "[0],[142307070918776],", null, null, "/codeGenerate/index", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918779L, "system", "code_gen_module", "gen/codeGenerate/module", null, null, null, "thunderbolt", false, null, "模块管理", 0, null, 142307070918776L, "[0],[142307070918776],", null, null, "/codeGenerate/module", 100, 0, 1, null, null, null, "Y", 1 },
                    { 142307070918780L, "system", "code_gen_assembly", "gen/codeGenerate/assembly", null, null, null, "thunderbolt", false, null, "组件管理", 0, null, 142307070918776L, "[0],[142307070918776],", null, null, "/codeGenerate/assembly", 100, 0, 1, null, null, null, "Y", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918778L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918779L);

            migrationBuilder.DeleteData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918780L);

            migrationBuilder.UpdateData(
                table: "sys_menu",
                keyColumn: "Id",
                keyValue: 142307070918776L,
                columns: new[] { "Component", "Router", "Type" },
                values: new object[] { "gen/codeGenerate/index", "/codeGenerate/index", 1 });
        }
    }
}
