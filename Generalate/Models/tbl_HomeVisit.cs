using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class tbl_HomeVisit : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Purpose { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string TransferLetter { get; set; }
        public string ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
}