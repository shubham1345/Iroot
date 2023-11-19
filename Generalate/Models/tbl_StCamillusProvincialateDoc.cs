using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_StCamillusProvincialateDoc : CommanProperties
    {
        [Key]
        public int StCamillusProvincialateId { get; set; }

        // [Required]
        [StringLength(50)]
        public string DoccumentName { get; set; }
        [StringLength(50)]
        public string SubDoccument { get; set; }
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]

        [DisplayName("File")]
        public string File { get; set; }

        //public virtual tbl_StCamillusProvincialateDoc tbl_StCamillusProvincialateDoc { get; set; }
    }
}