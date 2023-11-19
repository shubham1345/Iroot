using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_Entry : CommanProperties
    {
        [Key]
        public long EntryId { get; set; }

        [Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

        [DisplayName("Name")]
        [StringLength(200)]
        public string Name { get; set; }

        [DisplayName("Date")]
        [StringLength(10)]
        public string DateOfBaptism { get; set; }

        [DisplayName("Name")]
        [StringLength(200)]
        public string ChurchName1 { get; set; }

        [DisplayName("Minister/Prelate")]
        [StringLength(500)]
        public string Minister1 { get; set; }

        [DisplayName("ChristianLife")]
        [StringLength(500)]
        public string Place1 { get; set; }

        [DisplayName("Date Of Confirmation")]
        [StringLength(10)]
        public string DateOfConfirmation { get; set; }

        [DisplayName("Church Name/Place")]
        [StringLength(200)]
        public string ChurchName2 { get; set; }

        [DisplayName("Date Of Ordination")]
        [StringLength(500)]
        public string Minister2 { get; set; }

        [DisplayName("Place Of Ordination")]
        [StringLength(500)]
        public string Place2 { get; set; }

        [StringLength(35)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }

        //TODO Rajesh

        [StringLength(35)]
        public string SirName { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}
