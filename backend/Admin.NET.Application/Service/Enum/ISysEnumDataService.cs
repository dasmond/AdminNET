using Microsoft.AspNetCore.Mvc;

namespace Admin.NET.Application
{
    public interface ISysEnumDataService
    {
        Task<dynamic> GetEnumDataList([FromQuery] EnumDataInput input);

        Task<dynamic> GetEnumDataListByField([FromQuery] QueryEnumDataInput input);
    }
}