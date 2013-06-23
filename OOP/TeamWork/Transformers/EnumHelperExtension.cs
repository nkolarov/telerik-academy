using System;
using System.ComponentModel;

namespace Transformers
{
    public static class EnumHelperExtension
    {
        public static string ToDescription(this Enum value)
        { // Extension method for Enum
            // Get string description
            var description = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (description.Length > 0)
            {
                return description[0].Description;
            }
            
            return value.ToString();
        }
    }
}