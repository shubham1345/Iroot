using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Generalate.Models.ViewModels;

namespace Generalate.Models
{
    public class tbl_DocumentType : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Name_French { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }
        [StringLength(50)]
#pragma warning disable CS0108 // 'tbl_DocumentType.CreatedBy' hides inherited member 'CommanProperties.CreatedBy'. Use the new keyword if hiding was intended.
        public string CreatedBy { get; set; }
#pragma warning restore CS0108 // 'tbl_DocumentType.CreatedBy' hides inherited member 'CommanProperties.CreatedBy'. Use the new keyword if hiding was intended.

    }
}