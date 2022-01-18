using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.NET.Database.Migrations.Migrations.DefaultDb
{
    public partial class _220118 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentClass",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "班级名称"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "创建者名称"),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "修改者名称"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "软删除标记"),
                    TenantId = table.Column<long>(type: "bigint", nullable: true, comment: "租户id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClass", x => x.Id);
                },
                comment: "班级表");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "学生名称"),
                    Age = table.Column<int>(type: "integer", nullable: false, comment: "学生年龄"),
                    StudentClassId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "创建者名称"),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, comment: "修改者名称"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, comment: "软删除标记"),
                    TenantId = table.Column<long>(type: "bigint", nullable: true, comment: "租户id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_StudentClass_StudentClassId",
                        column: x => x.StudentClassId,
                        principalTable: "StudentClass",
                        principalColumn: "Id");
                },
                comment: "学生表");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentClassId",
                table: "Student",
                column: "StudentClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "StudentClass");
        }
    }
}
