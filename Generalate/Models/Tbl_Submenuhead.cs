using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Generalate.Models.ViewModels;

namespace Generalate.Models
{
    public class Tbl_Submenuhead:CommanProperties
    {
        [Key]
        public int Submenu_Id { get; set; }

        public string Submenu_Name { get; set; }

        public int Topmenu_Id { get; set; }

        public string Topmenu_Name { get; set; }

        public string Page_name { get; set; }

        public string File_Name { get; set; }

    }
}