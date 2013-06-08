using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Dev3Lib.Sql;

namespace Dev3Lib.Test
{
    [TestClass()]
    public class SqlDelete_Test
    {
        [TestInitialize]
        public void TestInit()
        {
            DependencyFactory.PartialSetContainer(builder =>
            {
                builder.RegisterType<SqlDelete>().As<ISqlDelete>();
                builder.RegisterType<DefaultDbContext>().As<IDbContext>().WithParameter(new TypedParameter(typeof(string), "Initial Catalog=tbaDATA;Data Source=(local)\\Sqlexpress;Integrated Security=true"));
            });
        }

        [TestMethod]
        public void Delete_Success()
        {
            using (DependencyFactory.BeginScope())
            {
                DependencyFactory.Resolve<IDbContext>().BeginTransaction();
                var delete = DependencyFactory.Resolve<ISqlDelete>();
                delete.Delete("tbltbaerror", new WhereClause(96, "error_id"));
            }
        }
    }
}
