using Admin.NET.Core.Util.LowCode.Front.Model;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Interface;
using Furion.Extras.Admin.NET.Util.LowCode.Front.Model;

namespace Furion.Extras.Admin.NET.Util.LowCode.Front.Code
{
    public static class AutoCode_FrontModel
    {
        public static List<IFront> AllFront(this Front_Model model)
        {
            List<IFront> list = new List<IFront>();

            model.List.ForEach(item =>
            {
                if (item is IFrontLayout)
                {
                    (item as IFrontLayout).ReadFront(front => { list.Add(front); });
                }
                else
                {
                    list.Add(item);
                }
            });

            return list;
        }

        public static List<ViewDynamic> AllDynamic(this List<IFront> list)
        {
            List<ViewDynamic> data = new List<ViewDynamic>();

            list.ForEach(item =>
            {
                if (item.Dynamic != null)
                {
                    data.Add(item.Dynamic);
                }
            });

            return data;
        }
    }
}