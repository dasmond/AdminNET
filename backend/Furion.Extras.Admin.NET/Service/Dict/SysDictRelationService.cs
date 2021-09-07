using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service
{
    /// <summary>
    /// 字典关系服务
    /// </summary>
    [ApiDescriptionSettings(Name = "DictRelation", Order = 100)]
    [AllowAnonymous]
    public class SysDictRelationService : ISysDictRelationService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SysDictRelation> _sysDictRelationRep;  // 字典关系表仓储
        private readonly IUserManager _userManager;

        public SysDictRelationService(IRepository<SysDictRelation> sysDictRelationRep, IUserManager userManager)
        {
            _sysDictRelationRep = sysDictRelationRep;
            _userManager = userManager;
        }

        [HttpPost("/sysDictRelation/add")]
        public async Task AddDictRelation(DictRelationInput input)
        {
            if (!input.DataRelationIds.Any())
                return;
            var exists = await _sysDictRelationRep.Where(u => u.DataId == input.DataId
            && input.DataRelationIds.Contains(u.DataRelationId), false).ToListAsync();
            var noExistIds = input.DataRelationIds.Except(exists.Select(u => u.DataRelationId));
            if (!noExistIds.Any())
                return;
            var relations = noExistIds.Select(u => new SysDictRelation()
            {
                Id = Yitter.IdGenerator.YitIdHelper.NextId(),
                DataId = input.DataId,
                DataRelationId = u,
                TypeId = input.TypeId,
                CreatedTime = DateTime.Now,
                CreatedUserId = 0,
                CreatedUserName = string.Empty,
                IsDeleted = false,
                UpdatedTime = DateTime.Now,
                UpdatedUserId = 0,
                UpdatedUserName = string.Empty
            });
            await _sysDictRelationRep.InsertAsync(relations);
        }

        [HttpPost("/sysDictRelation/delete")]
        public async Task DeleteByDataId(DeleteDictRelationInput input)
        {
            var dictRelation = await _sysDictRelationRep.FirstOrDefaultAsync(u => u.DataId == input.DataId && u.DataRelationId == input.DataRelationId);
            if (dictRelation == null) throw Oops.Oh(ErrorCode.D3004);
            await dictRelation.DeleteAsync();
        }

        [HttpGet("/sysDictRelation/page")]
        public async Task<dynamic> QueryDictDataPageList([FromQuery] DictRelationPageInput input)
        {
            bool supperAdmin = _userManager.SuperAdmin;
            var dictRelations = await _sysDictRelationRep
                .Where(u=> u.DataId == input.DataId)
                .Where(u=> input.TypeId < 1 || u.TypeId == input.TypeId)
                .Where(u=> string.IsNullOrEmpty(input.DataRelationVal) || u.SysDictDataRelaiton.Value.Contains(input.DataRelationVal))
                .OrderByDescending(u=>u.CreatedTime)
                .Select(u=> new DictRelationOutput()
                {
                    DataId = u.DataId,
                    DataRelationId = u.DataRelationId,
                    TypeId = u.TypeId,
                    DataRelationValue = u.SysDictDataRelaiton.Value,
                    TypeName = u.SysDictDataRelaiton.SysDictType.Name
                })
                .ToPagedListAsync(input.PageNo, input.PageSize);

            return XnPageResult<DictRelationOutput>.PageResult(dictRelations);
        }
    }
}
