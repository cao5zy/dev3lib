using Dev3Lib.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenNETCF.Media.MP3;
using IdSharp.Tagging.ID3v1;
using IdSharp.Tagging.ID3v2;

namespace Dev3Lib.Test
{
    
    
    /// <summary>
    ///This is a test class for Mp3TagID3V1Test and is intended
    ///to contain all Mp3TagID3V1Test Unit Tests
    ///</summary>
    [TestClass()]
    public class Mp3TagID3V1Test
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


        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void IsEdit_False_Test()
        {
            string fileName = @"f:\30.mp3";
            Mp3TagID3V1 target = new Mp3TagID3V1(fileName);

            Assert.IsFalse(target.IsEdited());
        }

        [TestMethod]
        public void IsEdit_True_Test()
        {
            string fileName = @"f:\30.mp3";
            Mp3TagID3V1 target = new Mp3TagID3V1(fileName);

            target.Title = "czy sermox";
            target.Artist = "czy";
            target.Album = "sses";
            target.Year = "2332";

            Assert.IsTrue(target.IsEdited());

            target.Save();
        }

        [TestMethod]
        public void Save_Test()
        {
            string fileName = @"f:\tj.mp3";
            Mp3TagID3V1 target = new Mp3TagID3V1(fileName);

            target.Title = "czy";
            target.Comment = "edit by czy";
            target.Save();

            target = new Mp3TagID3V1(fileName);

            Assert.AreEqual("czy", target.Title);

        }

        [TestMethod]
        public void Edit_Test()
        {
            ID3Tag tag = ID3Tag.FromFile(@"f:\30.mp3");
            string title = tag.Title;
            string artist = tag.Artist;

            tag.Title = "czy";
            tag.Artist = "czy artist";
            tag.WriteToFile();
        }

        [TestMethod]
        public void IdSharp_Tagging_ID3v1()
        {
            ID3v1Tag tag = new ID3v1Tag(@"f:\30.mp3");
            string album = tag.Album;
            string artist = tag.Artist;
            string title = tag.Title;

            tag.Album = "for czy";
            tag.Save(@"f:\30.mp3");
        }

        [TestMethod]
        public void IdSharp_Tagging_ID3v2()
        {
            ID3v2Tag tag = new ID3v2Tag(@"f:\30.mp3");
            string album = tag.Album;
            string artist = tag.Artist;
            string title = tag.Title;

            tag.Album = "for czy";
            tag.Title = "czy's mp3";
            tag.Artist = "czy and czy";
            tag.Year = "2033";
            tag.Save(@"f:\30.mp3");
        }
    }
}
