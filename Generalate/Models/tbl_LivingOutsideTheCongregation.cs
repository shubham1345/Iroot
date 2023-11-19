using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_LivingOutsideTheCongregation : CommanProperties
    {
        [Key]
        public long LivingOutsideId { get; set; }

        [Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [DisplayName("From Date")]
        [StringLength(10)]
        public string FromDate { get; set; }

        [DisplayName("To Date")]
        [StringLength(10)]
        public string ToDate { get; set; }

        [StringLength(256)]
        public string Place { get; set; }

        [StringLength(256)]
        public string Purpose { get; set; }

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
