using Generalate.Models.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generalate.Models
{
    public class SocietyData: CommanProperties
    {
        public SocietyData()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/mm/yyyy");
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
        [StringLength(50)]
        public string SocId { get; set; }
        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }
        [StringLength(50)]
        public string File1 { get; set; }
        [StringLength(50)]
        public string File2 { get; set; }
        [StringLength(50)]
        public string File3 { get; set; }
        [StringLength(50)]
        public string File4 { get; set; }
        [StringLength(50)]
        public string File5 { get; set; }
        [StringLength(50)]
        public string other1 { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
#pragma warning disable CS0108 // 'SocietyData.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'SocietyData.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
    }
}