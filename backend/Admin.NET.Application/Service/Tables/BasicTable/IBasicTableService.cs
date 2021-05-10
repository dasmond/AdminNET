using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dilon.Application.Service.Tables.BasicTable
{
    public interface IBasicTableService
    {
        Task<dynamic> GetBasicTableList();
    }
}
