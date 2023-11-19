using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class tbl_DioceseData : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string DioId { get; set; }
        public string DioceseName { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
    }
}