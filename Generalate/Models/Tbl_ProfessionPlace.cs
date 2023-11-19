using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Tbl_ProfessionPlace : CommanProperties
    {
        [Key]
        public int Id { get; set; }


        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Name_French { get; set; }

    }
}