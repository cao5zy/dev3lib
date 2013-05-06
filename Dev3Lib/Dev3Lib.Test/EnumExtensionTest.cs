using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dev3Lib.Util;

namespace Dev3Lib.Test
{
    [TestClass]
    public class EnumExtensionTest
    {
        enum testEnum
        { 
            Hello,
            AB,
            C_D,
            AbCd,
        }
        [TestMethod]
        public void ToList_Success()
        {
            testEnum e = new testEnum();
            var list = EnumExtension.ToList<testEnum>();

            Assert.IsTrue(list.Count == 4);
            Assert.AreEqual("Hello", list[0].Value);
            Assert.AreEqual("A B", list[1].Value);
            Assert.AreEqual("C/D", list[2].Value);
            Assert.AreEqual("Ab Cd", list[3].Value);
        }
    }
}
