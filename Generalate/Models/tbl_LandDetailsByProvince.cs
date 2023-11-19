using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class tbl_LandDetailsByProvince : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string DioId { get; set; }
        public string MyId { get; set; }
        public string LandType { get; set; }
        public string PCIId { get; set; }
        public string DocumentType { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string File { get; set; }
#pragma warning disable CS0108 // 'tbl_LandDetailsByProvince.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'tbl_LandDetailsByProvince.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string ProvinceName { get; set; }
        public string ParishName { get; set; }
    }
}