using Dev3Lib.DbConvert;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public interface ISelector
    {
        IEnumerator<T> Read<T>(Converter<DataReaderAdapter, T> convert,
            string sql,
            WhereClause where,
            string orderBys = null);

        List<T> Return<T>(Converter<DataReaderAdapter, T> convert,
            string sql,
            WhereClause where,
            string orderBys = null);

        int Count(string sql,
            WhereClause where);

    }
}
