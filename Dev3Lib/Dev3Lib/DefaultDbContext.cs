using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dev3Lib
{
    public class DefaultDbContext : IDbContext
    {
        private SqlConnection _conn = null;
        private SqlTransaction _trans = null;
        private bool _isCommit = false;

        public DefaultDbContext(string connectionString)
        {
            _conn = new SqlConnection(connectionString);
            _conn.Open();
        }

        public DefaultDbContext()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            _conn.Open();
        }
        public void Dispose()
        {
            if (!(_trans == null || _isCommit))
                _trans.Rollback();
            if (_conn.State != System.Data.ConnectionState.Closed)
                _conn.Close();
        }

        public void BeginTransaction()
        {
            if (_trans == null)
            {
                _trans = _conn.BeginTransaction();
            }
        }

        public void Commit()
        {
            if (_isCommit)
                throw new InvalidOperationException("transaction has been committed");

            if (_trans != null)
            {
                _trans.Commit();
                _isCommit = true;
            }
        }

        public SqlConnection Connection
        {
            get { return _conn; }
        }


        public SqlTransaction Transaction
        {
            get { return _trans; }
        }
    }

}
