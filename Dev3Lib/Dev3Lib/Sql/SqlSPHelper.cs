using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Dev3Lib.Sql
{
    public class SqlSPHelper : IDisposable
    {
        private SqlConnection _conn;
        private SqlCommand _cmd;
        public SqlSPHelper(string connStr,
            string procedureName
            )
        {
            _conn = new SqlConnection(connStr);
            _conn.Open();

            _cmd = _conn.CreateCommand();
            _cmd.CommandType = System.Data.CommandType.StoredProcedure;
            _cmd.CommandText = procedureName;
        }

        public void AddParameterWithValue(string paramName, object value)
        {
            if (paramName.StartsWith("@"))
                _cmd.Parameters.AddWithValue(paramName, value);
            else
                _cmd.Parameters.AddWithValue("@" + paramName, value);
        }

        public List<T> ExecuteList<T>(Func<SqlDataReader, T> converter)
        {
            List<T> list = new List<T>();

            var reader = _cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(converter(reader));
            }

            return list;

        }
        public void Dispose()
        {
            _conn.Close();
            throw new NotImplementedException();
        }
    }
}
