using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Generalate.Models;
using Generalate.Models.ViewModels;
using System.Collections;
namespace Generalate.ViewModel
{
    public class GetDashboardViewmodel
    {
        public int SocietyDrop { get; set; }
        public Dictionary<int,string> AllSocieties { get; set; }
        public int CongrationDrop { get; set; }
        public Dictionary<string, string> AllCongdata { get; set; }
        public int CongsDrop { get; set; }
        public Dictionary<string, string> AllCongdict { get; set; }
        public int ComOSDrop { get; set; }
        public Dictionary<int, string> Allcommosdict { get; set; }
        public int DisSecDrop { get; set; }
        public Dictionary<string, string> AllDiosecDict { get; set; }
        public int ProvinceDrop1 { get; set; }
        public Dictionary<string, string> GetAllProvinceDict { get; set; }
        public int ProvinceDrop { get; set; }
        public string TblPersoneldetails { get; set; }
        public List<tbl_PersonalDetails>tbl_PersonalDetails { get; set; }
        public int persionNames { get; set; }
        public Dictionary<int, string> personeltable { get; set; }
        public Hashtable personeltable1 { get; set; }
        public string Birthdaydata { get; set; }
        public string Eternaldata { get; set; }
        public string Newsletter { get; set; }
        public string Circular { get; set; }
        public string JubiliData { get; set; }
    }

    public class TempClass
    {
        public string MemberId { get; set; }
        public string StageOfFormation { get; set; }
        public string Provincename { get; set; }    
    }

    public class TempPersonelData
    {
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string SirName { get; set; }
        public long PersonalDetailsId { get; set; }
    }

    public class TempPersonelDataViewmodel
    {
        public string MemberID { get; set; }
        public string Name { get; set; }
        public string SirName { get; set; }
        public long PersonalDetailsId { get; set; }
        public string DOB { get; set; }
        public string UploadPhoto { get; set; }
        public string Provincename { get; set; }
        public string FileNo { get; set; }
        public string NameBaptismial { get; set; }
        public string Country { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string AppiontmentType { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Image { get; set; }
        public string ProvinceId { get; set; }
        public string Continent { get; set; }
        public string MotherTongue { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Age { get; set; }
        public string FirstNoviDate { get; set; }
        public string SecondNoviDate { get; set; }
        public string PreNoviDate { get; set; }
        public string JubilyType { get; set; }
        public string ArcheveNO { get; set; }
        public string Course { get; set; }
        public string GenFileNo { get; set; }
        public string NameofProvince { get; set; }
        public string Diedcheck { get; set; }
        public string Sapcheck { get; set; }
        public string Archivecheck { get; set; }
        public string IsTransfer { get; set; }
        public bool IsDeleted { get; set; }

    }

    public class TempDeathviewmodel
    {
        public string MemberID { get; set; }
        public string Name { get; set; }
        public string SirName { get; set; }
        public long PersonalDetailsId { get; set; }
        public string DOB { get; set; }
        public string UploadPhoto { get; set; }
        public string Date { get; set; }
        public string Spare1 { get; set; }
        public string Provincename { get; set; }
        public string CurrentStatusFor { get; set; }
        public string age { get; set; }
        public string time { get; set; }
        public string Cause { get; set; }
        public string LastPlaceRites { get; set; }
        public string LastNatureRites { get; set; }
        public string Description { get; set; }
        public string ProvinceName { get; set; }


    }

    public class PersonelDetailscachetbl
    {
        public List<string> MemberInCandi { get; set; }
        public List<string> MemberInNovi { get; set; }
        public List<string> MemberInNovIst { get; set; }
        public List<string> MemberInNovIInd { get; set; }
        public List<string> firstvow { get; set; }
        public List<string> finalvow { get; set; }
        public List<TempPersonelDataViewmodel> Personeldetails { get;set; }
        public List<tbl_SeperationFromTheCongregation> seperationdata { get; set; }
        public List<TempDeathviewmodel>Deathdata { get; set; }
        public List<TempClass> MemberIncandidates { get; set; }
        public List<TempClass> MemberInnovitiates { get; set; }
        public List<TempClass> MemberIstNovitiate { get; set; }
        public List<TempClass> MemberInIIndNovitiate { get; set; }
        public List<TempClass> MemberInfirstvow { get; set; }
        public List<TempClass> MemberInFinalvow { get; set; }
        public List<PersonalDetailsViewModel>personalDetailsViewModels { get; set; }
    }

    public class TempSeprationViewmodel
    {
        public string MemberID { get; set; }
        public string Name { get; set; }
        public string SirName { get; set; }
        public string ProvinceName { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string age { get; set; }
        public string Title { get; set; }
        public string NameofProvince { get; set; }
    }

}   