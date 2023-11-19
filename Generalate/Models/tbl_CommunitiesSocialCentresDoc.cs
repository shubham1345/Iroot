using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_CommunitiesSocialCentresDoc : CommanProperties
    {
        [Key]
        public int CommunityId { get; set; }

        // [Required]
        [StringLength(50)]
        public string CommunityName { get; set; }

        [StringLength(50)]
        public string EstablishDate { get; set; }

        [StringLength(50)]
        public string Place { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(500)]
        public string ContactNumber { get; set; }
        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(50)]

        [DisplayName("File")]
        public string File { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }

        //public virtual tbl_CommunitiesSocialCentresDoc tbl_CommunitiesSocialCentresDoc { get; set; }
    }
}