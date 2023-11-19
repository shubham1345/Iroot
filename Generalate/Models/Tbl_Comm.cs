using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_Comm : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string CommunityName { get; set; }
        public string CongregationName { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
#pragma warning disable CS0108 // 'Tbl_Comm.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'Tbl_Comm.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}