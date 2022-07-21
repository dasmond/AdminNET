using Admin.NET.Core.Util.LowCode.Front.Model;

namespace Admin.NET.Core.Util.LowCode.Front.Code
{
    public static class AutoCode_Dynamic
    {
        public static Front_Dynamic GetDynamic(this string DynamicKey)
        {
            var index = DynamicKey.IndexOf('$');
            if (index >= 0)
            {
                return new Front_Dynamic()
                {
                    Head = DynamicKey.Substring(0, index),
                    Dynamic = DynamicKey.Substring(index + 1),
                    DynamicKey = DynamicKey
                };
            }

            return null;
        }
    }
}