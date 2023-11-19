using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tbl_Academy : CommanProperties
    {
        [Key]
        public int acaid { get; set; }

        // [Required]
        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string course { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string degree { get; set; }
        [StringLength(50)]
        public string university { get; set; }
        [StringLength(50)]
        public string fromdate { get; set; }
        [StringLength(50)]
        public string todate { get; set; }
        [StringLength(50)]
        public string classo { get; set; }
        [StringLength(50)]
        public string medium { get; set; }
        [StringLength(200)]
        public string adress { get; set; }
        [StringLength(500)]
        public string remark { get; set; }
        public string Description { get; set; }
        public string doc { get; set; }
        [StringLength(50)]
        public string MemberId { get; set; }
        public object Id { get; internal set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}