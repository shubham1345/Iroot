using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class tbl_Diocese : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string State { get; set; }
        public string DioId { get; set; }
        public string DisSec { get; set; }
        public string DioceseName { get; set; }
        public string ProvinceName { get; set; }
        public string ActiveCkeck { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Place { get; set; }
        public string FileDio { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
    }
}