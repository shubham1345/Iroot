using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class tbl_DioceseInst : CommanProperties
    {
        [Key]
        public int id { get; set; }
        public string DioId { get; set; }
        public string MyId { get; set; }
        public string DioName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string File { get; set; }
#pragma warning disable CS0108 // 'tbl_DioceseInst.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'tbl_DioceseInst.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string ProvinceName { get; set; }
        public string InstName { get; set; }
    }
}