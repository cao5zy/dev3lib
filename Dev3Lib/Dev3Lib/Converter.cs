using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib
{
    public static class Converter
    {
        public static int ToInt32(this string value)
        {
            if (value.IsNullOrEmpty())
                return 0;
            return int.Parse(value);
        }

        public static double ToDouble(this string value)
        {
            if (value.IsNullOrEmpty())
                return 0;
            return double.Parse(value);
        }

        public static DateTime ToDateTime(this string value)
        {
            if (value.IsNullOrEmpty())
                return DateTime.MinValue;
            return DateTime.Parse(value);
        }

    }
}
