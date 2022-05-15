using System;
using System.Collections.Generic;
using System.Text;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Model
{
    public class NotFoundFrontException : Exception
    {
        public NotFoundFrontException(string message): base(message)
        {

        }
    }
}
