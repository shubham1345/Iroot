using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Generalate.Models
{
    public partial class tbl_Retirement : CommanProperties
    {
        [Key]
        public long RetirementId { get; set; }

        [Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

        [StringLength(256)]
        public string Name { get; set; }
        public string Diedcheck { get; set; }
        public string SapCheck { get; set; }
        public string DOR { get; set; }
        public string Archivecheck { get; set; }
        public string Age { get; set; }

        [StringLength(200)]
        public string Reason { get; set; }

        [StringLength(200)]
        public string Community { get; set; }

        [StringLength(75)]
        public string Remarks { get; set; }

        [StringLength(35)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }

        [StringLength(35)]
        public string SirName { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
        public virtual tbl_PersonalDetails tbl_PersonalDetails { get; set; }
    }
}
