using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public class UpdateValue : IUpdateValue
    {
        private IUpdateValue _nextUpdateValue;
        public IUpdateValue Append(IUpdateValue value)
        {
            if (_nextUpdateValue != null)
                throw new InvalidOperationException();

            if (value == null)
                throw new NullReferenceException("value");

            _nextUpdateValue = value;

            return this;
        }

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
                return _paramName;
            }
            set
            {
                _paramName = value;
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

        public void ToNameValues(IDictionary<string, object> values)
        {
            if (!values.ContainsKey(ParamName))
                values.Add(ParamName, Value);

            if (_nextUpdateValue != null)
                _nextUpdateValue.ToNameValues(values);
        }

        public void ToValueClause(IList<string> columnNames, IList<string> valueNames)
        {
            if (Value != null)
            {
                columnNames.Add(ColumnName);
                valueNames.Add(ParamName);
            }

            if (_nextUpdateValue != null)
                _nextUpdateValue.ToValueClause(columnNames, valueNames);
        }
    }
}
