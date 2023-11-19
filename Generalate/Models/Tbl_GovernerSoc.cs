using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_GovernerSoc : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string MyId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        [StringLength(50)]
        public string MobileNo { get; set; }

        [StringLength(550)]
        public string Address { get; set; }

        [StringLength(50)]
        public string PanNo { get; set; }

        [StringLength(50)]
        public string PanDoc { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}