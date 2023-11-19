using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Generalate.Models
{
    public partial class tbl_Passed : CommanProperties
    {
        [Key]
        public long PassedId { get; set; }
        public string MemberID { get; set; }
        public string Diedcheck { get; set; }
        public string Name { get; set; }
        public string LastCommunity { get; set; }
        public string Cause { get; set; }
        public string Date { get; set; }
        public string Age { get; set; }
        public string WorkingYear { get; set; }
        public string CurrentStatusFor { get; set; }
        public string CurrentStatusAppo { get; set; }
        public string Time { get; set; }
        public string InstitutionPlace { get; set; }
        public string LastNatureRites { get; set; }
        public string LastPlaceRites { get; set; }
        public string DeathCertificate { get; set; }
        public string obituary { get; set; }
        public string Spare1 { get; set; }
        public string Spare2 { get; set; }
        public string Spare3 { get; set; }
        public string SirName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string ProvinceName { get; set; }
        public string EAge { get; set; }
        public string Added_Year { get; set; }
        public virtual tbl_PersonalDetails tbl_PersonalDetails { get; set; }
    }
}
