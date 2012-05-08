using Dev3Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Dev3Lib.Algorithms;

namespace Dev3Lib.Test
{
    
    
    /// <summary>
    ///This is a test class for PaginationTest and is intended
    ///to contain all PaginationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PaginationTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod()]
        public void GetPageTest()
        {
            int[] items = new int[] { 1,2,3,4,5};

            Pagination<int> p = new Pagination<int>(items, 2);

            Assert.AreEqual(3, p._pagesCount);
            Assert.IsTrue(p.GetPage(2).SafeIsEqual(new[] { 3, 4 }));

            p = new Pagination<int>(items, 3);

            Assert.AreEqual(2, p._pagesCount);
            Assert.IsTrue(p.GetPage(2).SafeIsEqual(new[] { 4, 5 }));
        }
    }
}
