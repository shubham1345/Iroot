using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class DemoTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid id { get; set; }
        [StringLength(50)]
        public string CongId { get; set; }
        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }
        [StringLength(50)]
        public string File1 { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}