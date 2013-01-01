using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public interface ISelector
    {
        T Read<T>(Func<IDataReader, T> convert,
            string sql,
            IWhere where);

        List<T> Return<T>(Func<IDataReader, T> convert,
            string sql,
            IWhere where);

        int Count(string sql,
            IWhere where);
    }
}
