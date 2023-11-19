using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Generalate.Models.ViewModels;

namespace Generalate.Models
{
    public class Tbl_Languages: CommanProperties
    {
        [Key]
        public int Lnaguage_Id { get; set; }

        public string Language_Name { get; set; }
    }
}