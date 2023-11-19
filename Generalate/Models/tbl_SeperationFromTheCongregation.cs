using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_SeperationFromTheCongregation : CommanProperties
    {
        [Key]
        public long SeperationId { get; set; }

        [Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }
        public string Sapcheck { get; set; }
        [StringLength(256)]
        public string Name { get; set; }
        public string SeperationDate { get; set; }
        public string Title { get; set; }
        public string Describtion { get; set; }
        public string File { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
        [StringLength(10)]
        public string SeperationAge { get; set; }

        public string StageOFFormation { get; set; }
        public string Added_Year { get; set; }

        public virtual tbl_PersonalDetails tbl_PersonalDetails { get; set; }
    }
}
