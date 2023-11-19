using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tbl_ComOSInstitute : CommanProperties
    {
        [Key]
        public int id { get; set; }
        public string ComOsId { get; set; }
        public string MyId { get; set; }
        public string ComOsName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string File { get; set; }
#pragma warning disable CS0108 // 'tbl_ComOSInstitute.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'tbl_ComOSInstitute.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string Diocese { get; set; }
        public string ProvinceName { get; set; }
        public string InstName { get; set; }
    }
}