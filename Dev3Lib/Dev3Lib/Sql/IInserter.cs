using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public interface IInserter
    {
        long Insert(string tableName, IEnumerable<IValue> values, bool returnSeed = false);
    }
}
