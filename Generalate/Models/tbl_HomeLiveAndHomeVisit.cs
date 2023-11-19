using Generalate.Models.ViewModels;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_HomeLiveAndHomeVisit : CommanProperties
    {
        [Key]
        public long HomeliveId { get; set; }

        [Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

        [StringLength(256)]
        public string Name { get; set; }
        [StringLength(256)]
        public string FromDate { get; set; }
        [StringLength(256)]
        public string ToDate { get; set; }

        [DisplayName("Departure Date")]
        public string DepartureDate { get; set; }

        [DisplayName("Arrival Date")]
        public string ArrivalDate { get; set; }

        [DisplayName("Formation Term")]
        [StringLength(500)]
        public string ColName { get; set; }

        //[DisplayName("Number of Days")]
        //public int? NoOfDays { get; set; }

        [StringLength(200)]
        public string Purpose { get; set; }

        [StringLength(200)]
        public string Place { get; set; }
        public string Description { get; set; }

        [StringLength(35)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }

        [StringLength(40)]
        public string Institute { get; set; }
        
        [DisplayName("TransferLetter")]
        public string TransferLetter { get; set; }

        public string SirName { get; set; }
        [StringLength(550)]
        public string ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public virtual tbl_PersonalDetails tbl_PersonalDetails { get; set; }
    }
}
