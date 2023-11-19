using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_ServiceInTheCongregation : CommanProperties
    {
        [Key]
        public long ServiceId { get; set; }

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

        [StringLength(1024)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Community { get; set; }

        [StringLength(50)]
        public string Office { get; set; }

        [StringLength(150)]
        public string Other { get; set; }

        [DisplayName("Superior Name")]
        [StringLength(100)]
        public string superiorName { get; set; }

        [DisplayName("Email ID")]
        [StringLength(200)]
        public string EmailId { get; set; }

        [StringLength(35)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }

        [DisplayName("TransferLetter")]
        public string Certificate { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }

        public virtual tbl_PersonalDetails tbl_PersonalDetails { get; set; }
    }
}
