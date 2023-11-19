using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Tbl_FormationTypes : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FortmationType { get; set; }
    }
}