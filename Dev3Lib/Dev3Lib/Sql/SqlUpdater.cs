using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dev3Lib.Algorithms;

namespace Dev3Lib.Sql
{
    public class SqlUpdater : IUpdater
    {
        private SqlConnection _conn;
        private SqlTransaction _trans;
        private static readonly string _updateFormat = "update {0} set {1} where 1 = 1 and {2}";

        public SqlUpdater(SqlConnection conn,
            SqlTransaction trans = null)
        {
            _conn = conn;
            _trans = trans;
        }

        public void Update(string tableName, IEnumerable<IValue> values, WhereClause where)
        {
            if(values.IsNullOrEmpty())
                throw new ArgumentNullException("value");

            if (where == null)
                throw new ArgumentNullException("where");

            var whereValues = where.ToNameValues();
            List<string> columnNames = new List<string>();
            List<string> paramNames = new List<string>();

            values.SafeForEach(n=>
            {
                if (!whereValues.ContainsKey(n.ParamName))
                {
                    whereValues.Add(n.ParamName, n.Value);
                    columnNames.Add(n.ColumnName);
                    paramNames.Add(n.ParamName);
                }
            });


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

                    foreach (var item in whereValues)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                    int result = cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
