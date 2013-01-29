using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public sealed class Where : IWhere
    {
        public Where(object value,
            string columnName,
            string paramName = null,
            Comparison comp = Sql.Comparison.Equal)
            : base(columnName, paramName, comp, value) { }
        protected override string ToCurrentWhereClause()
        {
            return string.Format("{0} {1} {2}", ColumnName, Comparison.ToOperator(), ParamName);
        }
    }
}
