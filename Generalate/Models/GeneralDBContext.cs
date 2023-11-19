namespace Generalate.Models
{
    using System.Data.Entity;

    public partial class GeneralDBContext : DbContext
    {

        public GeneralDBContext()
            : base("name=Generalate")
        {

        }
        public virtual DbSet<tblGenCommission> tblGenCommission { get; set; }
        public virtual DbSet<tbl_DistSecCommission> tbl_DistSecCommission { get; set; }
        public virtual DbSet<tbl_DioceseParish> tbl_DioceseParish { get; set; }
        public virtual DbSet<tbl_ParishByProvince> tbl_ParishByProvince { get; set; }
        public virtual DbSet<Tbl_Calender> Tbl_Calender { get; set; }
        public virtual DbSet<tbl_ComOSContact> tbl_ComOSContact { get; set; }
        public virtual DbSet<ComOSProvince> ComOSProvince { get; set; }
        public virtual DbSet<ComOSProContact> ComOSProContact { get; set; }
        public virtual DbSet<tbl_ComOSCommunity> tbl_ComOSCommunity { get; set; }
        public virtual DbSet<tbl_DioceseCom> tbl_DioceseCom { get; set; }
        public virtual DbSet<StaffDetails> StaffDetails { get; set; }
        public virtual DbSet<tbl_HomeVisit> tbl_HomeVisit { get; set; }
        public virtual DbSet<tbl_DioBishSec> tbl_DioBishSec { get; set; }
        public virtual DbSet<tblAllTableParameterAlise> tblAllTableParameterAlise { get; set; }

        public virtual DbSet<tbl_DioceseInst> tbl_DioceseInst { get; set; }
        public virtual DbSet<tbl_ComOSInstitute> tbl_ComOSInstitute { get; set; }
        public virtual DbSet<tbl_DistSecCouncil> tbl_DistSecCouncil { get; set; }
        public virtual DbSet<Tbl_DesignationDetails> Tbl_DesignationDetails { get; set; }

        public virtual DbSet<tbl_DistSector> tbl_DistSector { get; set; }
        public virtual DbSet<tbl_DistSectorData> tbl_DistSectorData { get; set; }
        public virtual DbSet<tbl_Diocese> tbl_Diocese { get; set; }
        public virtual DbSet<tbl_DioceseData> tbl_DioceseData { get; set; }
        public virtual DbSet<ExcelSheetData> ExcelSheetData { get; set; }
        public virtual DbSet<GeneralCouncil> MeetingMinutes { get; set; }
        public virtual DbSet<GeneralMember> GeneralMember { get; set; }
        public virtual DbSet<GeneralTreasurer> GeneralTreasurer { get; set; }
        public virtual DbSet<NewsLetter> NewsLetter { get; set; }
        public virtual DbSet<Circulars> Circulars { get; set; }
        public virtual DbSet<tbl_Archive> tbl_Archive { get; set; }
        public virtual DbSet<GeneralateFileNo> GeneralateFileNo { get; set; }
        public virtual DbSet<ComOutSide> ComOutSide { get; set; }
        public virtual DbSet<ComHouseDetails> ComHouseDetails { get; set; }
        public virtual DbSet<ComOutSideDetails> ComOutSideDetails { get; set; }
        public virtual DbSet<ComHouse> ComHouse { get; set; }
        public virtual DbSet<MyDataCOS> MyDataCOS { get; set; }
        public virtual DbSet<MyComDataCH> MyComDataCH { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<Tbl_RenewalVows> Tbl_RenewalVows { get; set; }
        public virtual DbSet<Tbl_ProvinceCouncil> Tbl_ProvinceCouncil { get; set; }
        public virtual DbSet<Tbl_GovernerSoc> Tbl_GovernerSoc { get; set; }
        public virtual DbSet<Tbl_Governer> Tbl_Governer { get; set; }
        public virtual DbSet<Tbl_Transfer> Tbl_Transfer { get; set; }
        public virtual DbSet<AllProvinceRecord> AllProvinceRecord { get; set; }
        public virtual DbSet<tbl_Complaint> tbl_Complaint { get; set; }
        public virtual DbSet<tbl_EmergencyContact> tbl_EmergencyContact { get; set; }
        public virtual DbSet<tbl_Entry> tbl_Entry { get; set; }
        public virtual DbSet<tbl_EntryLife> tbl_EntryLife { get; set; }
        public virtual DbSet<tbl_EntryLife1> tbl_EntryLife1 { get; set; }
        public virtual DbSet<tblAddExtraCommunity> tblAddExtraCommunity { get; set; }
        public virtual DbSet<tblUserDynamicConfiguration> tblUserDynamicConfiguration { get; set; }


        public virtual DbSet<tbl_Health> tbl_Health { get; set; }
        public virtual DbSet<tbl_HomeLiveAndHomeVisit> tbl_HomeLiveAndHomeVisit { get; set; }
        public virtual DbSet<tbl_Jubilee> tbl_Jubilee { get; set; }
        public virtual DbSet<tbl_KnownLanguages> tbl_KnownLanguages { get; set; }
        public virtual DbSet<tbl_LivingOutsideTheCongregation> tbl_LivingOutsideTheCongregation { get; set; }
        public virtual DbSet<tbl_Passed> tbl_Passed { get; set; }
        public virtual DbSet<tbl_PersonalDetails> tbl_PersonalDetails { get; set; }
        public virtual DbSet<tbl_ReligiousEducation> tbl_ReligiousEducation { get; set; }
        public virtual DbSet<tbl_Retirement> tbl_Retirement { get; set; }
        public virtual DbSet<tbl_SecularEducation> tbl_SecularEducation { get; set; }
        public virtual DbSet<tbl_Seminar> tbl_Seminar { get; set; }
        public virtual DbSet<tbl_SeperationFromTheCongregation> tbl_SeperationFromTheCongregation { get; set; }
        public virtual DbSet<tbl_ServiceInTheCongregation> tbl_ServiceInTheCongregation { get; set; }
        public virtual DbSet<tbl_Insurance> tbl_Insurance { get; set; }
        public virtual DbSet<tbl_TravelRecord> tbl_TravelRecord { get; set; }
        public virtual DbSet<tbl_CommonDataList> tbl_CommonDataList { get; set; }
        public virtual DbSet<tbl_CommonDataListItems> tbl_CommonDataListItems { get; set; }
        public virtual DbSet<Tbl_UserLogins> Tbl_UserLogins { get; set; }
        public virtual DbSet<tbl_UserModuleLogin> tbl_UserModuleLogin { get; set; }
        public virtual DbSet<tbl_CandidatesInformationDoc> tbl_CandidatesInformationDoc { get; set; }
        public virtual DbSet<tbl_CommunicationOfficeDoc> tbl_CommunicationOfficeDoc { get; set; }
        public virtual DbSet<tbl_BookOfAccountsDoc> tbl_BookOfAccountsDoc { get; set; }
        public virtual DbSet<tbl_CommunitiesSocialCentresDoc> tbl_CommunitiesSocialCentresDoc { get; set; }
        public virtual DbSet<tbl_ConfreresDoc> tbl_ConfreresDoc { get; set; }
        public virtual DbSet<tbl_FinancialGuidelineDoc> tbl_FinancialGuidelineDoc { get; set; }
        public virtual DbSet<tbl_FinancialReportDoc> tbl_FinancialReportDoc { get; set; }
        public virtual DbSet<tbl_FomDoc> tbl_FomDoc { get; set; }
        public virtual DbSet<tbl_FormatorsMeetDoc> tbl_FormatorsMeetDoc { get; set; }
        public virtual DbSet<tbl_FundRaisingCommiteeDoc> tbl_FundRaisingCommiteeDoc { get; set; }
        public virtual DbSet<tbl_GeneralateDoc> tbl_GeneralateDoc { get; set; }
        public virtual DbSet<tbl_GeneralMattersDoc> tbl_GeneralMattersDoc { get; set; }
        public virtual DbSet<tbl_MinistryDoc> tbl_MinistryDoc { get; set; }
        public virtual DbSet<tbl_MissionDoc> tbl_MissionDoc { get; set; }
        public virtual DbSet<tbl_OngoingFormationDoc> tbl_OngoingFormationDoc { get; set; }

        public virtual DbSet<tbl_OVCDoc> tbl_OVCDoc { get; set; }
        public virtual DbSet<tbl_ProvincialDoc> tbl_ProvincialDoc { get; set; }
        public virtual DbSet<tbl_SCTDoc> tbl_SCTDoc { get; set; }
        public virtual DbSet<tbl_SocialInstitutionDoc> tbl_SocialInstitutionDoc { get; set; }
        public virtual DbSet<tbl_SpiritualCommunityDoc> tbl_SpiritualCommunityDoc { get; set; }
        public virtual DbSet<tbl_StCamillusProvincialateDoc> tbl_StCamillusProvincialateDoc { get; set; }
        public virtual DbSet<tbl_VocationalTrainingDoc> tbl_VocationalTrainingDoc { get; set; }
        public virtual DbSet<tbl_VocationPromotionDoc> tbl_VocationPromotionDoc { get; set; }

        public virtual DbSet<tbl_Bank_Details> tbl_Bank_Details { get; set; }
        public virtual DbSet<tbl_Soc_Addminstration> tbl_Soc_Addminstration { get; set; }
        public virtual DbSet<tbl_Inst> tbl_Inst { get; set; }
        public virtual DbSet<tbl_InstitutionFinal> tbl_InstitutionFinal { get; set; }
        public virtual DbSet<tbl_Socityadd> tbl_Socityadd { get; set; }
        public virtual DbSet<tbl_institution123> tbl_institution123 { get; set; }
        public virtual DbSet<tbl_InstDetails> tbl_InstDetails { get; set; }
        public virtual DbSet<tbl_LandDetails> tbl_LandDetails { get; set; }
        public virtual DbSet<tbl_Primarydetails> tbl_Primarydetails { get; set; }
        public virtual DbSet<Tbl_ParisInstitutionDetails> Tbl_ParisInstitutionDetails { get; set; }
        public virtual DbSet<Tbl_CommunityInstitutionDetails> Tbl_CommunityInstitutionDetails { get; set; }
        public virtual DbSet<tbl_ProvinceGallery> Tbl_ProvinceGallery { get; set; }
        public virtual DbSet<tbl_CommunityGallery> Tbl_CommunityGallery { get; set; }
        public virtual DbSet<tblProvienceImportantDates> tblProvienceImportantDates { get; set; }
        public virtual DbSet<tblProvinceImportantDates> tblProvinceImportantDates { get; set; }
        public virtual DbSet<tblCommunityImportantDates> tblCommunityImportantDates { get; set; }
        public virtual DbSet<Tbl_Paris> Tbl_Paris { get; set; }
        public virtual DbSet<Tbl_Institution> tbl_Institution { get; set; }
        public virtual DbSet<Tbl_LandDocuments> Tbl_LandDocuments { get; set; }
        public virtual DbSet<Tbl_SocietyDetails> Tbl_SocietyDetails { get; set; }
        public virtual DbSet<Tbl_FormationTypes> Tbl_FormationTypes { get; set; }
        public virtual DbSet<Tbl_formationsDetails> Tbl_formationsDetails { get; set; }
        public virtual DbSet<Tbl_Complains> Tbl_Complains { get; set; }
        public virtual DbSet<tbl_Academy> tbl_Academy { get; set; }
        public virtual DbSet<tbl_unknow> tbl_unknow { get; set; }
        public virtual DbSet<Tbl_Comm> Tbl_Comm { get; set; }
        public virtual DbSet<DataLists> DataLists { get; set; }
        public virtual DbSet<DataListItems> DataListItems { get; set; }
        public virtual DbSet<tblContinentMst> tblContinentMst { get; set; }

        public virtual DbSet<tbl_DocumentType> tbl_DocumentType { get; set; }
        public virtual DbSet<tbl_LandDetailsByProvince> tbl_LandDetailsByProvince { get; set; }


        public virtual DbSet<Tbl_InstitutionAppointmentDetails> Tbl_InstitutionAppointmentDetails { get; set; }
        public virtual DbSet<Tbl_CommunityAppointmentDetails> Tbl_CommunityAppointmentDetails { get; set; }
        public virtual DbSet<Tbl_ProfessionDetails> Tbl_ProfessionDetails { get; set; }
        public virtual DbSet<DataLists2> DataLists2 { get; set; }
        public virtual DbSet<AppointmentData> AppointmentData { get; set; }
        public virtual DbSet<DataListItems2> DataListItems2 { get; set; }
        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<InstutionAppointments> InstutionAppointments { get; set; }
        public virtual DbSet<FamilyDetails> FamilyDetails { get; set; }
        public virtual DbSet<Claustration> Claustrations { get; set; }
        public virtual DbSet<Societys> Societys { get; set; }
        public virtual DbSet<Sacraments> Sacraments { get; set; }
        public virtual DbSet<Tbl_Cong> Tbl_Cong { get; set; }
        public virtual DbSet<tbl_Congregation> tbl_Congregation { get; set; }
        public virtual DbSet<tbl_Province> tbl_Province { get; set; }
        public virtual DbSet<SocietyData> SocietyData { get; set; }
        public virtual DbSet<CongData> CongData { get; set; }
        public virtual DbSet<CongreData> CongreData { get; set; }
        public virtual DbSet<ProvinceData> ProvinceData { get; set; }
        public virtual DbSet<CounCircCommi> CounCircCommi { get; set; }
        public virtual DbSet<SocInsPage> SocInsPage { get; set; }
        public virtual DbSet<Tbl_CongrationsData> Tbl_CongrationsDatas { get; set; }
        public virtual DbSet<Tbl_provinceData> Tbl_provinceDatas { get; set; }
        public DbSet<RolePagePermission> RolePagePermissions { get; set; }
        public DbSet<MultiLanguage> Tbl_MultiLanguage { get; set; }
        public DbSet<TabPermissions> Tbl_TabPermissions { get; set; }
        public DbSet<LoggingTrack> Tbl_LoggingTrack { get; set; }
        public DbSet<tbl_ProCommission> tbl_ProCommission { get; set; }
        public DbSet<tbl_OfficialDocument> tbl_OfficialDocument { get; set; }
        public DbSet<Tbl_ProfessionPlace> Tbl_ProfessionPlace { get; set; }
        public DbSet<tblConfigSetting> tblConfigSetting { get; set; }
        public DbSet<Tbl_AverageAge> Tbl_AverageAge { get; set; }
        public DbSet<Tbl_Languagesetting> Tbl_Languagesetting { get; set; }
        public DbSet<Tbl_Languages> Tbl_Languages { get; set; }
        public DbSet<GeneralSecretary> GeneralSecretary { get; set; }
        public DbSet<Tbl_InstitutionImportantdates> Tbl_InstitutionImportantdates { get; set; }
        public DbSet<Tbl_InstituteGallery> Tbl_InstituteGallery { get; set; }
        public DbSet<Tbl_CommInstiImportantdates> Tbl_CommInstiImportantdates { get; set; }
        public DbSet<Tbl_CommInstiGallery> Tbl_CommInstiGallery { get; set; }
        public DbSet<Tbl_GeneralCommunity> Tbl_GeneralCommunity { get; set; }
        public DbSet<Tbl_ProGeneralMember> Tbl_ProGeneralMember { get; set; }
        public DbSet<Tbl_ProGeneralCouncil> Tbl_ProGeneralCouncil { get; set; }
        public DbSet<Tbl_ProGeneralTreaserer> Tbl_ProGeneralTreaserer { get; set; }
        public DbSet<Tbl_ProGeneralSecretary> Tbl_ProGeneralSecretary { get; set; }
        public DbSet<Tbl_UserRole> Tbl_UserRole { get; set; }
        public DbSet<Tbl_Topmenuheader> Tbl_Topmenuheader { get; set; }
        public DbSet<Tbl_Submenuhead> Tbl_Submenuhead { get; set; }
        public DbSet<Tbl_SubmenuTabs> Tbl_SubmenuTabs { get; set; }
        public DbSet<Tbl_TopMenuPermission> Tbl_TopMenuPermission { get; set; }
        public DbSet<Tbl_formationsStatusYear> Tbl_formationsStatusYear { get; set; }

    }

}  
