using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Dev3Lib
{
    public interface IDbContext : IDisposable
    {
        void BeginTransaction();
        void Commit();
        SqlConnection Connection { get; }
        SqlTransaction Transaction { get; }
    }
}
