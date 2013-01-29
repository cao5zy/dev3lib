using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public abstract class IWhere
    {
        private IWhere _prevWhere;
        private string _whereClause;

        public IWhere And(IWhere where)
        {
            if (where == null)
                throw new NullReferenceException("where");

   
            where._prevWhere = this;

            if(string.IsNullOrEmpty(_whereClause))
                _whereClause = ToCurrentWhereClause();


            string nextWhereClause = string.IsNullOrEmpty(where._whereClause) ? where.ToCurrentWhereClause() : where._whereClause;

            if(string.IsNullOrEmpty(_whereClause) && string.IsNullOrEmpty(nextWhereClause))
                return where;
            else if(string.IsNullOrEmpty(_whereClause))
            {
                where._whereClause = nextWhereClause;
            }
            else if(string.IsNullOrEmpty(nextWhereClause))
            {
                where._whereClause = _whereClause;
            }
            else
                where._whereClause = string.Format("{0} and ({1})",_whereClause, nextWhereClause);

            return where;
        }
        public IWhere Or(IWhere where)
        {
            if (where == null)
                throw new NullReferenceException("where");

     
            where._prevWhere = this;

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
                if (string.IsNullOrEmpty(_whereClause))
                    return ToCurrentWhereClause();
                else
                    return _whereClause;
            }
        }

        public void ToNameValues(IDictionary<string, object> valueDic)
        {
            if (!valueDic.ContainsKey(ParamName))
                valueDic.Add(ColumnName, Value);

            if (_prevWhere != null)
                _prevWhere.ToNameValues(valueDic);
        }
        public string ColumnName { get; set; }

        private string _paramName;

        public string ParamName
        {
            get
            {
                if (string.IsNullOrEmpty(_paramName))
                    return string.Format("@{0}", ColumnName);
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
        public object Value { get; set; }

        public Comparison Comparison { get; set; }

        protected abstract string ToCurrentWhereClause();

    }
}
