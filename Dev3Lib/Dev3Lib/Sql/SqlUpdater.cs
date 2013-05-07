using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dev3Lib.Algorithms;
using Dev3Lib.Util;

namespace Dev3Lib.Sql
{
    public class SqlUpdater : IUpdater
    {
        private IDbContext _dbContext;
        private static readonly string _updateFormat = "update {0} set {1} where 1 = 1 and {2}";

        public SqlUpdater(IDbContext dbContext)
        {
            _dbContext = dbContext;
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
                using (var cmd = _dbContext.Connection.CreateCommand())
                {
                    cmd.Transaction = _dbContext.Transaction;

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
