using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public abstract class AbstractSelector
    {
        public abstract T Read<T>(Func<IDataReader, T> convert,
            string sql,
            IWhere where);

        public abstract List<T> Return<T>(Func<IDataReader, T> convert,
            string sql,
            IWhere where);

        public abstract int Count(string sql,
            IWhere where);
    }
}
