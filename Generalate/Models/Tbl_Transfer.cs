using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_Transfer : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string OldMemberId { get; set; }
        [StringLength(150)]
        public string BrotherName { get; set; }

        [StringLength(150)]
        public string OldProvinceId { get; set; }
        [StringLength(550)]
        public string OldProvinceName { get; set; }

        public string NewProvinceId { get; set; }
        public string NewProvinceName { get; set; }

        [StringLength(550)]
        public string Extra { get; set; }
        public string NewMemberId { get; set; }
#pragma warning disable CS0108 // 'Tbl_Transfer.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'Tbl_Transfer.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string InsertBy { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string MemberUnicId { get; set; }
    }
}