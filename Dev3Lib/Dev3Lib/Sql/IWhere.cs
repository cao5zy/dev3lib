using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public abstract class IWhere
    {
        private readonly string _columnName, _paramName;
        private string _whereClause;
        private readonly object _value;
        private readonly IDictionary<string, object> _valueDic = new Dictionary<string, object>();
        private readonly Comparison _comp;

        public IWhere(string columnName,
            string paramName,
            Comparison comp,
            object value)
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

            _valueDic.Add(_paramName, _value);
        }

        public IWhere(string columnName,
            Comparison comp,
            object value)
            : this(columnName, null, comp, value)
        {

        }

        public IWhere(string columnName,
            object value)
            : this(columnName, null, Comparison.Equal, value)
        {

        }

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

        public IWhere And(IWhere where)
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
        public IWhere Or(IWhere where)
        {
            if (where == null)
                throw new NullReferenceException("where");



            if (string.IsNullOrEmpty(_whereClause))
                _whereClause = ToCurrentWhereClause();

            string nextWhereClause = where.ToCurrentWhereClause();

            if (string.IsNullOrEmpty(_whereClause) && string.IsNullOrEmpty(nextWhereClause))
                return where;
            else if (string.IsNullOrEmpty(_whereClause))
            {
                where._whereClause = nextWhereClause;
            }
            else if (string.IsNullOrEmpty(nextWhereClause))
            {
                where._whereClause = _whereClause;
            }
            else
                where._whereClause = string.Format("{0} or ({1})", _whereClause, nextWhereClause);

            return where;
        }

        public string WhereClause
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

        protected abstract string ToCurrentWhereClause();

    }
}
