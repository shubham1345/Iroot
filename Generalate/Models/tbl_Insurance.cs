using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class tbl_Insurance : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Minister { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string Premium { get; set; }

        [StringLength(50)]
        public string Ammount { get; set; }

        [StringLength(50)]
        public string MemberId { get; set; }

        [StringLength(50)]
        public string File { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}