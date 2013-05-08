using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Dev3Lib.Algorithms;

namespace Dev3Lib.Util
{
    public class EnumValueException : InvalidCastException { }

    public static class EnumExtension
    {
        private static Regex _OnlyText = new Regex(@"[A-Z]{1}[a-z]*");
        private static Regex _ContainsNumber = new Regex(@"\d+");
        public static IDictionary<int, string> ToDic<T>()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();

            Type t = typeof(T);
            var names = Enum.GetNames(t);
            var values = Enum.GetValues(t);

            if (values.Length != 0)
            {
                int index = 0;
                foreach (var n in values)
                {
                    
                    dic.Add(Convert.ToInt32(n), ConvertName(names[index++]));
                }
            }
            return dic;
        }

        public static void FillEnum<T>(object listSource, 
            string valueFieldName, 
            string textFieldName,
            IDictionary<int, string> overrides = null)
        {
            var type = listSource.GetType();
            string dataSourceName = "DataSource";
            var dataSource = type.GetProperty(dataSourceName);
            var valueField = type.GetProperty(valueFieldName);
            var textField = type.GetProperty(textFieldName);

            var dic = ToDic<T>();
            if (overrides != null)
            {
                overrides.SafeFindAll(n => dic.ContainsKey(n.Key))
                    .SafeForEach(n => dic[n.Key] = overrides[n.Key]);
            }

            dataSource.SetValue(listSource, dic, null);
            valueField.SetValue(listSource, "Key", null);
            textField.SetValue(listSource, "Value", null);
        }

        public static void FillEnum<T>(object listSource,
            T defaultVal, 
            string valueFieldName, 
            string textFieldName,
            IDictionary<int, string> overrides = null)
        {
            var type = listSource.GetType();

            string dataSourceName = "DataSource";
            var dataSource = type.GetProperty(dataSourceName);
            var valueField = type.GetProperty(valueFieldName);
            var textField = type.GetProperty(textFieldName);

            var dic = ToDic<T>();
            if (overrides != null)
            {
                overrides.SafeFindAll(n => dic.ContainsKey(n.Key))
                    .SafeForEach(n => dic[n.Key] = overrides[n.Key]);
            }

            dataSource.SetValue(listSource, dic, null);
            valueField.SetValue(listSource, "Key", null);
            textField.SetValue(listSource, "Value", null);

            string selectedValueName = "SelectedValue";
            var selectedValue = type.GetProperty(selectedValueName);

            selectedValue.SetValue(listSource, Convert.ToInt32(defaultVal).ToString(), null);
        }
        private static string ConvertName(string originalEnumName)
        {
            if (_ContainsNumber.IsMatch(originalEnumName))
                return originalEnumName;

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

        public static T GetEnumValue<T>(this string selectedValue, T defaultVal, bool causeException = false)
        {
            if (string.IsNullOrEmpty(selectedValue))
                return defaultVal;

            int val = Convert.ToInt32(selectedValue);
            foreach (var n in Enum.GetValues(typeof(T)))
            {
                if (Convert.ToInt32(n) == val)
                    return (T)Enum.ToObject(typeof(T), val);
            }

            if (causeException)
                throw new EnumValueException();

            return defaultVal;
        }

        public static bool TryGetEnumValue<T>(this string selectedValue, out T outVal)
        {
            outVal = default(T);
            if (string.IsNullOrEmpty(selectedValue))
                return false;

            int val = Convert.ToInt32(selectedValue);
            foreach (var n in Enum.GetValues(typeof(T)))
            {
                if (Convert.ToInt32(n) == val)
                {
                    outVal = (T)Enum.ToObject(typeof(T), val);
                    return true;
                }
            }

            return false;
        }
    }
}
