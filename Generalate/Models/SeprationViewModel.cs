using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class SeprationViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Describtion { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}