using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public interface ISqlDelete
    {
        void Delete(string tableName, WhereClause where);
    }
}
