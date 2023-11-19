using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Tbl_SubmenuTabs : CommanProperties
    {
        [Key]
        public int SubmenuTabsId { get; set; }

        public string Submenutab_Name { get; set; }

        public string PageViewURL { get; set; }

        public int Submenu_Id { get; set; }
    }
}