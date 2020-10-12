using System;
using System.ComponentModel;

namespace Moosesoft.RulesEngine.Extensions
{
    public static class StringExtensions
    {
        public static object ToType(this string @string, Type type)
        {
            if (@string == null) throw new ArgumentNullException(nameof(@string));

            var converter = TypeDescriptor.GetConverter(type);
            return converter.ConvertFromString(@string);
        }        
    }
}