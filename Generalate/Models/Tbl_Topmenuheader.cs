using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Generalate.Models.ViewModels;

namespace Generalate.Models
{
    public class Tbl_Topmenuheader:CommanProperties
    {
       [Key]
        public int Header_id { get; set; }

        public string Header_Name { get; set; }



    }
}