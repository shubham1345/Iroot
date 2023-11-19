using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_SocietyDetails : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string SocietyName { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }

    }
}