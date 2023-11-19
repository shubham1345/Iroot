using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{

    public partial class tbl_Socityadd : CommanProperties
    {
        [Key]
        public int SocitydetailsID { get; set; }

        // [Required]
        [StringLength(50)]
        public string Date { get; set; }
       

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Catogery{ get; set; }

        [StringLength(250)]
        public string Remark { get; set; }

        [StringLength(50)]

        [DisplayName("File")]
        public string File { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}
