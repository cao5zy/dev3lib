using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public interface IValue
    {
        IValue Append(IValue value);
        string ColumnName { get; set; }
        string ParamName { get; set; }
        object Value { get; set; }
        List<IValue> ToList();
    }
}
