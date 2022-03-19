using SqlSugar;
using System;
using System.Threading.Tasks;

namespace Admin.NET.Core
{
    /// <summary>
    /// 分页拓展类
    /// </summary>
    public static class SqlSugarPagedExtensions
    {
        /// <summary>
        /// 分页拓展
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static SqlSugarPagedList<TEntity> ToPagedList<TEntity>(this ISugarQueryable<TEntity> entity, int pageIndex, int pageSize)
            where TEntity : new()
        {
            var total = 0;
            var items = entity.ToPageList(pageIndex, pageSize, ref total);
            var totalPages = (int)Math.Ceiling(total / (double)pageSize);
            return new SqlSugarPagedList<TEntity>
            {
                Page = pageIndex,
                PageSize = pageSize,
                Items = items,
                Total = total,
                TotalPages = totalPages,
                HasNextPage = pageIndex < totalPages,
                HasPrevPage = pageIndex - 1 > 0
            };
        }

        /// <summary>
        /// 分页拓展
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<SqlSugarPagedList<TEntity>> ToPagedListAsync<TEntity>(this ISugarQueryable<TEntity> entity, int pageIndex, int pageSize)
            where TEntity : new()
        {
            RefAsync<int> total = 0;
            var items = await entity.ToPageListAsync(pageIndex, pageSize, total);
            var totalPages = (int)Math.Ceiling(total / (double)pageSize);
            return new SqlSugarPagedList<TEntity>
            {
                Page = pageIndex,
                PageSize = pageSize,
                Items = items,
                Total = total,
                TotalPages = totalPages,
                HasNextPage = pageIndex < totalPages,
                HasPrevPage = pageIndex - 1 > 0
            };
        }
    }
}