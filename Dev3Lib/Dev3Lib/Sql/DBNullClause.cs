using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public class DBNullClause : WhereClause
    {
        public DBNullClause(string columnName) : base(null, columnName) { }

        protected override string ToCurrentWhereClause()
        {
            return string.Format("{0} is null", ColumnName);
        }

        protected override IEnumerable<object> ToValues()
        {
            return new object[] { };
        }
    }
}
