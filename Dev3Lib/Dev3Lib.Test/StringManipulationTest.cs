using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dev3Lib.Util;

namespace Dev3Lib.Test
{
    [TestClass]
    public class StringManipulationTest
    {
        [TestMethod]
        public void IndexOfT()
        {
            string s = "http://localhost:9909/test.html";

            Assert.AreEqual(s.IndexOfT('/', 0, 3), 21);
        }
    }
}
