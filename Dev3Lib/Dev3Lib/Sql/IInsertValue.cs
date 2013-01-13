using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public interface IInsertValue
    {
        IInsertValue Append(IInsertValue value);
        string ColumnName { get; set; }
        string ParamName { get; set; }
        object Value { get; set; }
        void ToNameValues(IDictionary<string, object> values);
        void ToValueClause(IList<string> columnNames, IList<string> valueNames);
    }
}
