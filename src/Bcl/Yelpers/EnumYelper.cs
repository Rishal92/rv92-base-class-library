using System;
using System.ComponentModel;

namespace Bcl.Yelpers
{
    public static class EnumYelper
    {
        public static T ParseEnum<T>(string value)
        {
            if (value == null)
                return default;
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static string GetEnumDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fieldInfo?.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;

            return value.ToString();
        }
    }
}