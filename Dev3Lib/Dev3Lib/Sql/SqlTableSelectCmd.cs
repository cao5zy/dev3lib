using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Dev3Lib.Util;

namespace Dev3Lib.Sql
{
    public class SqlTableSelectCmd
    {
        private SqlCommand _cmd;
        private StringBuilder _whereBuilder = new StringBuilder();
        public SqlTableSelectCmd(SqlConnection conn,
            string tableName)
        {
            _cmd = conn.CreateCommand();
            _cmd.CommandText = string.Format("select * from {0}", tableName);
            _cmd.CommandType = CommandType.Text;
        }

        public void AddParameterWithValue(string columnName, object value)
        {
            if (columnName.StartsWith("@"))
            {
                _cmd.Parameters.AddWithValue(columnName, value);
                if (_whereBuilder.Length == 0)
                {
                    _whereBuilder.AppendFormat("{0}={0}", columnName);
                }
                else
                {
                    _whereBuilder.AppendFormat(" and {0}={0}", columnName);
                }
            }
            else
            {
                _cmd.Parameters.AddWithValue("@" + columnName, value);

                if (_whereBuilder.Length == 0)
                {
                    _whereBuilder.AppendFormat("{0}=@{0}", columnName);
                }
                else
                {
                    _whereBuilder.AppendFormat(" and {0}=@{0}", columnName);
                }
            }

        }

        public List<T> ExecuteList<T>(Func<SqlDataReader, T> converter)
        {
            List<T> list = new List<T>();

            _cmd.CommandText = _whereBuilder.InsertHead(" where ").InsertHead(_cmd.CommandText).ToString();
            var reader = _cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(converter(reader));
            }

            return list;
        }

        public IDataReader ExecuteReader()
        {
            return _cmd.ExecuteReader();
        }
    }
}
