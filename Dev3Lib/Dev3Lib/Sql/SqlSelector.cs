using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dev3Lib.Sql
{
    public class SqlSelector : ISelector
    {
        private IDbContext _dbContext;
        private static readonly string _selectFormat = "{0} where 1=1 {1}";
        private static readonly string _selectOrderByFormat = "{0} where 1=1 {1} order by {2}";

        public SqlSelector(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerator<T> Read<T>(Converter<System.Data.IDataReader, T> convert,
            string sql,
            WhereClause where,
            string orderBys = null)
        {
            using (var cmd = _dbContext.Connection.CreateCommand())
            {
                cmd.Transaction = _dbContext.Transaction;

                cmd.CommandType = System.Data.CommandType.Text;

                string whereClause = string.Empty;
                if (where != null)
                    whereClause = string.Format("and {0}", where.Clause);

                if (orderBys == null)
                {
                    cmd.CommandText = string.Format(_selectFormat,
                        sql,
                       whereClause);
                }
                else
                {
                    cmd.CommandText = string.Format(_selectOrderByFormat,
                        sql,
                        whereClause,
                        orderBys);
                }

                GenerateParameters(where, cmd.Parameters);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        yield return convert(reader);
                }
            }
        }

        public List<T> Return<T>(Converter<System.Data.IDataReader, T> convert,
            string sql,
            WhereClause where,
            string orderBys = null)
        {
            using (var cmd = _dbContext.Connection.CreateCommand())
            {
                cmd.Transaction = _dbContext.Transaction;

                cmd.CommandType = System.Data.CommandType.Text;

                string whereClause = string.Empty;
                if (where != null)
                    whereClause = string.Format("and {0}", where.Clause);

                if (orderBys == null)
                {
                    cmd.CommandText = string.Format(_selectFormat,
                        sql,
                        whereClause);
                }
                else
                {
                    cmd.CommandText = string.Format(_selectOrderByFormat,
                        sql,
                        whereClause,
                        orderBys);
                }
                GenerateParameters(where, cmd.Parameters);

                List<T> list = new List<T>();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(convert(reader));

                    return list;
                }
            }
        }

        public int Count(string sql, WhereClause where)
        {
            using (var cmd = _dbContext.Connection.CreateCommand())
            {
                cmd.Transaction = _dbContext.Transaction;

                cmd.CommandType = System.Data.CommandType.Text;

                string whereClause = string.Empty;
                if (where != null)
                    whereClause = string.Format("and {0}", where.Clause);

                cmd.CommandText = string.Format(_selectFormat,
                    sql,
                    whereClause
                    );

                GenerateParameters(where, cmd.Parameters);

                var result = cmd.ExecuteScalar();
                if (result == null)
                    throw new InvalidOperationException("result count");

                return Convert.ToInt32(result);
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
