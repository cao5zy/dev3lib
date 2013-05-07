using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dev3Lib.Util;


namespace Dev3Lib.Sql
{
    public class SqlInserter : IInserter
    {
        private IDbContext _dbContext;
        public SqlInserter(IDbContext dbContext)
        {
            _dbContext = dbContext;
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
                using (var cmd = _dbContext.Connection.CreateCommand())
                {
                    cmd.Transaction = _dbContext.Transaction;

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
