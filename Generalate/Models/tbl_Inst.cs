using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_Inst : CommanProperties
    {
        [Key]
        public int InstitutionId { get; set; }

        [Required]
       
        [StringLength(15)]
        public string INSTID { get; set; }

        [StringLength(256)]
        public string InstName { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }


    }
}
