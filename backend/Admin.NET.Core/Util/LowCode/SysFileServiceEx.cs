using Admin.NET.Core.Util.LowCode.Dto;
using Furion.DatabaseAccessor;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core.Util.LowCode
{
    public static class SysFileServiceEx
    {
        public static List<Front_FileDto> GetFiles(this string fileid, IRepository<SysFile> repository)
        {
            List<Front_FileDto> data = new List<Front_FileDto>();

            if (string.IsNullOrWhiteSpace(fileid)) return data;

            foreach (var id in fileid.Split(','))
            {
                if (long.TryParse(id, out long val))
                {
                    data.Add(repository.Where(x => x.Id == val).ProjectToType<Front_FileDto>().FirstOrDefault());
                }
            }

            return data;
        }
    }
}
