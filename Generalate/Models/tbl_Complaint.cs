using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Generalate.Models
{
    public partial class tbl_Complaint : CommanProperties
    {
        [Key]
        public int ComplaintID { get; set; }

        [Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [DisplayName("Complaint From")]
        [StringLength(70)]
        public string ComplaintFrom { get; set; }

        [DisplayName("Complaint Date")]
        public string ComplaintDATE { get; set; }

        [DisplayName("Complaint Nature")]
        [StringLength(700)]
        public string ComplaintNATURE { get; set; }

        [DisplayName("Decesion")]
        [StringLength(300)]
        public string Decesion { get; set; }
        
        public string Document { get; set; }

        [StringLength(255)]
        public string Spare1 { get; set; }

        [StringLength(352)]
        public string Spare2 { get; set; }

        [Display(Name = "UploadDocFiles")]
        [StringLength(350)]
        public string Spare3 { get; set; }

        [StringLength(50)]
        public string SirName { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}
