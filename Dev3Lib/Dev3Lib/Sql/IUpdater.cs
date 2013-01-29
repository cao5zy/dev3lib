using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public interface IUpdater
    {
        void Update(string tableName, IEnumerable<IValue> values, WhereClause where);
    }
}
