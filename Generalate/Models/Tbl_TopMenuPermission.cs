using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Generalate.Models.ViewModels;

namespace Generalate.Models
{
    public class Tbl_TopMenuPermission : CommanProperties
    {
        [Key]
        public int TopMenu_Id { get; set; }

        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string PageName { get; set; }
        public bool HasPermission { get; set; }
        public string PageViewName { get; set; }
        public int ParentId { get; set; }
        public int TopMenuHeader_Id { get; set; }
        public string CreatePageview { get; set; }
        public string EditPageview { get; set; }
        public string DeletePageview { get; set; }
        public string ViewPageview { get; set; }
        public bool Createpermission { get; set; }
        public bool Editpermission { get; set; }
        public bool Deletepermission { get; set; }
        public bool Viewpermission { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
    }

    public class Tbl_RolePermission : CommanProperties
    {
      

        public string TagName { get; set; }
        public string Url { get; set; }
       
        
    }

}