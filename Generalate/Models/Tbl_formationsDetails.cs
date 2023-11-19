using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_formationsDetails : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        // [Required]
        [StringLength(50)]
        public string StageOfFormation { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(350)]
        public string Community { get; set; }
        [StringLength(50)]
        public string FromDate { get; set; }
        public string VowsDate { get; set; }
        public string Diedcheck { get; set; }
        public string Sapcheck { get; set; }
        public string Archivecheck { get; set; }
        public string CurrentStatus { get; set; }
        [StringLength(50)]
        public string ToDate { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Institution { get; set; }
        [StringLength(50)]
        public string Superior { get; set; }
        [StringLength(50)]
        public string Formators { get; set; }
        [StringLength(50)]
        public string Novisemaster { get; set; }
         
        public string Place { get; set; }
        [StringLength(50)]
        public string Receivedby { get; set; }
        [StringLength(50)]
        public string Conferredby { get; set; }
        [StringLength(50)]
        public string VocationFacilitator { get; set; }

        [StringLength(50)]
        public string MemberId { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public bool IsDeleted { get; set; }
        public string Celebrity { get; set; }
        public string Status { get; set; }
        public string Country { get; set; }
    }
}
