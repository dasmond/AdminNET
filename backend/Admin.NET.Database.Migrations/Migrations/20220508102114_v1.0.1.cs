using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.NET.Database.Migrations.Migrations
{
    public partial class v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deliverables",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id主键"),
                    Issue = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "当前月份"),
                    Enterprise = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "所属企业"),
                    Acceptance = table.Column<string>(type: "nvarchar(2000)", nullable: true, comment: "上传验收单"),
                    Job = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "任务"),
                    State = table.Column<long>(type: "bigint", nullable: false, comment: "状态"),
                    Deliver = table.Column<string>(type: "nvarchar(2000)", nullable: true, comment: "上传交付物"),
                    FullName = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "创客姓名"),
                    IdCard = table.Column<string>(type: "nvarchar(200)", nullable: false, comment: "身份证号"),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true, comment: "更新时间"),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "创建者Id"),
                    CreatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "创建者名称"),
                    UpdatedUserId = table.Column<long>(type: "bigint", nullable: true, comment: "修改者Id"),
                    UpdatedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "修改者名称"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "软删除标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverables", x => x.Id);
                },
                comment: "交付物管理表");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliverables");
        }
    }
}
