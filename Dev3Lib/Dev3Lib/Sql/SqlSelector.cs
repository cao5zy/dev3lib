using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public class SqlSelector : ISelector
    {
        public T Read<T>(Func<System.Data.IDataReader, T> convert, string sql, IWhere where)
        {
            throw new NotImplementedException();
        }

        public List<T> Return<T>(Func<System.Data.IDataReader, T> convert, string sql, IWhere where)
        {
            throw new NotImplementedException();
        }

        public int Count(string sql, IWhere where)
        {
            throw new NotImplementedException();
        }

        private void GenerateParameters(IWhere where, SqlParameterCollection paramColl)
        {
            Dictionary<string, object> valueDic = new Dictionary<string, object>();
            where.ToNameValues(valueDic);

            List<SqlParameter> list = new List<SqlParameter>(valueDic.Count);

            foreach (var keypair in valueDic)
            {
                paramColl.AddWithValue(keypair.Key, keypair.Value);
            }

        }
    }
}
