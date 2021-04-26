using Dilon.Core;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dilon.Application.Entity.Tables
{
    /// <summary>
    /// 基本表格
    /// </summary>
    [SugarTable("BasicTableModel", TableDescription = "基本表格")]
    public class BasicTableModel : DEntityBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnDescription = "名称", IsNullable = true)]
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [SugarColumn(ColumnDescription = "编码", IsNullable = true)]
        public string Code { get; set; }

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
