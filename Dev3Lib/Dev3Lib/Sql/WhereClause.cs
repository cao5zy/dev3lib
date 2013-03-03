using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public class WhereClause
    {
        /*
         * where clause is composed at the Add and Or method
         * */
        private readonly string _columnName, _paramName;
        private string _whereClause;
        private readonly object _value;
        private readonly IDictionary<string, object> _valueDic = new Dictionary<string, object>();
        private readonly Comparison _comp;

        public WhereClause(object value,
            string columnName,
            string paramName = null,
            Comparison comp = Sql.Comparison.Equal
            )
        {
            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentNullException(columnName);

            if (string.IsNullOrEmpty(paramName))
            {
                _paramName = string.Format("@{0}", columnName);
            }
            else
            {
                if (paramName.StartsWith("@"))
                    _paramName = paramName;
                else
                    _paramName = string.Format("@{0}", paramName);
            }

            _columnName = columnName;

            _comp = comp;

            _value = value;

            _whereClause = ToCurrentWhereClause();

            var values = ToValues();
            int index = 0;
            foreach (var val in values)
            {
                if (index == 0)
                {
                    _valueDic.Add(_paramName, val);
                }
                else
                {
                    _valueDic.Add(_paramName + index.ToString(), val);
                }

                index++;
            }
        }

        public WhereClause(object value,
            string columnName,
            Comparison comp)
            : this(value, columnName, null, comp) { }

        protected string ColumnName
        {
            get
            {
                return _columnName;
            }
        }

        protected string ParamName
        {
            get
            {
                return _paramName;
            }
        }

        protected object Value
        {
            get
            {
                return _value;
            }
        }

        protected Comparison Comparison
        {
            get
            {
                return _comp;
            }
        }

        public WhereClause And(WhereClause where)
        {
            if (where == null)
                throw new NullReferenceException("where");


            string currentClause = string.IsNullOrEmpty(_whereClause) ? ToCurrentWhereClause() : _whereClause;
            string nextWhereClause = string.IsNullOrEmpty(where._whereClause) ? where.ToCurrentWhereClause() : where._whereClause;

            if (string.IsNullOrEmpty(currentClause) && string.IsNullOrEmpty(nextWhereClause))
                return this;
            else if (string.IsNullOrEmpty(currentClause))
            {
                _whereClause = nextWhereClause;
            }
            else if (string.IsNullOrEmpty(nextWhereClause))
            {
                _whereClause = currentClause;
            }
            else
                _whereClause = string.Format("({0} and {1})", currentClause, nextWhereClause);


            foreach (var item in where._valueDic)
            {
                if (!_valueDic.ContainsKey(item.Key))
                    _valueDic.Add(item.Key, item.Value);
            }
            return this;
        }
        public WhereClause Or(WhereClause where)
        {
            if (where == null)
                throw new NullReferenceException("where");


            string currentClause = string.IsNullOrEmpty(_whereClause) ? ToCurrentWhereClause() : _whereClause;
            string nextWhereClause = string.IsNullOrEmpty(where._whereClause) ? where.ToCurrentWhereClause() : where._whereClause;

            if (string.IsNullOrEmpty(currentClause) && string.IsNullOrEmpty(nextWhereClause))
                return this;
            else if (string.IsNullOrEmpty(currentClause))
            {
                _whereClause = nextWhereClause;
            }
            else if (string.IsNullOrEmpty(nextWhereClause))
            {
                _whereClause = currentClause;
            }
            else
                _whereClause = string.Format("({0} and {1})", currentClause, nextWhereClause);


            foreach (var item in where._valueDic)
            {
                if (!_valueDic.ContainsKey(item.Key))
                    _valueDic.Add(item.Key, item.Value);
            }
            return this;
        }

        public string Clause
        {
            get
            {
                return _whereClause;
            }
        }

        public IDictionary<string, object> ToNameValues()
        {
            return _valueDic;
        }

        protected virtual string ToCurrentWhereClause()
        {
            return string.Format("{0} {1} {2}", ColumnName, Comparison.ToOperator(), ParamName);
        }

        protected virtual IEnumerable<object> ToValues()
        {
            return new object[] { _value };
        }


    }
}
