using System;
using System.ComponentModel;

namespace Solution.CrossCutting.Utils
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var attribute = value.GetAttribute<DescriptionAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }

        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            if (value == null)
            {
                return null;
            }

            var member = value.GetType().GetMember(value.ToString());

            var attributes = member[0].GetCustomAttributes(typeof(T), false);

            return (T)attributes[0];
        }
    }
}
