using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_EntryLife1 : CommanProperties
    {
        [Key]
        public long EntryLifeId { get; set; }

        [Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

        [DisplayName("OnFormation Date")]
        [StringLength(10)]
        public string EntryDate { get; set; }

        [StringLength(500)]
        public string Place { get; set; }

        [StringLength(200)]
        public string Director { get; set; }

        [StringLength(500)]
        public string Minister { get; set; }

        [DisplayName("OnFormator Incharge")]
        [StringLength(200)]
        public string OngoingFormation { get; set; }
        
        [DisplayName("OnFormation Term")]
        [StringLength(500)]
        public string ColName { get; set; }

        [StringLength(35)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public virtual tbl_PersonalDetails tbl_PersonalDetails { get; set; }
    }
}
