using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service
{
    public interface ISysDictRelationService
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task AddDictRelation(DictRelationInput input);
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        Task DeleteByDataId(DeleteDictRelationInput input);
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<dynamic> QueryDictDataPageList([FromQuery] DictRelationPageInput input);

    }
}
