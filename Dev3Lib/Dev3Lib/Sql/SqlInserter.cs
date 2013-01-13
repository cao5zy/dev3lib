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
        private static readonly string _insertFormat = "insert into {0} ({1}) values({2})";
        public void Insert(IInsertValue value)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            List<string> columnNames = new List<string>();
            List<string> paramNames = new List<string>();

            value.ToValueClause(columnNames, paramNames);
            value.ToNameValues(values);

            if (columnNames.Count != 0)
            {
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.Transaction = _trans;

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = string.Format(_insertFormat,
                        columnNames.SafeJoinWith(","),
                        paramNames.SafeJoinWith(","));

                    foreach (var item in values)
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
