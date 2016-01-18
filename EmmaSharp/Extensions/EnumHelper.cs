using System;
using System.Linq;
using System.Runtime.Serialization;

namespace EmmaSharp.Extensions
{
    public static class EnumHelper
    {
        public static string ToEnumString<T>(this Enum instance)
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("instance", "Must be enum type");
            string enumString = instance.ToString();
            var field = typeof(T).GetField(enumString);
            if (field != null) // instance can be a number that was cast to T, instead of a named value, or could be a combination of flags instead of a single value
            {
                var attr = (EnumMemberAttribute)field.GetCustomAttributes(typeof(EnumMemberAttribute), false).SingleOrDefault();
                if (attr != null) // if there's no EnumMember attr, use the default value
                    enumString = attr.Value;
            }
            return enumString;
        }
    }
}
