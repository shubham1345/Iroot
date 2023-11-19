using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class AppointmentData : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string DataListName { get; set; }

        [StringLength(150)]
        public string DataListItemName { get; set; }

        [StringLength(150)]
        public string Date { get; set; }

        [StringLength(150)]
        public string FromDate { get; set; }

        [StringLength(150)]
        public string ToDate { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [StringLength(350)]
        public string File { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}