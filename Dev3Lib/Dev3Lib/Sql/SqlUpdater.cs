using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public class SqlUpdater : IUpdater
    {
        private SqlConnection _conn;
        private SqlTransaction _trans;
        private static readonly string _updateFormat = "update {0} set {1} where 1 = 1 {2}";

        public void Update(string tableName, IUpdateValue value, WhereClause where)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            var values = where.ToNameValues();
            List<string> columnNames = new List<string>();
            List<string> paramNames = new List<string>();

            value.ToNameValues(values);
            value.ToValueClause(columnNames, paramNames);

            if (columnNames.Count != 0)
            {
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.Transaction = _trans;

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = string.Format(_updateFormat,
                        tableName,
                        columnNames.Select((s, i) => string.Format("{0}={1}", s, paramNames[i])).SafeJoinWith(","),
                        where.Clause);

                    foreach (var item in values)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                    int result = cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
