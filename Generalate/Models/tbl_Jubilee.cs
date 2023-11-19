using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_Jubilee : CommanProperties
    {
        [Key]
        public int JubileeID { get; set; }

        [Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [DisplayName("Proffession")]
        [StringLength(256)]
        public string Profession { get; set; }

        [DisplayName("First Proffession")]
        [StringLength(10)]
        public string FirstProfession { get; set; }

        [DisplayName("Silver Jubilee")]
        [StringLength(10)]
        public string SilverJubilee { get; set; }

        [DisplayName("Golden Jubilee")]
        [StringLength(10)]
        public string GoldenJubilee { get; set; }

        [DisplayName("Platinum Jubilee")]
        [StringLength(10)]
        public string PlatinumJubilee { get; set; }

        [DisplayName("Diamond Jubilee")]
        [StringLength(10)]
        public string DiamondJubilee { get; set; }

        [DisplayName("Place")]
        [StringLength(50)]
        public string FPPlace { get; set; }

        [DisplayName("Place")]
        [StringLength(50)]
        public string SJPlace { get; set; }

        [DisplayName("Place")]
        [StringLength(50)]
        public string GJPlace { get; set; }

        [DisplayName("Place")]
        [StringLength(50)]
        public string PJPlace { get; set; }

        [DisplayName("Place")]
        [StringLength(50)]
        public string DJPlace { get; set; }

        [StringLength(35)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }

        [StringLength(35)]
        public string SirName { get; set; }
        //public bool IsDeleted { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public virtual tbl_PersonalDetails tbl_PersonalDetails { get; set; }
    }
}
