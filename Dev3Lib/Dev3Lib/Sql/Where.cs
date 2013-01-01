using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public sealed class Where : IWhere
    {
        private object _value;
        private string _paramName;
        private string _columnName;
        private Comparison _comparison;
        private IWhere _nextWhere;
        private bool _isAnd;
        
        public IWhere And(IWhere where)
        {
            _isAnd = true;
            _nextWhere = where;
            return this;
        }

        public IWhere Or(IWhere where)
        {
            _nextWhere = where;
            return this;
        }

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

        public string ParamName
        {
            get
            {
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

        public Comparison Comparison
        {
            get
            {
                return _comparison;
            }
            set
            {
                _comparison = value;
            }
        }


        public string ToWhereClause()
        {
            StringBuilder sb = new StringBuilder();
            if (_nextWhere == null)
            {
                sb.Append(ColumnName)
                    .Append(Comparison.ToOperator())
                    .Append(ParamName);
            }
            else
            {
                sb.Append("(")
                    .Append(ColumnName)
                    .Append(Comparison.ToOperator())
                    .Append(ParamName);
                if (_isAnd)
                    sb.Append(" AND ");
                else
                    sb.Append(" OR ");

                sb.Append(_nextWhere.ToWhereClause())
                    .Append(")");
            }

            return sb.ToString();
        }
    }
}
