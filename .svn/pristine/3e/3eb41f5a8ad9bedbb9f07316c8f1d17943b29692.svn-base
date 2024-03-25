using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core.Entity.WFH_Entity
{
    /// <summary>
    /// 省市区县乡镇街道4级
    /// </summary>
    /// 

    [SugarTable(null, "省市区县乡镇街道4级")]
    [SysTable]
    public class Pub_District : EntityBaseId
    {

        /// <summary>
        /// 父级挂接id
        /// </summary>
        [SugarColumn(ColumnDescription = "父级挂接id")]
        public int pid { get; set; }
        /// <summary>
        /// 区划编码
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "区划编码", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string code { get; set; }
        /// <summary>
        /// 区划名称
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "区划名称", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "备注", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "创建时间", IsNullable = true)]
        public DateTime create_time { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "更新时间", IsNullable = true)]
        public DateTime update_time { get; set; }
        /// <summary>
        /// 状态 0 正常 -2 删除 -1 停用1
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "状态")]
        public int status { get; set; }
        /// <summary>
        /// 级次id 
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "级次id")]
        public int level { get; set; }
        /// <summary>
        /// 经纬度
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "经纬度", Length = 255)]
        [MaxLength(255)]
        public string center { get; set; }
        /// <summary>
        /// 城市编码（无用）
        /// </summary>
        /// 
        [SugarColumn(ColumnDescription = "城市编码（无用）", Length = 255, IsNullable = true)]
        [MaxLength(255)]
        public string city_code { get; set; }
    }
}
