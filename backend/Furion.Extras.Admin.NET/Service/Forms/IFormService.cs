using Furion.DatabaseAccessor;
using Furion.Extras.Admin.NET.Service.Forms.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Furion.Extras.Admin.NET.Service.Forms
{
    /// <summary>
    /// 表单管理接口
    /// </summary>
    public interface IFormService
    {
        /// <summary>
        /// 获取表单列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PageResult<FormDto>> GetPageList([FromQuery] FormPageSearch input);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<FormDto> FormAdd(FormAddDto input);

        /// <summary>
        /// 更新表单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateEditForm(FormEditDto input);

        /// <summary>
        /// 删除表单
        /// </summary>
        /// <param name="input"></param>
        Task Delete(BaseId input);

        /// <summary>
        /// 发布表单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Publish(FormPublishDto input);

        /// <summary>
        /// 获取单一实体
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        Task<FormDto> Get(BaseId Input);

        /// <summary>
        /// 获取单一实体查看
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        Task<FormDto> GetView([FromQuery] BaseId Input);

        /// <summary>
        /// 获取发布表单列表
        /// </summary>
        /// <returns></returns>
        Task<dynamic> GetPulishList(long? typeId);

    }
}
