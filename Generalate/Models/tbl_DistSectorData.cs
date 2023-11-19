using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tbl_DistSectorData : CommanProperties
    {
        [Key]
        public int id { get; set; }
        public string DistId { get; set; }
        public string MyId { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
#pragma warning disable CS0108 // 'tbl_DistSectorData.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'tbl_DistSectorData.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        [StringLength(550)]
        public string DistSecName { get; set; }
        public string ActiveCkeck { get; set; }
    }
}