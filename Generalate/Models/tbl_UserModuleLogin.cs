using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class tbl_UserModuleLogin : CommanProperties
    {
        [Key]
        public int LoginId { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        public string UserPassword { get; set; }

        [DisplayName("Role")]
        public string UserRole { get; set; }

        public string Spare1 { get; set; }

        public string Spare2 { get; set; }

        public string Spare3 { get; set; }

    }
}