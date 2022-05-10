using SqlSugar;
using System.Collections.Generic;

namespace ServiceCore.Shared
{
    /// <summary>
    /// 自定义实体过滤器接口
    /// </summary>
    public interface IEntityFilter
    {
        /// <summary>
        /// 实体过滤器
        /// </summary>
        /// <returns></returns>
        IEnumerable<TableFilterItem<object>> AddEntityFilter();
    }
}