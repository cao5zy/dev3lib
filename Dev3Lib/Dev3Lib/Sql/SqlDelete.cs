using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public class SqlDelete : ISqlDelete
    {
        private IDbContext _dbContext;
        private string _debugSql = string.Empty;

        public SqlDelete(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string DebugSql
        {
            get
            {
                return _debugSql;
            }
        }

        public void Delete(string tableName, WhereClause where)
        {
            string sql = string.Format("delete from {0} where {1}", tableName, where.Clause);

            _debugSql = sql;

            using (var cmd = _dbContext.Connection.CreateCommand())
            {
                cmd.Transaction = _dbContext.Transaction;

                cmd.CommandText = sql;

                GenerateParameters(where, cmd.Parameters);


                cmd.ExecuteNonQuery();
            }
        }

        private void GenerateParameters(WhereClause where, SqlParameterCollection paramColl)
        {
            var valueDic = where.ToNameValues();

            List<SqlParameter> list = new List<SqlParameter>(valueDic.Count);

            foreach (var keypair in valueDic)
            {
                paramColl.AddWithValue(keypair.Key, keypair.Value);
            }

        }
    }
}
