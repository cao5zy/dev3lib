using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public class LikeClause : WhereClause
    {
        public LikeClause(string columnName, string value, string paramName = null, Comparison cmp = Comparison.LeftLike)
            : base(value, columnName, paramName, cmp)
        {
        }

        protected override string ToCurrentWhereClause()
        {

            if (Comparison == Comparison.LeftLike)
                return string.Format("{0} like '%' + {1}", ColumnName, ParamName);
            else if (Comparison == Comparison.RightLike)
                return string.Format("{0} like {1} + '%'", ColumnName, ParamName);
            else
                return string.Format("{0} like '%' + {1} + '%'", ColumnName, ParamName);
        }
    }
}
