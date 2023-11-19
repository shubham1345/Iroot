using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generalate.Models
{

    public partial class tbl_PersonalDetails : CommanProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PersonalDetailsId { get; set; }

        
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }
        public string GenFilecheck { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string Archivecheck { get; set; }
        [DisplayName("PAN Number")]
        [StringLength(200)]
        public string NameBaptismial { get; set; }

        [DisplayName("Email ID")]
        [StringLength(200)]
        public string EmailID { get; set; }

        [DisplayName("SurName")]
        [StringLength(200)]
        public string SirName { get; set; }

        public byte[] Image { get; set; }

        [StringLength(100)]
        public string MotherTongue { get; set; }

        [DisplayName("Mobile Number")]
        public string Mobile { get; set; }

        [StringLength(20)]
        public string BloodGroup { get; set; }
        public string Birthday { get; set; }
        public string Diedcheck { get; set; }
        public string Sapcheck { get; set; }
        public string CurrentStatus { get; set; }
        public string Vowscheck { get; set; }
        public string VowsStatus { get; set; }
        public string CurrentCommunity { get; set; }
        public string ProvinceCode { get; set; }
        [DisplayName("DOB")]
        [StringLength(50)]
        public string DOB { get; set; }
        [DisplayName("FeastDays")]

        [StringLength(10)]
        public string FeastDays { get; set; }

        [DisplayName("Village/Town")]
        [StringLength(100)]
        public string VillageTown { get; set; }

        [StringLength(100)]
        public string District { get; set; }

        [StringLength(100)]
        public string State { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        public string Pincode { get; set; }

        [DisplayName("MemberID")]
        public string AadharNo { get; set; }

        [DisplayName("Name as in AadharCard")]
        [StringLength(50)]
        public string NameasinAadharCard { get; set; }

        [DisplayName("Father's Name")]
        [StringLength(200)]
        public string FatherName { get; set; }

        [DisplayName("Father's Mobile Number")]
        public string FMobile { get; set; }

        [DisplayName("Mother's Name")]
        [StringLength(200)]
        public string MotherName { get; set; }

        [DisplayName("Mother's Mobile Number")]
        public string MMobile { get; set; }

        [DisplayName("No of Brother")]
        public string NoOfBrother { get; set; }

        [DisplayName("Number of Sister")]
        public string NoOfSister { get; set; }

        [DisplayName("Place in the Family")]
        public string PlaceintheFamily { get; set; }

        [StringLength(256)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [Display(Name = "Uploaded File")]
        [StringLength(256)]
        public string Spare3 { get; set; }

        [StringLength(256)]
        public string Parish1 { get; set; }

        [DisplayName("Father's Baptismial Name")]
        [StringLength(256)]
        public string FBaptism { get; set; }

        [DisplayName("Mother's Baptismial Name")]
        [StringLength(256)]
        public string MBaptism { get; set; }

        [StringLength(50)]
        public string FileNo { get; set; }
        public bool IsDeleted { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public string GenFileNo { get; set; }
        public string IsTransfer { get; set; }
        public string MemberUnicId { get; set; }

    }
}
