using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public class InsertValue : IValue
    {
        private string _columnName;
        public string ColumnName
        {
            get
            {
                return _columnName;
            }
            set
            {
                _columnName = value;
            }
        }

        private string _paramName;
        public string ParamName
        {
            get
            {
                if (string.IsNullOrEmpty(_paramName))
                    return string.Format("@{0}", _columnName);
                else
                    return _paramName;
            }
            set
            {
                if (value.StartsWith("@"))
                    _paramName = value;
                else
                    _paramName = string.Format("@{0}", value);
            }
        }

        private object _value;
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
}
