using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_FinancialGuidelineDoc : CommanProperties
    {
        [Key]
        public int FinancialDocId { get; set; }

        // [Required]
        [StringLength(50)]
        public string DoccumentName { get; set; }
       

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string Phonenumber { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]

        [DisplayName("File")]
        public string File { get; set; }
        [StringLength(50)]

        [DisplayName("Photo")]
        public string Photo { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        //public virtual tbl_MinistryDoc tbl_MinistryDoc { get; set; }
    }
}