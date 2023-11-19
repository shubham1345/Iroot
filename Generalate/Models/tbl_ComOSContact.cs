using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class tbl_ComOSContact : CommanProperties
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
        public string Date { get; set; }
        public string ProvinceName { get; set; }
        public string MemberName { get; set; }
        public string Types { get; set; }
    }
}