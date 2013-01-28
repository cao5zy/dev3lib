using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public sealed class Where : IWhere
    {

        protected override string ToCurrentWhereClause()
        {
            return string.Format("{0} {1} {2}", ColumnName, Comparison.ToOperator(), ParamName);
        }
    }
}
