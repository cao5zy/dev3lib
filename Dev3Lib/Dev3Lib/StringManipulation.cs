using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib
{
    public static class StringManipulation
    {
        public static StringBuilder InsertHead(this StringBuilder sb, string str)
        {
            return sb.Insert(0, str);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNotEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static int ToInt32(this string value)
        {
            if (value.IsNullOrEmpty())
                return 0;
            return int.Parse(value);
        }
    }
}
