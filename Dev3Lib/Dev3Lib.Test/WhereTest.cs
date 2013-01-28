using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dev3Lib.Sql;

namespace Dev3Lib.Test
{
    [TestClass]
    public class WhereTest
    {
        [TestMethod]
        public void Test_1_And()
        {
            string result = new Where { ColumnName = "c1", ParamName = "c1", Comparison = Comparison.Equal, Value = 1 }
                .And(new Where { ColumnName = "c2", ParamName = "c2", Comparison = Comparison.Equal, Value = 2 })
                .WhereClause;

            Assert.AreEqual("(c1=@c1 AND c2=@c2)", result);
        }
    }
}
