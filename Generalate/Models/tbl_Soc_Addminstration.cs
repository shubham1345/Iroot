using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial  class tbl_Soc_Addminstration : CommanProperties

    {

        [Key]
        public int SocityAdministrationId { get; set; }

        // [Required]
        [StringLength(50)]
        public string SocityName { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string RegNo { get; set; }

        [StringLength(50)]
        public string PanNo { get; set; }

        [StringLength(500)]
        public string FCRANo { get; set; }

        [StringLength(50)]
        public string ANo { get; set; }


        [StringLength(50)]
        public string GNo { get; set; }


        [StringLength(50)]
        public string Spare { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}