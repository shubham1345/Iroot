using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_EmergencyContact : CommanProperties
    {
        [Key]
        public long EmergencyContactId { get; set; }

        [Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

       [DisplayName("Name")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Relationship { get; set; }

        [DisplayName("Mobile Number")]
        public string Mobile { get; set; }

        [DisplayName("Landline Number")]
        public string Landline { get; set; }

        [DisplayName("Email ID")]
        [StringLength(200)]
        public string EmailID { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(35)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }

        //TODO Rajesh 
        [StringLength(35)]
        public string SirName { get; set; }

        public virtual tbl_PersonalDetails tbl_PersonalDetails { get; set; }
    }
}
