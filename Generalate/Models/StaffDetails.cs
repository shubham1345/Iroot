using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class StaffDetails : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string StaffNameName { get; set; }
        public string MyId { get; set; }
        public string EnterbyId { get; set; }
        public string Enterby { get; set; }
        public string EnterbyName { get; set; }
        public string StaffDOB { get; set; }
        public string Gender { get; set; }
        public string Qualificatiion { get; set; }
        public string Designation { get; set; }
        public string File { get; set; }
        public string IdNo { get; set; }
    }
}