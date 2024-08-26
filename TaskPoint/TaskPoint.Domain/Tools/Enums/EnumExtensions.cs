using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPoint.Domain.Tools.Enums
{
    public static class EnumExtensions
    {
        public static TEnum ToEnum<TEnum>(this string value) where TEnum : struct
        {
            if (Enum.TryParse<TEnum>(value, true, out var result))
            {
                return result;
            }
            throw new ArgumentException($"Invalid value '{value}' for enum '{typeof(TEnum).Name}'");
        }
    }
}
