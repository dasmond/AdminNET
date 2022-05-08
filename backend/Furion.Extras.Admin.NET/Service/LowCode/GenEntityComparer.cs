using Furion.Extras.Admin.NET.Service.LowCode.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.Extras.Admin.NET.Service.LowCode
{
    public class GenEntityComparer : IEqualityComparer<GenEntity>
    {
        public bool Equals(GenEntity x, GenEntity y)
        {
            bool result = true;
            if (x == null && y == null)
            {
                result = true;
            }
            else if (x == null ^ y == null)
            {
                result = false;
            }
            else
            {
                result = (x.TableDesc == y.TableDesc) &&
                    (x.ClassName == y.ClassName) &&
                    (x.TableName == y.TableName) &&
                    (x.NameSpace == y.NameSpace);
            }
            return result;
        }

        public int GetHashCode([DisallowNull] GenEntity obj)
        {
            return obj == null ? 0 : obj.ToString().GetHashCode();
        }
    }
}
