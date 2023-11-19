using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_Calender : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string GenName { get; set; }
        public string GenId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Event { get; set; }
        public string ProvinceName { get; set; }
    }
}