using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_UserLogins : CommanProperties
    {
        public Tbl_UserLogins()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserPassword { get; set; }
    
        public string UserRole { get; set; }

        public string Spare1 { get; set; }
        public string Spare2 { get; set; }
        public string Spare3 { get; set; }

        public string EncrptedInfo { get; set; }
        public string EncrptedInfoFile { get; set; }
        public string LoginUserName { get; set; }
#pragma warning disable CS0108 // 'Tbl_UserLogins.CreatedBy' hides inherited member 'CommanProperties.CreatedBy'. Use the new keyword if hiding was intended.
        public string CreatedBy { get; set; }
#pragma warning restore CS0108 // 'Tbl_UserLogins.CreatedBy' hides inherited member 'CommanProperties.CreatedBy'. Use the new keyword if hiding was intended.
#pragma warning disable CS0108 // 'Tbl_UserLogins.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'Tbl_UserLogins.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string MemberId { get; set; }
        public string IsActive { get; set; }        
    }
}