using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Sacraments : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Sacrament { get; set; }

        [StringLength(50)]
        public string Minister { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string ChurchName { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(50)]
        public string MemberId { get; set; }

        [StringLength(350)]
        public string File { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public string Diocese { get; set; }
    }
}