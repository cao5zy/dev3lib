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
        public void ToDic_Success()
        {
            testEnum e = new testEnum();
            var dic = EnumExtension.ToDic<testEnum>();

            Assert.IsTrue(dic.Count == 5);
            Assert.AreEqual("Hello", dic[(int)testEnum.Hello]);
            Assert.AreEqual("A B", dic[(int)testEnum.AB]);
            Assert.AreEqual("C/D", dic[(int)testEnum.C_D]);
            Assert.AreEqual("Ab Cd", dic[(int)testEnum.AbCd]);
            Assert.AreEqual("B2B", dic[(int)testEnum.B2B]);
        }

        [TestMethod]
        public void TryGetEnumValue_Success()
        {
            string val = "3";
            testEnum outVal;

            if (val.ToInt32().TryGetEnumValue<testEnum>(out outVal))
                Assert.AreEqual(testEnum.AbCd, outVal);
        }

        [TestMethod]
        public void GetEnumValue_Success()
        {
            string val = "3";

            Assert.AreEqual(testEnum.AbCd, val.ToInt32().GetEnumValue(testEnum.AB));
        }
        [TestMethod]
        [ExpectedException(typeof(EnumValueException))]
        public void GetEnumValue_Fail()
        {
            string val = "5";

            Assert.AreEqual(testEnum.AbCd, val.ToInt32().GetEnumValue(testEnum.AB, true));
        }

        [TestMethod]
        public void ToName_Normal_Success()
        {
            testEnum t = testEnum.AbCd;

            Assert.AreEqual("Ab Cd", t.ToName());
        }

        [TestMethod]
        public void ToName_Default_Success()
        {
            testEnum t = testEnum.AbCd;

            Assert.AreEqual("ABCD", t.ToName("ABCD"));
        }
    }
}
