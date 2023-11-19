using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_GeneralMattersDoc : CommanProperties
    {
        [Key]
        public int GeneralMattersId { get; set; }

        // [Required]
        [StringLength(50)]
        public string DoccumentName { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]

        [DisplayName("File")]
        public string File { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
        //public virtual tbl_GeneralMattersDoc tbl_GeneralMattersDoc { get; set; }
    }
}
