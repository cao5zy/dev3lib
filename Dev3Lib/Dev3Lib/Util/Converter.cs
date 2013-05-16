using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Util
{
    public static class Converter
    {
        public static int ToInt32(this string value)
        {
            if (value.IsNullOrEmpty())
                return 0;
            return int.Parse(value);
        }

        public static int ToInt32(this string value, int defaultVal, bool causeException = false)
        {
            if (value.IsNullOrEmpty())
                return defaultVal;

            int val;
            if (int.TryParse(value, out val))
                return val;
            else
            {
                if (causeException)
                    throw new InvalidCastException();
                else
                    return defaultVal;
            }
        }

        public static int ToInt32(this object value, int defaultValue = 0)
        {
            if (value == null)
                return defaultValue;

            int result;
            if(int.TryParse(value.ToString(), out result))
                return result;
            else
                return defaultValue;
        }

        public static double ToDouble(this string value)
        {
            if (value.IsNullOrEmpty())
                return 0;
            return double.Parse(value);
        }

        public static double ToDouble(this string value, double defaultVal, bool causeException = false)
        {
            if (value.IsNullOrEmpty())
                return defaultVal;

            double val;
            if (double.TryParse(value, out val))
                return val;
            else
            {
                if (causeException)
                    throw new InvalidCastException();
                else
                    return defaultVal;
            }
        }

        public static bool ToBool(this object value, bool defaultValue = false)
        {
            if (value == null)
                return defaultValue;

            bool val;
            if(Boolean.TryParse(value.ToString(), out val))
                return val;
            else
                return defaultValue;
        }

        public static DateTime ToDateTime(this string value)
        {
            if (value.IsNullOrEmpty())
                return DateTime.MinValue;
            return DateTime.Parse(value);
        }

        public static DateTime ToDateTime(this string value, DateTime defaultVal, bool causeException = false)
        {
            if (value.IsNullOrEmpty())
                return defaultVal;

            DateTime t;
            if (DateTime.TryParse(value, out t))
                return t;
            else
            {
                if (causeException)
                    throw new InvalidCastException();
                else
                    return defaultVal;
            }
        }
    }
}
