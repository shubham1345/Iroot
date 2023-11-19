using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_ReligiousEducation : CommanProperties
    {
        [Key]
        public long ReligiousId { get; set; }

        [Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

        [DisplayName("Name")]
        [StringLength(200)]
        public string Name { get; set; }

        [DisplayName("Degree Name")]
        [StringLength(100)]
        public string DegreeName { get; set; }

        [DisplayName("From Date")]
        [StringLength(10)]
        public string FromDate { get; set; }

        [DisplayName("To Date")]
        [StringLength(10)]
        public string ToDate { get; set; }

        [StringLength(300)]
        public string University { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [DisplayName("Class Obtained")]
        [StringLength(35)]
        public string ClassObtained { get; set; }

        [StringLength(35)]
        public string Remarks { get; set; }

        [StringLength(35)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }

        [DisplayName("Certificate")]
        public string Certificate { get; set; }

        //TODO Rajesh
        public string SirName { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }

        public virtual tbl_PersonalDetails tbl_PersonalDetails { get; set; }
    }
}
