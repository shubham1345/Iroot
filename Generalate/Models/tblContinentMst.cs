
using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tblContinentMst : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string ContinentName { get; set; }

        [StringLength(50)]
        public string ContinentName_French { get; set; }
    }
}
