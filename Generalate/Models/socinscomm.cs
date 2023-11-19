using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class socinscomm
    {
        public int MemberId { get; set;}
        public int PanNumber { get; set; }
        public int NameOfTheSocity { get; set; }
        public int FCRANumber { get; set; }
        public int Date { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}