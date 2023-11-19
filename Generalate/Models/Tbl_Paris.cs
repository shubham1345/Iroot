using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Tbl_Paris : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(50)]
        public string MyId { get; set; }

        [StringLength(50)]
        public string YearOfEstablacement { get; set; }

        [StringLength(50)]
        public string ParisName { get; set; }

        [StringLength(50)]
        public string Place { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Tial { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(500)]
        public string FileName { get; set; }

        [StringLength(50)]
#pragma warning disable CS0108 // 'Tbl_Paris.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'Tbl_Paris.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.

        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}