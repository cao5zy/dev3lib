using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dev3Lib.Util
{
    public static class EnumExtension
    {
        private static Regex _OnlyText = new Regex(@"[A-Z]{1}[a-z]*");
        public static List<KeyValuePair<int, string>> ToList<T>()
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();

            Type t = typeof(T);
            var names = Enum.GetNames(t);
            var values = Enum.GetValues(t);

            if (values.Length != 0)
            {
                int index = 0;
                foreach (var n in values)
                {
                    list.Add(new KeyValuePair<int, string>(Convert.ToInt32(n), ConvertName(names[index++])));
                }
            }
            return list;
        }

        private static string ConvertName(string originalEnumName)
        {
            var names = originalEnumName.Split(new char[]{'_'});
            if (names.Length > 1)
                return string.Join("/", names);

            var matchs = _OnlyText.Matches(originalEnumName);
            if (matchs.Count != 0)
            {
                List<string> slist = new List<string>();
                foreach (Match m in matchs)
                {
                    slist.Add(m.Value);
                }

                return string.Join(" ", slist.ToArray());
            }

            return originalEnumName;
        }
    }
}
