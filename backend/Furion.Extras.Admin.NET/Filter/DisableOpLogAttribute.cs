using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET
{
    /// <summary>
    /// 禁用操作日志
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
    public class DisableOpLogAttribute : Attribute
    {

    }
}
