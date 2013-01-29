﻿using System;
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
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<SqlInserter>().As<IInserter>();

            using (SqlConnection conn = new SqlConnection("Initial Catalog=tbaDATA;Data Source=(local)\\Sqlexpress;Integrated Security=true"))
            {
                conn.Open();

                builder.RegisterInstance(conn).ExternallyOwned();

                var inserter = builder.Build().Resolve<IInserter>();

                inserter.Insert("tblTBAFeedback", new InsertValue[] {
                new InsertValue{
                ColumnName="AupairId",
                Value=12543,
                },
                new InsertValue{
                ColumnName="FeedbackDate",
                Value=DateTime.Now,
                },
                new InsertValue{
                ColumnName="FeedbackRanking",
                Value=1,
                },
                new InsertValue{
                ColumnName="FeedbackComments",
                Value="test comments",
                },
                new InsertValue{
                ColumnName="FeedbackEmailAddress",
                Value="cest@163.com",
                }
                });
            }
        }
    }
}