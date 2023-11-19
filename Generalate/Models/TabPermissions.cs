using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class TabPermissions : CommanProperties
    {

        [Key]
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string TabName { get; set; }
        public string TabViewName { get; set; }
        public int TabId { get; set; }
        public string provinceId { get; set; }
        public string IsPermission { get; set; }
    }
}