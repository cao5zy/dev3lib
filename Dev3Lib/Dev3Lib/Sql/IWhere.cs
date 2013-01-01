using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public interface IWhere
    {
        IWhere And(IWhere where);
        IWhere Or(IWhere where);
        string ToWhereClause();
        void ToNameValues(IDictionary<string, object> valueDic);
        string ColumnName { get; set; }
        string ParamName { get; set; }
        object Value { get; set; }

        Comparison Comparison { get; set; }
    }
}
