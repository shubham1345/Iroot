using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Tbl_formationsStatusYear
    {
        [Key]
        public long Id { get; set; }
        public int formationsDetailsId { get; set; }
        public string MemberId { get; set; }
        public string Status { get; set; }
        //public string StatusDate { get; set; }
        public string StatusYear { get; set; }
        public string CreatedDate { get; set; }
              
    }
}