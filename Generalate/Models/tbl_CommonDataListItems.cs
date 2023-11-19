using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_CommonDataListItems : CommanProperties
    {
        [Key]
        public int CDLITId { get; set; }

        [StringLength(500)]
        public string DataListName { get; set; }

        [StringLength(500)]
        public string DataListItemName { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [StringLength(35)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}
