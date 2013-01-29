using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using Dev3Lib.Sql;
using System.Data.SqlClient;
using System.Data;

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
        private Converter<IDataReader, TestItem> _convert = reader => new TestItem
        {
            AupairId = Convert.IsDBNull(reader["AupairId"]) ? 0 : Convert.ToInt32(reader["AupairId"]),
            AuPairStatusID = Convert.IsDBNull(reader["AuPairStatusID"]) ? 0 : Convert.ToInt32(reader["AuPairStatusID"]),
            BlockedFlag = Convert.IsDBNull(reader["BlockedFlag"]) ? false : Convert.ToBoolean(reader["BlockedFlag"]),
            FirstName = Convert.IsDBNull(reader["FirstName"]) ? string.Empty : Convert.ToString(reader["FirstName"]),
            LastName = Convert.IsDBNull(reader["LastName"]) ? string.Empty : Convert.ToString(reader["LastName"]),
            GenderId = Convert.IsDBNull(reader["GenderId"]) ? (short)0 : Convert.ToInt16(reader["GenderId"]),
            Email = Convert.IsDBNull(reader["Email"]) ? string.Empty : Convert.ToString(reader["Email"]),
            Password = Convert.IsDBNull(reader["Password"]) ? string.Empty : Convert.ToString(reader["Password"]),
            CurrentAddressLine1 = Convert.IsDBNull(reader["CurrentAddressLine1"]) ? string.Empty : Convert.ToString(reader["CurrentAddressLine1"]),
            CurrentAddressLine2 = Convert.IsDBNull(reader["CurrentAddressLine2"]) ? string.Empty : Convert.ToString(reader["CurrentAddressLine2"]),
            CurrentTown = Convert.IsDBNull(reader["CurrentTown"]) ? string.Empty : Convert.ToString(reader["CurrentTown"]),
            CurrentState = Convert.IsDBNull(reader["CurrentState"]) ? string.Empty : Convert.ToString(reader["CurrentState"]),
            CurrentCountryId = Convert.IsDBNull(reader["CurrentCountryId"]) ? (short)0 : Convert.ToInt16(reader["CurrentCountryId"]),
            PostalAddressLine1 = Convert.IsDBNull(reader["PostalAddressLine1"]) ? string.Empty : Convert.ToString(reader["PostalAddressLine1"]),
            PostalAddressLine2 = Convert.IsDBNull(reader["PostalAddressLine2"]) ? string.Empty : Convert.ToString(reader["PostalAddressLine2"]),
            PostalTown = Convert.IsDBNull(reader["PostalTown"]) ? string.Empty : Convert.ToString(reader["PostalTown"]),
            PostalState = Convert.IsDBNull(reader["PostalState"]) ? string.Empty : Convert.ToString(reader["PostalState"]),
            PostalCountryId = Convert.IsDBNull(reader["PostalCountryId"]) ? (short)0 : Convert.ToInt16(reader["PostalCountryId"]),
            NationalityCountryId = Convert.IsDBNull(reader["NationalityCountryId"]) ? (short)0 : Convert.ToInt16(reader["NationalityCountryId"]),
            BestPhoneNumber = Convert.IsDBNull(reader["BestPhoneNumber"]) ? string.Empty : Convert.ToString(reader["BestPhoneNumber"]),
            Skypename = Convert.IsDBNull(reader["Skypename"]) ? string.Empty : Convert.ToString(reader["Skypename"]),
            BestTimeToCall = Convert.IsDBNull(reader["BestTimeToCall"]) ? string.Empty : Convert.ToString(reader["BestTimeToCall"]),
            FirstMembershipDate = Convert.IsDBNull(reader["FirstMembershipDate"]) ? System.DateTime.Now : Convert.ToDateTime(reader["FirstMembershipDate"]),
            MembershipStart = Convert.IsDBNull(reader["MembershipStart"]) ? System.DateTime.Now : Convert.ToDateTime(reader["MembershipStart"]),
            MembershipEnd = Convert.IsDBNull(reader["MembershipEnd"]) ? System.DateTime.Now : Convert.ToDateTime(reader["MembershipEnd"]),
            CurrentMembershipPremium = Convert.IsDBNull(reader["CurrentMembershipPremium"]) ? false : Convert.ToBoolean(reader["CurrentMembershipPremium"]),
            PowerSearchStartDate = Convert.IsDBNull(reader["PowerSearchStartDate"]) ? System.DateTime.Now : Convert.ToDateTime(reader["PowerSearchStartDate"]),
            PowerSearchEndDate = Convert.IsDBNull(reader["PowerSearchEndDate"]) ? System.DateTime.Now : Convert.ToDateTime(reader["PowerSearchEndDate"]),
            CurrentPowerSearch = Convert.IsDBNull(reader["CurrentPowerSearch"]) ? false : Convert.ToBoolean(reader["CurrentPowerSearch"]),
            AupairConnect = Convert.IsDBNull(reader["AupairConnect"]) ? false : Convert.ToBoolean(reader["AupairConnect"]),
            LastPaymentMethod = Convert.IsDBNull(reader["LastPaymentMethod"]) ? string.Empty : Convert.ToString(reader["LastPaymentMethod"]),
            LastLoggedIn = Convert.IsDBNull(reader["LastLoggedIn"]) ? System.DateTime.Now : Convert.ToDateTime(reader["LastLoggedIn"]),
            AvailableToStartFrom = Convert.IsDBNull(reader["AvailableToStartFrom"]) ? System.DateTime.Now : Convert.ToDateTime(reader["AvailableToStartFrom"]),
            AvailableToStartTo = Convert.IsDBNull(reader["AvailableToStartTo"]) ? System.DateTime.Now : Convert.ToDateTime(reader["AvailableToStartTo"]),
            AvailableDurationFromId = Convert.IsDBNull(reader["AvailableDurationFromId"]) ? (short)0 : Convert.ToInt16(reader["AvailableDurationFromId"]),
            AvailableDurationToId = Convert.IsDBNull(reader["AvailableDurationToId"]) ? (short)0 : Convert.ToInt16(reader["AvailableDurationToId"]),
            MustBeHomeByDate = Convert.IsDBNull(reader["MustBeHomeByDate"]) ? System.DateTime.Now : Convert.ToDateTime(reader["MustBeHomeByDate"]),
            Tattoos = Convert.IsDBNull(reader["Tattoos"]) ? false : Convert.ToBoolean(reader["Tattoos"]),
            Piercings = Convert.IsDBNull(reader["Piercings"]) ? false : Convert.ToBoolean(reader["Piercings"]),
            TattooInfo = Convert.IsDBNull(reader["TattooInfo"]) ? string.Empty : Convert.ToString(reader["TattooInfo"]),
            PiercingInfo = Convert.IsDBNull(reader["PiercingInfo"]) ? string.Empty : Convert.ToString(reader["PiercingInfo"]),
            CanSwim = Convert.IsDBNull(reader["CanSwim"]) ? false : Convert.ToBoolean(reader["CanSwim"]),
            HasFirstAidTraining = Convert.IsDBNull(reader["HasFirstAidTraining"]) ? false : Convert.ToBoolean(reader["HasFirstAidTraining"]),
            IsHappyLookAfterPets = Convert.IsDBNull(reader["IsHappyLookAfterPets"]) ? false : Convert.ToBoolean(reader["IsHappyLookAfterPets"]),
            IsHappyLiveWithPets = Convert.IsDBNull(reader["IsHappyLiveWithPets"]) ? false : Convert.ToBoolean(reader["IsHappyLiveWithPets"]),
            CookingSkillLevelId = Convert.IsDBNull(reader["CookingSkillLevelId"]) ? (short)0 : Convert.ToInt16(reader["CookingSkillLevelId"]),
            LightHousework = Convert.IsDBNull(reader["LightHousework"]) ? false : Convert.ToBoolean(reader["LightHousework"]),
            Cleaning = Convert.IsDBNull(reader["Cleaning"]) ? false : Convert.ToBoolean(reader["Cleaning"]),
            ShoppingErrands = Convert.IsDBNull(reader["ShoppingErrands"]) ? false : Convert.ToBoolean(reader["ShoppingErrands"]),
            ElderlyCare = Convert.IsDBNull(reader["ElderlyCare"]) ? false : Convert.ToBoolean(reader["ElderlyCare"]),
            FamilyMustHavePhoto = Convert.IsDBNull(reader["FamilyMustHavePhoto"]) ? false : Convert.ToBoolean(reader["FamilyMustHavePhoto"]),
            CanDoWebcam = Convert.IsDBNull(reader["CanDoWebcam"]) ? false : Convert.ToBoolean(reader["CanDoWebcam"]),
            FamilyMustDoWebcam = Convert.IsDBNull(reader["FamilyMustDoWebcam"]) ? false : Convert.ToBoolean(reader["FamilyMustDoWebcam"]),
            AupairCouple = Convert.IsDBNull(reader["AupairCouple"]) ? false : Convert.ToBoolean(reader["AupairCouple"]),
            CareForUpToChildrenId = Convert.IsDBNull(reader["CareForUpToChildrenId"]) ? (short)0 : Convert.ToInt16(reader["CareForUpToChildrenId"]),
            PrimaryReligionId = Convert.IsDBNull(reader["PrimaryReligionId"]) ? (short)0 : Convert.ToInt16(reader["PrimaryReligionId"]),
            ReligionImportant = Convert.IsDBNull(reader["ReligionImportant"]) ? false : Convert.ToBoolean(reader["ReligionImportant"]),
            HasDriversLicence = Convert.IsDBNull(reader["HasDriversLicence"]) ? false : Convert.ToBoolean(reader["HasDriversLicence"]),
            DriverSkillLevelId = Convert.IsDBNull(reader["DriverSkillLevelId"]) ? (short)0 : Convert.ToInt16(reader["DriverSkillLevelId"]),
            IsASmoker = Convert.IsDBNull(reader["IsASmoker"]) ? false : Convert.ToBoolean(reader["IsASmoker"]),
            WorkInSmokingHouse = Convert.IsDBNull(reader["WorkInSmokingHouse"]) ? false : Convert.ToBoolean(reader["WorkInSmokingHouse"]),
            DisabledChildren = Convert.IsDBNull(reader["DisabledChildren"]) ? false : Convert.ToBoolean(reader["DisabledChildren"]),
            InfantCare = Convert.IsDBNull(reader["InfantCare"]) ? false : Convert.ToBoolean(reader["InfantCare"]),
            SingleMotherId = Convert.IsDBNull(reader["SingleMotherId"]) ? (short)0 : Convert.ToInt16(reader["SingleMotherId"]),
            SingleFatherId = Convert.IsDBNull(reader["SingleFatherId"]) ? (short)0 : Convert.ToInt16(reader["SingleFatherId"]),
            FamilyFromAgeId = Convert.IsDBNull(reader["FamilyFromAgeId"]) ? (short)0 : Convert.ToInt16(reader["FamilyFromAgeId"]),
            FamilyToAgeId = Convert.IsDBNull(reader["FamilyToAgeId"]) ? (short)0 : Convert.ToInt16(reader["FamilyToAgeId"]),
            AupairExperienceId = Convert.IsDBNull(reader["AupairExperienceId"]) ? (short)0 : Convert.ToInt16(reader["AupairExperienceId"]),
            AupairEducationId = Convert.IsDBNull(reader["AupairEducationId"]) ? (short)0 : Convert.ToInt16(reader["AupairEducationId"]),
            HaveBeenAupairBefore = Convert.IsDBNull(reader["HaveBeenAupairBefore"]) ? false : Convert.ToBoolean(reader["HaveBeenAupairBefore"]),
            DietaryDescription = Convert.IsDBNull(reader["DietaryDescription"]) ? string.Empty : Convert.ToString(reader["DietaryDescription"]),
            PersonalInformationMessage = Convert.IsDBNull(reader["PersonalInformationMessage"]) ? string.Empty : Convert.ToString(reader["PersonalInformationMessage"]),
            FamilyMessage = Convert.IsDBNull(reader["FamilyMessage"]) ? string.Empty : Convert.ToString(reader["FamilyMessage"]),
            DisplayPhoneToPremiumMembers = Convert.IsDBNull(reader["DisplayPhoneToPremiumMembers"]) ? false : Convert.ToBoolean(reader["DisplayPhoneToPremiumMembers"]),
            ShareEmailWithConnect = Convert.IsDBNull(reader["ShareEmailWithConnect"]) ? false : Convert.ToBoolean(reader["ShareEmailWithConnect"]),
            HowHear = Convert.IsDBNull(reader["HowHear"]) ? string.Empty : Convert.ToString(reader["HowHear"]),
            RegistrationStatus = Convert.IsDBNull(reader["RegistrationStatus"]) ? string.Empty : Convert.ToString(reader["RegistrationStatus"]),
            CurrentPostcode = Convert.IsDBNull(reader["CurrentPostcode"]) ? string.Empty : Convert.ToString(reader["CurrentPostcode"]),
            PostalPostcode = Convert.IsDBNull(reader["PostalPostcode"]) ? string.Empty : Convert.ToString(reader["PostalPostcode"]),
            Photo1 = Convert.IsDBNull(reader["Photo1"]) ? string.Empty : Convert.ToString(reader["Photo1"]),
            Photo2 = Convert.IsDBNull(reader["Photo2"]) ? string.Empty : Convert.ToString(reader["Photo2"]),
            Photo3 = Convert.IsDBNull(reader["Photo3"]) ? string.Empty : Convert.ToString(reader["Photo3"]),
            Photo4 = Convert.IsDBNull(reader["Photo4"]) ? string.Empty : Convert.ToString(reader["Photo4"]),
            Photo5 = Convert.IsDBNull(reader["Photo5"]) ? string.Empty : Convert.ToString(reader["Photo5"]),
            Photo6 = Convert.IsDBNull(reader["Photo6"]) ? string.Empty : Convert.ToString(reader["Photo6"]),
            HomeCountryID = Convert.IsDBNull(reader["HomeCountryID"]) ? (short)0 : Convert.ToInt16(reader["HomeCountryID"]),
            HomeCity = Convert.IsDBNull(reader["HomeCity"]) ? string.Empty : Convert.ToString(reader["HomeCity"]),
            DateOfBirth = Convert.IsDBNull(reader["DateOfBirth"]) ? System.DateTime.Now : Convert.ToDateTime(reader["DateOfBirth"]),
            WillCook = Convert.IsDBNull(reader["WillCook"]) ? false : Convert.ToBoolean(reader["WillCook"]),
            TimezoneName = Convert.IsDBNull(reader["TimezoneName"]) ? string.Empty : Convert.ToString(reader["TimezoneName"]),
            Loc_Latitude = Convert.IsDBNull(reader["Loc_Latitude"]) ? 0 : Convert.ToDecimal(reader["Loc_Latitude"]),
            Loc_Longitude = Convert.IsDBNull(reader["Loc_Longitude"]) ? 0 : Convert.ToDecimal(reader["Loc_Longitude"]),
            TimezoneOffset = Convert.IsDBNull(reader["TimezoneOffset"]) ? 0 : Convert.ToDecimal(reader["TimezoneOffset"]),
            HasSavedDetails = Convert.IsDBNull(reader["HasSavedDetails"]) ? false : Convert.ToBoolean(reader["HasSavedDetails"]),
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
                   new WhereClause(1,"AuPairStatusID")
                   .And(new WhereClause(DateTime.Parse("2012-07-13"), "LastLoggedIn","LastLoggedIn1", Comparison.GreatorThanEqualTo)
                        .And(new WhereClause(DateTime.Parse("2012-12-12"),"LastLoggedIn","LastLoggedIn2", Comparison.LessThan))));
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
             * */

            Action<ISelector> run = (selector) =>
            {

                var reader = selector.Read<TestItem>(_convert,
                   "select * from tblTBAAupair",
                   new WhereClause(0, "BlockedFlag")
                   .And(new InClause(new object[] { 1, 2, 3 }, "AuPairStatusID"))
                    .And(new WhereClause(DateTime.Parse("2012-9-1"), "LastLoggedIn", Comparison.GreatorThan)));
                int count = 0;
                while (reader.MoveNext())
                    count++;

                Assert.AreEqual(1194, count);
            };

            RunSql(run);
        }
        private void RunSql(Action<ISelector> run)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<SqlSelector>().As<ISelector>();

            using (SqlConnection conn = new SqlConnection("Initial Catalog=tbaDATA;Data Source=(local)\\Sqlexpress;Integrated Security=true"))
            {
                conn.Open();

                builder.RegisterInstance<SqlConnection>(conn).ExternallyOwned();

                var selector = builder.Build().Resolve<ISelector>();

                run(selector);

            }
        }
    }
}
