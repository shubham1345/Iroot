using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class MemberReportViewModel
    {
        public tbl_PersonalDetails PersonalDetial { get; set; }
    }

    public class JubliiiData
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string JubliiType { get; set; }
        
        public string UploadPhoto { get; set; }
        public string ProvinceName { get; internal set; }
        public DateTime JubliDate { get; set;}
        public string Date { get; internal set; }
        public string MemberID { get; internal set; }
    }
    public class birthdayData
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string JubliiType { get; set; }
        public string Knowname { get; set; }
        public string Baptismialname { get; set; }
        public string Feastday { get; set; }
        public string DOB { get; set; }
        public string emailid { get; set; }
        public string Ordination { get; set; }
        public int Year { get; set; }
        public int Day { get; set; }
        public string Date { get; set; }
        public string ToDate { get; set; }
        public string Month { get; set; }
        public string DataListItemName { get; set; }
        public string Description { get; set; }
        public string UploadPhoto { get; set; }
    }
    public class eternalData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string JubliiType { get; set; }
        public string Knowname { get; set; }
        public string Baptismialname { get; set; }
        public string DOB { get; set; }
        public string emailid { get; set; }
        public string Ordination { get; set; }
        public int Year { get; set; }
        public int Day { get; set; }
        public string Date { get; set; }
        public string UploadPhoto { get; set; }
        public string Title { get; internal set; }
        public string ProvinceName { get; internal set; }
    }
}