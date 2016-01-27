using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Configurations
{
    public static class Extentions
    {
        #region To Add/Remove in IEnumearble Object List
        public static IEnumerable<T> Add<T>(this IEnumerable<T> list, T NewObj) where T : class
        {
            if (list == null)
            {
                list = (new List<T> { NewObj }) as IEnumerable<T>;
            }
            else
            {
                var sa = list.ToList();
                sa.Add(NewObj);
                list = sa as IEnumerable<T>;
            }
            return list;
        }
        public static IEnumerable<T> Remove<T>(this IEnumerable<T> list, T Obj) where T : class
        {
            if (list != null)
            {
                IEnumerable<T> newList = null;
                foreach (var item in list)
                {
                    if(item == Obj)
                    {
                        continue;
                    }
                    newList = newList.Add(item);
                }
                list = newList;
            }
            return list;
        }

        #endregion

        #region To get description from Enum Object


        public static string GetDescription(this Enum enumVal)
        {
            DescriptionAttribute attribute = enumVal.GetType()
                                                    .GetField(enumVal.ToString())
                                                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                                                    .SingleOrDefault() as DescriptionAttribute;

            return attribute == null ? enumVal.ToString() : attribute.Description;
        }
        public static string GetCode(this Enum enumVal)
        {
            DefaultValueAttribute attribute = enumVal.GetType()
                                                    .GetField(enumVal.ToString())
                                                    .GetCustomAttributes(typeof(DefaultValueAttribute), false)
                                                    .SingleOrDefault() as DefaultValueAttribute;

            return attribute == null ? enumVal.ToString() : attribute.Value.ToString();
        }
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        #endregion
    }
}
