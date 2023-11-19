using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class Formationmembers
    {

        public string Name { get; set; }
        public string MemberId { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceCode { get; set; }
        public string FileNo { get; internal set; }
        public string VowsStatus { get; internal set; }
        public string CurrentCommunity { get; internal set; }
        public string DOB { get; internal set; }
        public string Createdby { get; internal set; }
        public string CongregationName { get; internal set; }
        public string CommCode { get; internal set; }
        public string Place { get; internal set; }
        public string Surname { get; internal set; }
        public string Place1 { get; internal set; }
        public string Phone { get; internal set; }
        public string EmailId { get; internal set; }
        public string Surname1 { get; internal set; }
        public string Date { get; internal set; }
        public string Reason { get; internal set; }
        public string Community { get; internal set; }
        public string Address { get; internal set; }
        public string Designation { get; internal set; }
        public int TotalTempVows { get; internal set; }
        public int TotalNoBrothers { get; internal set; }
        public int Total2ndNov { get; internal set; }
        public int Total1stNov { get; internal set; }
        public int TotalPreNov { get; internal set; }
        public int TotalPerVows { get; internal set; }
        public int totalPerpetual { get; internal set; }
        public string FirstVowDate { get; set; }
        public string FinalVowDate { get; set; }
        public string VowsDate { get; set; }

    }
}