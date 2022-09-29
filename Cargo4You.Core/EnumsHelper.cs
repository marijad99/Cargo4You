using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cargo4You.Core
{
   
    public static class EnumsHelper
    {
        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }

        public static string GetEnumCssClass(Enum objEnum)
        {
            string description = GetDescription(objEnum);

            switch (description)
            {
                case "Success":
                    description = "success";
                    break;

                case "Error":
                    description = "error";
                    break;

                case "Warning":
                    description = "warn";
                    break;

                case "Info":
                    description = "info";
                    break;

                default:
                    description = "";
                    break;
            }

            return description;
        }



        public static string GetResourceDisplayEnums(Enum objEnum)
        {

            try
            {

                string message = GetDescription(objEnum);

                return string.IsNullOrWhiteSpace(message) ? objEnum.ToString() : message;

            }
            catch (Exception)
            {
                return objEnum.ToString();
            }
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
