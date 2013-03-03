using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.DbConvert
{
    public static class DbConvertHelper
    {
        public static int ToInt32(this object val)
        {
            if (val == null || Convert.IsDBNull(val))
                return 0;
            else
                return Convert.ToInt32(val);
        }
    }
}
