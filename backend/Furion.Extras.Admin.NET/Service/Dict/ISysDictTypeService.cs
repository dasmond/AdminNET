using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service
{
    public interface ISysDictTypeService
    {
        Task AddDictType(AddDictTypeInput input);

        Task ChangeDictTypeStatus(ChangeStateDictTypeInput input);

        Task DeleteDictType(DeleteDictTypeInput input);

        Task<List<DictTreeOutput>> GetDictTree();

        Task<SysDictType> GetDictType([FromQuery] QueryDictTypeInfoInput input);

        Task<List<SysDictData>> GetDictTypeDropDown([FromQuery] DropDownDictTypeInput input);

        Task<List<SysDictType>> GetDictTypeList();

        Task<PageResult<SysDictType>> QueryDictTypePageList([FromQuery] DictTypePageInput input);

        Task UpdateDictType(UpdateDictTypeInput input);
    }
}