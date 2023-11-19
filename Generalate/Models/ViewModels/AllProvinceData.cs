using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class AllProvinceData
    {
        public string ProvinceName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string EmailId { get; set; }
        public string Fax { get; set; }
        public string website { get; set; }
        public string Country { get; set; }
        public string Provincecode { get; set; }
        public List<CommunityDetails> CommunityDetails { get; set; }
        public List<ProvinceCouncil> ProvinceCouncils { get; set; }
        public List<ProvinceCouncil> ProvinceSuperior { get; set; }
        public List<ProvinceCouncil> ProvinceCouncilor { get; set; }
        public List<ProvinceCouncil> Treaserer { get; set; }
        public List<ProvinceCouncil> Secretary { get; set; }
        public List<AllMembers> AllMembers { get; set; }
        public List<Responsibility> Responsibility { get; set; }
        public ProvinceCouncil superiorgeneral { get; set; }
        public ProvinceCouncil Generaltreaserer { get; set; }
        public ProvinceCouncil GeneralSecretary { get; set; }
        public List<ProvinceCouncil>Generalcouncil { get; set; }
        public tbl_Province province { get; set; }
        public string Congregation { get; set; }
        public string Congregation_id { get; set; }
        public string Congregation_Country { get; set; }
        public int provsuperiorcnt { get; set; }
        public int procouncilcnt { get; set; }
        public int protreasecnt { get; set; }
        public int proseccnt { get; set; }
        public List<AppointmentsMember> Outsideprovince { get; set; }
        public List<AppointmentsMember> Outsideprovince1 { get; set; }
        public int ospcount { get; set; }
    }
    public class ProvinceCouncil
    {
        public string CouncilMember { get; set; }
        public string SurName { get; set; }
        public string Designation { get; set; }
        public string MemEmail { get; set; }
        public string MemPhone { get; set; }
        public int Id { get; internal set; }
        public object Name { get; internal set; }
        public string Responsibility { get; internal set; }
        public int count { get; set; }

    }
    public class CommunityDetails
    {
        public string CommunityName { get; set; }
        public string CommunityCode { get; set; }
        public string CommunityPlace { get; set; }
        public string CommunityAddress { get; set; }
        public string CommunityPhone { get; set; }
        public string CommunityEmailId { get; set; }
        public string CommunityCountry { get; set; }
        public List<AppointmentsMember> AppointmentsMember { get; set; }
        public List<AppointmentsMember> Appointment { get; set; }
    }
    public class AppointmentsMember
    {
        public string MemberName { get; set; }
        public string SurName { get; set; }
        public string Designation { get; set; }
        public string MemEmail { get; set; }
        public string MemPhone { get; set; }
    }
    public class AllMembers
    {
        public string ProMemberName { get; set; }
        public string ProSurName { get; set; }
        public string DateOfBirth { get; set; }
        public string ProCountry { get; set; }
        public string ProFirstVows { get; set; }
        public string ProFinalVows { get; set; }
        public string ProMemCode { get; set; }
    }

    public class Responsibility
    {
        public string ResponsibilityName { get; set; }
        public List<ProvinceComission> ProvinceComission { get; set; }
    }

    public class ProvinceComission
    {
        public string ComisMemName { get; set; }
        public string ComisDesignation { get; set; }
        public string ComisAddress { get; set; }
        public string Comisstate { get; set; }
        public string ComisPlace { get; set; }
        public string ComisPin { get; set; }
        public string ComisCountry { get; set; }
        public string ComisEmail { get; set; }
        public string ComisTelephone { get; set; }
    }
}