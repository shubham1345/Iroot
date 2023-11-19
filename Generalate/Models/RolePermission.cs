using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class RolePermission : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string PageName { get; set; }
        public bool HasPermission { get; set; }
        public string PageViewName { get; set; }
        public int ParentId { get; set; }

        public string Items { get; set; }
        public string adminRole { get; set; }
        public string userRole { get; set; }
        public string permission { get; set; }
       
    }
}