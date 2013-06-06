using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using Dev3Lib.Sql;
using System.Data.SqlClient;

namespace Dev3Lib.Test
{
    [TestClass]
    public class SqlInsertorTest
    {
        [TestMethod]
        public void Insert_Test()
        {

            DependencyFactory.PartialSetContainer(builder => {
                builder.RegisterType<SqlInserter>().As<IInserter>();
                builder.RegisterType<DefaultDbContext>().As<IDbContext>().WithParameter(new TypedParameter(typeof(string), "Initial Catalog=tbaDATA;Data Source=(local)\\Sqlexpress;Integrated Security=true"));
            });
           
            using (DependencyFactory.BeginScope())
            {
                var inserter = DependencyFactory.Resolve<IInserter>();

                inserter.Insert("tblTBAFeedback", new SqlValue[] {
                new SqlValue{
                ColumnName="AupairId",
                Value=12543,
                },
                new SqlValue{
                ColumnName="FeedbackDate",
                Value=DateTime.Now,
                },
                new SqlValue{
                ColumnName="FeedbackRanking",
                Value=1,
                },
                new SqlValue{
                ColumnName="FeedbackComments",
                Value="test comments",
                },
                new SqlValue{
                ColumnName="FeedbackEmailAddress",
                Value="cest@163.com",
                }
                });
            }
        }

        [TestMethod]
        public void Insert_With_Return()
        {
            DependencyFactory.PartialSetContainer(builder =>
            {
                builder.RegisterType<SqlInserter>().As<IInserter>();
                builder.RegisterType<DefaultDbContext>().As<IDbContext>().WithParameter(new TypedParameter(typeof(string), "Initial Catalog=tbaDATA;Data Source=(local)\\Sqlexpress;Integrated Security=true"));
            });

            using (DependencyFactory.BeginScope())
            {
                var inserter = DependencyFactory.Resolve<IInserter>();

                var id = inserter.Insert("tblTBAError", new SqlValue[] {
                new SqlValue{
                ColumnName="error_message",
                Value="test error",
                },
                new SqlValue{
                ColumnName="error_stacktrace",
                Value="stack site",
                },
                new SqlValue{
                ColumnName="error_z7message",
                Value="error message",
                },
                new SqlValue{
                ColumnName="error_datetime",
                Value=DateTime.Now,
                },
                }, true);

                Assert.IsTrue(id != 0);
            }
        }
    }
}
