using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using Dev3Lib.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Dev3Lib.DbConvert;

namespace Dev3Lib.Test
{
    [TestClass]
    public class SqlSelectorTest
    {
        class TestItem
        {
            public static readonly string _AupairIdColumn = "AupairId";
            public int AupairId { get; set; }


            public static readonly string _AuPairStatusIDColumn = "AuPairStatusID";
            public int AuPairStatusID { get; set; }


            public static readonly string _BlockedFlagColumn = "BlockedFlag";
            public bool BlockedFlag { get; set; }


            public static readonly string _FirstNameColumn = "FirstName";
            public string FirstName { get; set; }


            public static readonly string _LastNameColumn = "LastName";
            public string LastName { get; set; }


            public static readonly string _GenderIdColumn = "GenderId";
            public short GenderId { get; set; }


            public static readonly string _EmailColumn = "Email";
            public string Email { get; set; }


            public static readonly string _PasswordColumn = "Password";
            public string Password { get; set; }


            public static readonly string _CurrentAddressLine1Column = "CurrentAddressLine1";
            public string CurrentAddressLine1 { get; set; }


            public static readonly string _CurrentAddressLine2Column = "CurrentAddressLine2";
            public string CurrentAddressLine2 { get; set; }


            public static readonly string _CurrentTownColumn = "CurrentTown";
            public string CurrentTown { get; set; }


            public static readonly string _CurrentStateColumn = "CurrentState";
            public string CurrentState { get; set; }


            public static readonly string _CurrentCountryIdColumn = "CurrentCountryId";
            public short CurrentCountryId { get; set; }


            public static readonly string _PostalAddressLine1Column = "PostalAddressLine1";
            public string PostalAddressLine1 { get; set; }


            public static readonly string _PostalAddressLine2Column = "PostalAddressLine2";
            public string PostalAddressLine2 { get; set; }


            public static readonly string _PostalTownColumn = "PostalTown";
            public string PostalTown { get; set; }


            public static readonly string _PostalStateColumn = "PostalState";
            public string PostalState { get; set; }


            public static readonly string _PostalCountryIdColumn = "PostalCountryId";
            public short PostalCountryId { get; set; }


            public static readonly string _NationalityCountryIdColumn = "NationalityCountryId";
            public short NationalityCountryId { get; set; }


            public static readonly string _BestPhoneNumberColumn = "BestPhoneNumber";
            public string BestPhoneNumber { get; set; }


            public static readonly string _SkypenameColumn = "Skypename";
            public string Skypename { get; set; }


            public static readonly string _BestTimeToCallColumn = "BestTimeToCall";
            public string BestTimeToCall { get; set; }


            public static readonly string _FirstMembershipDateColumn = "FirstMembershipDate";
            public System.DateTime FirstMembershipDate { get; set; }


            public static readonly string _MembershipStartColumn = "MembershipStart";
            public System.DateTime MembershipStart { get; set; }


            public static readonly string _MembershipEndColumn = "MembershipEnd";
            public System.DateTime MembershipEnd { get; set; }


            public static readonly string _CurrentMembershipPremiumColumn = "CurrentMembershipPremium";
            public bool CurrentMembershipPremium { get; set; }


            public static readonly string _PowerSearchStartDateColumn = "PowerSearchStartDate";
            public System.DateTime PowerSearchStartDate { get; set; }


            public static readonly string _PowerSearchEndDateColumn = "PowerSearchEndDate";
            public System.DateTime PowerSearchEndDate { get; set; }


            public static readonly string _CurrentPowerSearchColumn = "CurrentPowerSearch";
            public bool CurrentPowerSearch { get; set; }


            public static readonly string _AupairConnectColumn = "AupairConnect";
            public bool AupairConnect { get; set; }


            public static readonly string _LastPaymentMethodColumn = "LastPaymentMethod";
            public string LastPaymentMethod { get; set; }


            public static readonly string _LastLoggedInColumn = "LastLoggedIn";
            public System.DateTime LastLoggedIn { get; set; }


            public static readonly string _AvailableToStartFromColumn = "AvailableToStartFrom";
            public System.DateTime AvailableToStartFrom { get; set; }


            public static readonly string _AvailableToStartToColumn = "AvailableToStartTo";
            public System.DateTime AvailableToStartTo { get; set; }


            public static readonly string _AvailableDurationFromIdColumn = "AvailableDurationFromId";
            public short AvailableDurationFromId { get; set; }


            public static readonly string _AvailableDurationToIdColumn = "AvailableDurationToId";
            public short AvailableDurationToId { get; set; }


            public static readonly string _MustBeHomeByDateColumn = "MustBeHomeByDate";
            public System.DateTime MustBeHomeByDate { get; set; }


            public static readonly string _TattoosColumn = "Tattoos";
            public bool Tattoos { get; set; }


            public static readonly string _PiercingsColumn = "Piercings";
            public bool Piercings { get; set; }


            public static readonly string _TattooInfoColumn = "TattooInfo";
            public string TattooInfo { get; set; }


            public static readonly string _PiercingInfoColumn = "PiercingInfo";
            public string PiercingInfo { get; set; }


            public static readonly string _CanSwimColumn = "CanSwim";
            public bool CanSwim { get; set; }


            public static readonly string _HasFirstAidTrainingColumn = "HasFirstAidTraining";
            public bool HasFirstAidTraining { get; set; }


            public static readonly string _IsHappyLookAfterPetsColumn = "IsHappyLookAfterPets";
            public bool IsHappyLookAfterPets { get; set; }


            public static readonly string _IsHappyLiveWithPetsColumn = "IsHappyLiveWithPets";
            public bool IsHappyLiveWithPets { get; set; }


            public static readonly string _CookingSkillLevelIdColumn = "CookingSkillLevelId";
            public short CookingSkillLevelId { get; set; }


            public static readonly string _LightHouseworkColumn = "LightHousework";
            public bool LightHousework { get; set; }


            public static readonly string _CleaningColumn = "Cleaning";
            public bool Cleaning { get; set; }


            public static readonly string _ShoppingErrandsColumn = "ShoppingErrands";
            public bool ShoppingErrands { get; set; }


            public static readonly string _ElderlyCareColumn = "ElderlyCare";
            public bool ElderlyCare { get; set; }


            public static readonly string _FamilyMustHavePhotoColumn = "FamilyMustHavePhoto";
            public bool FamilyMustHavePhoto { get; set; }


            public static readonly string _CanDoWebcamColumn = "CanDoWebcam";
            public bool CanDoWebcam { get; set; }


            public static readonly string _FamilyMustDoWebcamColumn = "FamilyMustDoWebcam";
            public bool FamilyMustDoWebcam { get; set; }


            public static readonly string _AupairCoupleColumn = "AupairCouple";
            public bool AupairCouple { get; set; }


            public static readonly string _CareForUpToChildrenIdColumn = "CareForUpToChildrenId";
            public short CareForUpToChildrenId { get; set; }


            public static readonly string _PrimaryReligionIdColumn = "PrimaryReligionId";
            public short PrimaryReligionId { get; set; }


            public static readonly string _ReligionImportantColumn = "ReligionImportant";
            public bool ReligionImportant { get; set; }


            public static readonly string _HasDriversLicenceColumn = "HasDriversLicence";
            public bool HasDriversLicence { get; set; }


            public static readonly string _DriverSkillLevelIdColumn = "DriverSkillLevelId";
            public short DriverSkillLevelId { get; set; }


            public static readonly string _IsASmokerColumn = "IsASmoker";
            public bool IsASmoker { get; set; }


            public static readonly string _WorkInSmokingHouseColumn = "WorkInSmokingHouse";
            public bool WorkInSmokingHouse { get; set; }


            public static readonly string _DisabledChildrenColumn = "DisabledChildren";
            public bool DisabledChildren { get; set; }


            public static readonly string _InfantCareColumn = "InfantCare";
            public bool InfantCare { get; set; }


            public static readonly string _SingleMotherIdColumn = "SingleMotherId";
            public short SingleMotherId { get; set; }


            public static readonly string _SingleFatherIdColumn = "SingleFatherId";
            public short SingleFatherId { get; set; }


            public static readonly string _FamilyFromAgeIdColumn = "FamilyFromAgeId";
            public short FamilyFromAgeId { get; set; }


            public static readonly string _FamilyToAgeIdColumn = "FamilyToAgeId";
            public short FamilyToAgeId { get; set; }


            public static readonly string _AupairExperienceIdColumn = "AupairExperienceId";
            public short AupairExperienceId { get; set; }


            public static readonly string _AupairEducationIdColumn = "AupairEducationId";
            public short AupairEducationId { get; set; }


            public static readonly string _HaveBeenAupairBeforeColumn = "HaveBeenAupairBefore";
            public bool HaveBeenAupairBefore { get; set; }


            public static readonly string _DietaryDescriptionColumn = "DietaryDescription";
            public string DietaryDescription { get; set; }


            public static readonly string _PersonalInformationMessageColumn = "PersonalInformationMessage";
            public string PersonalInformationMessage { get; set; }


            public static readonly string _FamilyMessageColumn = "FamilyMessage";
            public string FamilyMessage { get; set; }


            public static readonly string _DisplayPhoneToPremiumMembersColumn = "DisplayPhoneToPremiumMembers";
            public bool DisplayPhoneToPremiumMembers { get; set; }


            public static readonly string _ShareEmailWithConnectColumn = "ShareEmailWithConnect";
            public bool ShareEmailWithConnect { get; set; }


            public static readonly string _HowHearColumn = "HowHear";
            public string HowHear { get; set; }


            public static readonly string _RegistrationStatusColumn = "RegistrationStatus";
            public string RegistrationStatus { get; set; }


            public static readonly string _CurrentPostcodeColumn = "CurrentPostcode";
            public string CurrentPostcode { get; set; }


            public static readonly string _PostalPostcodeColumn = "PostalPostcode";
            public string PostalPostcode { get; set; }


            public static readonly string _Photo1Column = "Photo1";
            public string Photo1 { get; set; }


            public static readonly string _Photo2Column = "Photo2";
            public string Photo2 { get; set; }


            public static readonly string _Photo3Column = "Photo3";
            public string Photo3 { get; set; }


            public static readonly string _Photo4Column = "Photo4";
            public string Photo4 { get; set; }


            public static readonly string _Photo5Column = "Photo5";
            public string Photo5 { get; set; }


            public static readonly string _Photo6Column = "Photo6";
            public string Photo6 { get; set; }


            public static readonly string _HomeCountryIDColumn = "HomeCountryID";
            public short HomeCountryID { get; set; }


            public static readonly string _HomeCityColumn = "HomeCity";
            public string HomeCity { get; set; }


            public static readonly string _DateOfBirthColumn = "DateOfBirth";
            public System.DateTime DateOfBirth { get; set; }


            public static readonly string _WillCookColumn = "WillCook";
            public bool WillCook { get; set; }


            public static readonly string _TimezoneNameColumn = "TimezoneName";
            public string TimezoneName { get; set; }


            public static readonly string _Loc_LatitudeColumn = "Loc_Latitude";
            public System.Decimal Loc_Latitude { get; set; }


            public static readonly string _Loc_LongitudeColumn = "Loc_Longitude";
            public System.Decimal Loc_Longitude { get; set; }


            public static readonly string _TimezoneOffsetColumn = "TimezoneOffset";
            public System.Decimal TimezoneOffset { get; set; }


            public static readonly string _HasSavedDetailsColumn = "HasSavedDetails";
            public bool HasSavedDetails { get; set; }
        }
        #region converter
        private Converter<DataReaderAdapter, TestItem> _convert = reader => new TestItem
        {
            AupairId = reader.ToInt32("AupairId"),
            AuPairStatusID = reader.ToInt32("AuPairStatusID"),
            BlockedFlag = reader.ToBoolean("BlockedFlag"),
            FirstName = reader.ToString("FirstName"),
            LastName = reader.ToString("LastName"),
            GenderId = reader.ToShort("GenderId"),
            Email = reader.ToString("Email"),
            Password = reader.ToString("Password"),
            CurrentAddressLine1 = reader.ToString("CurrentAddressLine1"),
            CurrentAddressLine2 = reader.ToString("CurrentAddressLine2"),
            CurrentTown = reader.ToString("CurrentTown"),
            CurrentState = reader.ToString("CurrentState"),
            CurrentCountryId = reader.ToShort("CurrentCountryId"),
            PostalAddressLine1 = reader.ToString("PostalAddressLine1"),
            PostalAddressLine2 = reader.ToString("PostalAddressLine2"),
            PostalTown = reader.ToString("PostalTown"),
            PostalState = reader.ToString("PostalState"),
            PostalCountryId = reader.ToShort("PostalCountryId"),
            NationalityCountryId = reader.ToShort("NationalityCountryId"),
            BestPhoneNumber = reader.ToString("BestPhoneNumber"),
            Skypename = reader.ToString("Skypename"),
            BestTimeToCall = reader.ToString("BestTimeToCall"),
            FirstMembershipDate = reader.ToDateTime("FirstMembershipDate"),
            MembershipStart = reader.ToDateTime("MembershipStart"),
            MembershipEnd = reader.ToDateTime("MembershipEnd"),
            CurrentMembershipPremium = reader.ToBoolean("CurrentMembershipPremium"),
            PowerSearchStartDate = reader.ToDateTime("PowerSearchStartDate"),
            PowerSearchEndDate = reader.ToDateTime("PowerSearchEndDate"),
            CurrentPowerSearch = reader.ToBoolean("CurrentPowerSearch"),
            AupairConnect = reader.ToBoolean("AupairConnect"),
            LastPaymentMethod = reader.ToString("LastPaymentMethod"),
            LastLoggedIn = reader.ToDateTime("LastLoggedIn"),
            AvailableToStartFrom = reader.ToDateTime("AvailableToStartFrom"),
            AvailableToStartTo = reader.ToDateTime("AvailableToStartTo"),
            AvailableDurationFromId = reader.ToShort("AvailableDurationFromId"),
            AvailableDurationToId = reader.ToShort("AvailableDurationToId"),
            MustBeHomeByDate = reader.ToDateTime("MustBeHomeByDate"),
            Tattoos = reader.ToBoolean("Tattoos"),
            Piercings = reader.ToBoolean("Piercings"),
            TattooInfo = reader.ToString("TattooInfo"),
            PiercingInfo = reader.ToString("PiercingInfo"),
            CanSwim = reader.ToBoolean("CanSwim"),
            HasFirstAidTraining = reader.ToBoolean("HasFirstAidTraining"),
            IsHappyLookAfterPets = reader.ToBoolean("IsHappyLookAfterPets"),
            IsHappyLiveWithPets = reader.ToBoolean("IsHappyLiveWithPets"),
            CookingSkillLevelId = reader.ToShort("CookingSkillLevelId"),
            LightHousework = reader.ToBoolean("LightHousework"),
            Cleaning = reader.ToBoolean("Cleaning"),
            ShoppingErrands = reader.ToBoolean("ShoppingErrands"),
            ElderlyCare = reader.ToBoolean("ElderlyCare"),
            FamilyMustHavePhoto = reader.ToBoolean("FamilyMustHavePhoto"),
            CanDoWebcam = reader.ToBoolean("CanDoWebcam"),
            FamilyMustDoWebcam = reader.ToBoolean("FamilyMustDoWebcam"),
            AupairCouple = reader.ToBoolean("AupairCouple"),
            CareForUpToChildrenId = reader.ToShort("CareForUpToChildrenId"),
            PrimaryReligionId = reader.ToShort("PrimaryReligionId"),
            ReligionImportant = reader.ToBoolean("ReligionImportant"),
            HasDriversLicence = reader.ToBoolean("HasDriversLicence"),
            DriverSkillLevelId = reader.ToShort("DriverSkillLevelId"),
            IsASmoker = reader.ToBoolean("IsASmoker"),
            WorkInSmokingHouse = reader.ToBoolean("WorkInSmokingHouse"),
            DisabledChildren = reader.ToBoolean("DisabledChildren"),
            InfantCare = reader.ToBoolean("InfantCare"),
            SingleMotherId = reader.ToShort("SingleMotherId"),
            SingleFatherId = reader.ToShort("SingleFatherId"),
            FamilyFromAgeId = reader.ToShort("FamilyFromAgeId"),
            FamilyToAgeId = reader.ToShort("FamilyToAgeId"),
            AupairExperienceId = reader.ToShort("AupairExperienceId"),
            AupairEducationId = reader.ToShort("AupairEducationId"),
            HaveBeenAupairBefore = reader.ToBoolean("HaveBeenAupairBefore"),
            DietaryDescription = reader.ToString("DietaryDescription"),
            PersonalInformationMessage = reader.ToString("PersonalInformationMessage"),
            FamilyMessage = reader.ToString("FamilyMessage"),
            DisplayPhoneToPremiumMembers = reader.ToBoolean("DisplayPhoneToPremiumMembers"),
            ShareEmailWithConnect = reader.ToBoolean("ShareEmailWithConnect"),
            HowHear = reader.ToString("HowHear"),
            RegistrationStatus = reader.ToString("RegistrationStatus"),
            CurrentPostcode = reader.ToString("CurrentPostcode"),
            PostalPostcode = reader.ToString("PostalPostcode"),
            Photo1 = reader.ToString("Photo1"),
            Photo2 = reader.ToString("Photo2"),
            Photo3 = reader.ToString("Photo3"),
            Photo4 = reader.ToString("Photo4"),
            Photo5 = reader.ToString("Photo5"),
            Photo6 = reader.ToString("Photo6"),
            HomeCountryID = reader.ToShort("HomeCountryID"),
            HomeCity = reader.ToString("HomeCity"),
            DateOfBirth = reader.ToDateTime("DateOfBirth"),
            WillCook = reader.ToBoolean("WillCook"),
            TimezoneName = reader.ToString("TimezoneName"),
            Loc_Latitude = reader.ToDecimal("Loc_Latitude"),
            Loc_Longitude = reader.ToDecimal("Loc_Longitude"),
            TimezoneOffset = reader.ToDecimal("TimezoneOffset"),
            HasSavedDetails = reader.ToBoolean("HasSavedDetails"),
        };
        #endregion
        [TestMethod]
        public void Select_Test()
        {
            /* select * from tblTBAAupair 
where BlockedFlag = 0
and AuPairStatusID = 1
and GenderId = 1
and CurrentCountryId = 13
             * */
            Action<ISelector> run = (selector) =>
            {
                var list = selector.Return<TestItem>(r => new TestItem { }, "select * from tblTBAAupair",
                    new WhereClause(0, "BlockedFlag")
                        .And(new WhereClause(1, "AuPairStatusID"))
                        .And(new WhereClause(1, "GenderId"))
                        .And(new WhereClause(13, "CurrentCountryId")));
                Assert.AreEqual(48, list.Count);
            };

            RunSql(run);
        }


        [TestMethod]
        public void Select_With_Composite_Clause()
        {
            /*
             * select * from tblTBAAupair 
where AuPairStatusID = 1
and (LastLoggedIn >= '2012-07-13' and LastLoggedIn < '2012-12-12')
             * */

            Action<ISelector> run = (selector) =>
            {

                var reader = selector.Read<TestItem>(_convert,
                   "select * from tblTBAAupair",
                   new WhereClause(1, "AuPairStatusID")
                   .And(new WhereClause(DateTime.Parse("2012-07-13"), "LastLoggedIn", "LastLoggedIn1", Comparison.GreatorThanEqualTo)
                        .And(new WhereClause(DateTime.Parse("2012-12-12"), "LastLoggedIn", "LastLoggedIn2", Comparison.LessThan))));
                int count = 0;
                while (reader.MoveNext())
                    count++;

                Assert.AreEqual(1565, count);
            };

            RunSql(run);
        }


        [TestMethod]
        public void Select_With_In_Clause()
        {
            /*
             * select * from tblTBAAupair
where BlockedFlag = 0
and AuPairStatusID in (1,2,3)
and LastLoggedIn > '2012-9-1'
order by BlockedFlag
             * */

            Action<ISelector> run = (selector) =>
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var reader = selector.Read<TestItem>(_convert,
                   "select * from tblTBAAupair",
                   new WhereClause(0, "BlockedFlag")
                   .And(new InClause(new object[] { 1, 2, 3 }, "AuPairStatusID"))
                    .And(new WhereClause(DateTime.Parse("2012-9-1"), "LastLoggedIn", Comparison.GreatorThan)),
                    "BlockedFlag");
                int count = 0;
                while (reader.MoveNext())
                    count++;
                watch.Stop();
                Trace.WriteLine(string.Format("elapsed 1 {0}", watch.ElapsedTicks));

                Assert.AreEqual(1194, count);

                count = 0;

            };

            RunSql(run);

            using (SqlConnection conn = new SqlConnection("Initial Catalog=tbaDATA;Data Source=(local)\\Sqlexpress;Integrated Security=true"))
            {
                conn.Open();
                Stopwatch watch = new Stopwatch();
                int count = 0;
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    watch.Start();
                    cmd.CommandText = "select * from tblTBAAupair where BlockedFlag = 0 and AuPairStatusID in (1,2,3) and LastLoggedIn > '2012-9-1' order by BlockedFlag";
                    cmd.CommandType = CommandType.Text;

                    var reader1 = cmd.ExecuteReader();

                    while (reader1.Read())
                        count++;
                    watch.Stop();

                    Trace.WriteLine(string.Format("elapsed 2 {0}", watch.ElapsedTicks));
                }
            }
        }

        [TestMethod]
        public void Select_DBNull()
        {
            /*
             * select * from [dbo].[tblTBAMessages]
where ResponseDate is null
             * */
            Action<ISelector> run = (selector) =>
            {
                var count = selector.Count("select count(*) from [dbo].[tblTBAMessages]",
                    new DBNullClause("ResponseDate"));

                Assert.AreEqual(3063, count);
            };

            RunSql(run);
        }

        [TestMethod]
        public void Select_NotDbNull()
        {
            /*
             * select * from [dbo].[tblTBAMessages]
where ResponseDate is not null
             * */
            Action<ISelector> run = (selector) =>
            {
                var count = selector.Count("select count(*) from [dbo].[tblTBAMessages]",
                    new DBNotNullClause("ResponseDate"));

                Assert.AreEqual(2361, count);
            };

            RunSql(run);
        }

        [TestMethod]
        public void Select_NoWhere()
        {
            /*
             * 
             * select top 5 * from tbltbaaupair
             * */

            Action<ISelector> run = (selector) =>
            {
                var list = selector.Return<int>((n) => 0, "select top 5 * from tbltbaaupair", null);
                Assert.AreEqual(5, list.Count);

                var reader = selector.Read<int>((n) => 0, "select top 5 * from tbltbaaupair", null);
                int count = 0;
                while (reader.MoveNext())
                    count++;
                Assert.AreEqual(5, count);

                int num = selector.Count("select count(*) from tbltbaaupair", null);
                Assert.AreEqual(1675, num);
            };

            RunSql(run);
        }

        [TestMethod]
        public void Select_LeftLikeWhere()
        {
            /*
             select * from tbltbaaupair
where firstname like '%test'
             */
            Action<ISelector> run = (selector) =>
            {

                var list = selector.Return<int>((n) => 0, "select * from tbltbaaupair", new LikeClause("FirstName", "test"));
                Assert.AreEqual(4, list.Count);
            };

            RunSql(run);
        }

        [TestMethod]
        public void Select_RightLikeWhere()
        {
            /*
             select * from tbltbaaupair
where email like 'test%'
             */
            Action<ISelector> run = (selector) =>
            {

                var list = selector.Return<int>((n) => 0, "select * from tbltbaaupair", new LikeClause("Email", "test",null, Comparison.RightLike));
                Assert.AreEqual(2, list.Count);
            };

            RunSql(run);
        }

        [TestMethod]
        public void Select_BothLikeWhere()
        {
            /*
             select * from tbltbaaupair
where email like '%test%'
             */
            Action<ISelector> run = (selector) =>
            {

                var list = selector.Return<int>((n) => 0, "select * from tbltbaaupair", new LikeClause("Email", "test", null, Comparison.BothLike));
                Assert.AreEqual(4, list.Count);
            };

            RunSql(run);
        }

        [TestMethod]
        public void Select_Performance_Compare()
        {
            /*
             * 
             * select * from tblTBAAupair
where BlockedFlag = 0
and AuPairStatusID in (1,2,3)
and LastLoggedIn > '2012-9-1'
order by BlockedFlag
             * */

            Action<ISelector> run = (selector) =>
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var count = selector.Count(
                   "select count(*) from tblTBAAupair",
                   new WhereClause(0, "BlockedFlag")
                   .And(new InClause(new object[] { 1, 2, 3 }, "AuPairStatusID"))
                    .And(new WhereClause(DateTime.Parse("2012-9-1"), "LastLoggedIn", Comparison.GreatorThan)));

                watch.Stop();
                Trace.WriteLine(string.Format("elapsed 1 {0}", watch.ElapsedTicks));

                Assert.AreEqual(1194, count);
            };

            RunSql(run);

            using (SqlConnection conn = new SqlConnection("Initial Catalog=tbaDATA;Data Source=(local)\\Sqlexpress;Integrated Security=true"))
            {
                conn.Open();
                Stopwatch watch = new Stopwatch();
                int count = 0;
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    watch.Start();
                    cmd.CommandText = "select count(*) from tblTBAAupair where BlockedFlag = 0 and AuPairStatusID in (1,2,3) and LastLoggedIn > '2012-9-1'";
                    cmd.CommandType = CommandType.Text;

                    count = Convert.ToInt32(cmd.ExecuteScalar());

                    watch.Stop();

                    Trace.WriteLine(string.Format("elapsed 2 {0}", watch.ElapsedTicks));
                }
            }
        }
        private void RunSql(Action<ISelector> run)
        {
            using (DependencyFactory.BeginScope())
            {
                DependencyFactory.Resolve<IDbContext>().BeginTransaction();
                run(DependencyFactory.Resolve<ISelector>());
            }
        }

        [ClassInitialize]
        public static void InitClass(TestContext context)
        {
            DependencyFactory.SetContainer(() =>
            {
                ContainerBuilder container = new ContainerBuilder();

                container.RegisterType<DefaultDbContext>().WithParameter(new TypedParameter(typeof(string), @"Initial Catalog=tbaDATA;Data Source=.\Sqlexpress;Integrated Security=true")).As<IDbContext>().InstancePerLifetimeScope();
                container.RegisterType<SqlSelector>().As<ISelector>();

                return container.Build();
            });
        }
    }
}
