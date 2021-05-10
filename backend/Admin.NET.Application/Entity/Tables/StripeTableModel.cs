using Admin.NET.Core;
using SqlSugar;
using System;

namespace Admin.NET.Application.Entity.Tables
{
    /// <summary>
    /// 斑马线表格
    /// </summary>
    [SugarTable("StripeTableModel", TableDescription = "斑马线表格")]
    public class StripeTableModel : DEntityBase
    {
        /// <summary>
        /// 名字
        /// </summary>
        [SugarColumn(ColumnDescription = "名字", IsNullable = true)]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [SugarColumn(ColumnDescription = "性别", IsNullable = true)]
        public string Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [SugarColumn(ColumnDescription = "年龄",IsNullable = true)]
        public int Age { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        [SugarColumn(ColumnDescription = "街道", IsNullable = true)]
        public String Address { get; set; }
        /// <summary>
        /// 是否默认激活（Y-是，N-否）,只能有一个系统默认激活
        /// 用户登录后默认展示此系统菜单
        /// </summary>
        [SugarColumn(ColumnDescription = "是否默认激活", Length = 2, IsNullable = true)]
        public string Active { get; set; }

        /// <summary>
        /// 状态（字典 0正常 1停用 2删除）
        /// </summary>
        [SugarColumn(ColumnDescription = "状态")]
        public CommonStatus Status { get; set; } = CommonStatus.ENABLE;

        /// <summary>
        /// 排序
        /// </summary>
        [SugarColumn(ColumnDescription = "排序")]
        public int Sort { get; set; }
    }
}
