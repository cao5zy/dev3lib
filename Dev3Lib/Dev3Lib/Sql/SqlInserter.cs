using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public class SqlInserter : IInserter
    {
        private SqlConnection _conn;
        private SqlTransaction _trans;
        public SqlInserter(SqlConnection conn, SqlTransaction trans = null)
        {
            _conn = conn;
            _trans = trans;
        }
        private static readonly string _insertFormat = "insert into {0} ({1}) values({2})";

        public void Insert(string tableName, IEnumerable<IValue> values)
        {
            Dictionary<string, object> valuesDic = new Dictionary<string, object>();
            List<string> columnNames = new List<string>();
            List<string> paramNames = new List<string>();

            foreach (var val in values)
            {
                if (val.Value == null)
                    continue;

                valuesDic.Add(val.ParamName, val.Value);
                columnNames.Add(val.ColumnName);
                paramNames.Add(val.ParamName);
            }
            

            if (columnNames.Count != 0)
            {
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.Transaction = _trans;

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = string.Format(_insertFormat,
                        tableName,
                        columnNames.SafeJoinWith(","),
                        paramNames.SafeJoinWith(","));

                    foreach (var item in valuesDic)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                    int result = cmd.ExecuteNonQuery();

                    if (result == 0)
                        throw new InvalidOperationException("no result inserted");
                }
            }
        }
    }
}
