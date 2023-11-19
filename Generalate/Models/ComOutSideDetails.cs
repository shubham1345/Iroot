using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class ComOutSideDetails : CommanProperties
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public string ComId { get; set; }
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
    }
}