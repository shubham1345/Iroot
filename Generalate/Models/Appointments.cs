using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Appointments : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string MemberId { get; set; }
        [StringLength(150)]
        public string CongId { get; set; }
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Date { get; set; }
        [StringLength(150)]
        public string FromDate { get; set; }
        [StringLength(150)]
        public string ToDate { get; set; }
        [StringLength(1000)]
        public string doc { get; set; }
        public string Description { get; set; }
        [StringLength(500)]
        public string AppointmentType { get; set; }
        [StringLength(100)]
        public string drpNameType { get; set; }
        [StringLength(1500)]
        public string DesignationType { get; set; }
        [StringLength(500)]
        public string InstitutionType { get; set; }
        [StringLength(500)]
        public string CommunityType { get; set; }
        [StringLength(150)]
        public string Superior { get; set; }
        public string ParisData { get; set; }
        public string Diocese { get; set; }
        public string OSProvince { get; set; }
        public string OSCongName { get; set; }
        public string OSCongProvince { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        [StringLength(200)]
        public string SGGeneralate { get; set; }
        public string InsDesignationType { get; set; }
        public string OptionGuid { get; set; }
        public string Status { get; set; }
        public string Mandate { get; set; }
        public string Place { get; set; }

    }
}

