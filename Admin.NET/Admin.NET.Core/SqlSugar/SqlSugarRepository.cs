using Furion;
using SqlSugar;

namespace Admin.NET.Core
{
    /// <summary>
    /// SqlSugar仓储类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlSugarRepository<T> : SimpleClient<T> where T : class, new()
    {
        public SqlSugarRepository(ISqlSugarClient context = null) : base(context) // 默认值等于null不能少
        {
            base.Context = App.GetService<ISqlSugarClient>(); // 用手动获取方式支持切换仓储

            ////base.Context.Aop.OnLogExecuting = (s, p) =>
            ////{
            ////    Console.WriteLine(s);
            ////};
        }
    }
}