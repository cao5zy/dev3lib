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

        public static bool NotExceed(this string str, int len)
        {
            return str.IsNotEmpty() && str.Length <= len;
        }

        public static bool NullOrNotExceed(this string str, int len)
        {
            return str == null || str.Length <= len;
        }

        public static bool OrdinalIngoreCaseCompare(this string str, string target)
        {
            return string.Compare(str, target, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
