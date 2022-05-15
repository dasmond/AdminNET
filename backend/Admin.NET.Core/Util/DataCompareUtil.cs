using System.Linq.Expressions;
using System.Reflection;

namespace Furion.Extras.Admin.NET.Util
{
    public class DataCompareUtil<T1, T2>
    {
        public DataCompareUtil(
            Expression<Func<T1, object>> SelectorKey_1,
            Expression<Func<T2, object>> SelectorKey_2
            )
        {
            Propertys = new List<View_Property>();
            T_1 = typeof(T1);
            T_2 = typeof(T2);

            KeyProperty = new View_Property()
            {
                Property_1 = T_1.GetProperty(GetPropertyName(SelectorKey_1)),
                Property_2 = T_2.GetProperty(GetPropertyName(SelectorKey_2))
            };
        }

        private List<View_Property> Propertys { get; set; }

        private Type T_1 { get; set; }
        private Type T_2 { get; set; }

        private View_Property KeyProperty { get; set; }

        public void PushCompare(
            Expression<Func<T1, object>> Selector_1,
            Expression<Func<T2, object>> Selector_2
            )
        {
            Propertys.Add(new View_Property()
            {
                Property_1 = T_1.GetProperty(GetPropertyName(Selector_1)),
                Property_2 = T_2.GetProperty(GetPropertyName(Selector_2))
            });
        }

        public View_DataCompare<T1, T2> Compare(
            List<T1> Data_1,
            List<T2> Data_2
            )
        {
            View_DataCompare<T1, T2> data = new View_DataCompare<T1, T2>();

            Dictionary<string, T1> dic_Contain_2 = new Dictionary<string, T1>();
            Dictionary<string, T2> dic_Contain_1 = new Dictionary<string, T2>();

            foreach (var item_1 in Data_1)
            {
                foreach (var item_2 in Data_2)
                {
                    bool IsDifferent = false;

                    foreach (var Property_item in Propertys)
                    {
                        if (!IsDifferent)
                        {
                            if (Property_item.Property_1 == null || Property_item.Property_2 == null)
                            {
                                if (Property_item.Property_1 == null && Property_item.Property_2 == null)
                                {
                                    break;
                                }
                                else
                                {
                                    IsDifferent = true;
                                }
                            }
                            else
                            {
                                var obj_value1 = Property_item.Property_1.GetValue(item_1);
                                var obj_value2 = Property_item.Property_2.GetValue(item_2);

                                if (obj_value1 != null && obj_value2 != null)
                                {
                                    if (obj_value1 is decimal @decimal && obj_value2 is decimal @decimal2 && @decimal != @decimal2)
                                    {
                                        IsDifferent = true;
                                    }
                                    else if (obj_value1 is int @intl && obj_value2 is int @int2 && @intl != @int2)
                                    {
                                        IsDifferent = true;
                                    }
                                    else if (obj_value1 is Guid @Guidl && obj_value2 is Guid @Guid2 && @Guidl != @Guid2)
                                    {
                                        IsDifferent = true;
                                    }
                                    else if (obj_value1 is DateTime @DateTimel && obj_value2 is DateTime @DateTime2 && @DateTimel != @DateTime2)
                                    {
                                        IsDifferent = true;
                                    }
                                    else
                                    {
                                        if (obj_value1.ToString() != obj_value2.ToString())
                                            IsDifferent = true;
                                    }
                                }
                                else if (obj_value1 != null || obj_value2 != null)
                                {
                                    IsDifferent = true;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (!IsDifferent)
                    {
                        //item_1与item_2相同
                        string key_1 = KeyProperty.Property_1.GetValue(item_1).ToString();

                        if (!dic_Contain_2.ContainsKey(key_1))
                        {
                            dic_Contain_2.Add(key_1, item_1);
                            data.Contain_2.Add(item_1);
                        }

                        string key_2 = KeyProperty.Property_2.GetValue(item_2).ToString();

                        if (!dic_Contain_1.ContainsKey(key_2))
                        {
                            dic_Contain_1.Add(key_2, item_2);
                            data.Contain_1.Add(item_2);
                        }
                    }
                }
            }

            foreach (var item_1 in Data_1)
            {
                string key_1 = KeyProperty.Property_1.GetValue(item_1).ToString();

                if (!dic_Contain_2.ContainsKey(key_1))
                {
                    data.NoContain_2.Add(item_1);
                }
            }

            foreach (var item_2 in Data_2)
            {
                string key_2 = KeyProperty.Property_2.GetValue(item_2).ToString();

                if (!dic_Contain_1.ContainsKey(key_2))
                {
                    data.NoContain_1.Add(item_2);
                }
            }

            return data;
        }

        public static string GetPropertyName<T>(Expression<Func<T, object>> expr)
        {
            var rtn = "";
            if (expr.Body is UnaryExpression expression)
            {
                rtn = ((MemberExpression)expression.Operand).Member.Name;
            }
            else if (expr.Body is MemberExpression expression2)
            {
                rtn = expression2.Member.Name;
            }
            else if (expr.Body is ParameterExpression expression1)
            {
                rtn = expression1.Type.Name;
            }
            return rtn;
        }
    }

    public class View_DataCompare<T1, T2>
    {
        public View_DataCompare()
        {
            Contain_2 = new List<T1>();
            Contain_1 = new List<T2>();
            NoContain_2 = new List<T1>();
            NoContain_1 = new List<T2>();
        }
        /// <summary>
        /// 2号数据源中存在
        /// </summary>
        public List<T1> Contain_2 { get; set; }
        /// <summary>
        /// 1号数据源中存在
        /// </summary>
        public List<T2> Contain_1 { get; set; }
        /// <summary>
        /// 2号数据源中不存在
        /// </summary>
        public List<T1> NoContain_2 { get; set; }
        /// <summary>
        /// 1号数据源中不存在
        /// </summary>
        public List<T2> NoContain_1 { get; set; }
    }

    public class View_Property
    {
        public PropertyInfo Property_1 { get; set; }
        public PropertyInfo Property_2 { get; set; }
    }
}
