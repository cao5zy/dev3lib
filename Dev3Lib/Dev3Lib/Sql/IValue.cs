using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public interface IValue
    {
        string ColumnName { get; set; }
        string ParamName { get; set; }
        object Value { get; set; }
    }
}
