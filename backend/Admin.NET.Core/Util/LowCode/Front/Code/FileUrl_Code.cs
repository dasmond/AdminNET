using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Core.Util.LowCode.Front.Code
{
    public static class FileUrl_Code
    {
        public static string GetFileId(this string Url)
        {
            var param = Url.Substring(Url.IndexOf("?") + 1);

            param = param.Substring(param.IndexOf("id=") + 3);

            if(param.IndexOf("?") >= 0)
                param = param.Substring(0, param.IndexOf("?"));

            return param;
        }
    }
}
