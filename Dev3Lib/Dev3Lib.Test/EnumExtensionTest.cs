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
            B2B,
        }
        [TestMethod]
        public void ToList_Success()
        {
            testEnum e = new testEnum();
            var list = EnumExtension.ToList<testEnum>();

            Assert.IsTrue(list.Count == 5);
            Assert.AreEqual("Hello", list[0].Value);
            Assert.AreEqual("A B", list[1].Value);
            Assert.AreEqual("C/D", list[2].Value);
            Assert.AreEqual("Ab Cd", list[3].Value);
            Assert.AreEqual("B2B", list[4].Value);
        }

        [TestMethod]
        public void TryGetEnumValue_Success()
        {
            string val = "3";
            testEnum outVal;

            if (val.TryGetEnumValue<testEnum>(out outVal))
                Assert.AreEqual(testEnum.AbCd, outVal);
        }

        [TestMethod]
        public void GetEnumValue_Success()
        {
            string val = "3";

            Assert.AreEqual(testEnum.AbCd, val.GetEnumValue(testEnum.AB));
        }
        [TestMethod]
        [ExpectedException(typeof(EnumValueException))]
        public void GetEnumValue_Fail()
        {
            string val = "5";

            Assert.AreEqual(testEnum.AbCd, val.GetEnumValue(testEnum.AB, true));
        }
    }
}
