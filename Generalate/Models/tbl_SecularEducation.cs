using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_SecularEducation : CommanProperties
    {
        [Key]
        public long SecularId { get; set; }

        //[Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

        [DisplayName("Name")]
        [StringLength(100)]
        public string Name{ get; set; }

        [DisplayName("Degree Name")]
        [StringLength(100)]
        public string DegreeName { get; set; }

        [DisplayName("From Date")]
        [StringLength(10)]
        public string FromDate { get; set; }

        [DisplayName("To Date")]
        [StringLength(10)]
        public string ToDate { get; set; }

        [StringLength(35)]
        public string University { get; set; }

        [StringLength(35)]
        public string Address { get; set; }

        [DisplayName("Class Obtained")]
        [StringLength(35)]
        public string ClassObtained { get; set; }

        [StringLength(35)]
        public string Medium { get; set; }

        [StringLength(300)]
        public string Remarks { get; set; }

        [StringLength(35)]
        public string Title { get; set; }

        [StringLength(35)]
        public string Course { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }
        [DisplayName("Certificate")]
        public string Certificate { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }

        public string SirName { get; set; }


       
    }
}
