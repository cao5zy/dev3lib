using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public interface ISelector
    {
        IEnumerator<T> Read<T>(Converter<IDataReader, T> convert,
            string sql,
            WhereClause where);

        List<T> Return<T>(Converter<IDataReader, T> convert,
            string sql,
            WhereClause where);

        int Count(string sql,
            WhereClause where);

    }
}
