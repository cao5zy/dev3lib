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
            string result = new Where(1,"c1")
                .And(new Where(2,"c2")).WhereClause;

            Assert.AreEqual("(c1=@c1 AND c2=@c2)", result);
        }
    }
}
