using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using Dev3Lib.Sql;
using System.Data.SqlClient;

namespace Dev3Lib.Test
{
    [TestClass]
    public class SqlUpdaterTest
    {
        [TestMethod]
        public void Normal_Update_Test()
        {
            /*
             * select FirstName , LastName from tblTBAAupair
where aupairid = 12802 and firstName='test1FirstName' and lastname='test2LastName'
             * */

            Action<IUpdater> run = (updater) =>
            {
                updater.Update("tblTBAAupair", new IValue[] {
                    new SqlValue{
                        ColumnName="FirstName",
                        Value = "test1FirstName"
                    },
                    new SqlValue{
                        ColumnName = "LastName",
                        Value = "test2LastName",
                    }
                }, new WhereClause(12802, "aupairid"));


            };

            RunSql(run);
        }

        private void RunSql(Action<IUpdater> run)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<SqlUpdater>().As<IUpdater>();

            using (SqlConnection conn = new SqlConnection("Initial Catalog=tbaDATA;Data Source=(local)\\Sqlexpress;Integrated Security=true"))
            {
                conn.Open();

                builder.RegisterInstance<SqlConnection>(conn).ExternallyOwned();

                var updater = builder.Build().Resolve<IUpdater>();

                run(updater);

            }
        }
    }
}
