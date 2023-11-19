using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_Health : CommanProperties
    {
#pragma warning disable CS0649 // Field 'tbl_Health.Id' is never assigned to, and will always have its default value null
        internal static object Id;
#pragma warning restore CS0649 // Field 'tbl_Health.Id' is never assigned to, and will always have its default value null
#pragma warning disable CS0649 // Field 'tbl_Health.id' is never assigned to, and will always have its default value 0
        internal int id;
#pragma warning restore CS0649 // Field 'tbl_Health.id' is never assigned to, and will always have its default value 0

        public tbl_Health()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/mm/yyyy");
        }

        [Key]
        public int HealthId { get; set; }

        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public string Complaint { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        [StringLength(100)]
        public string Diagnosis { get; set; }
        public string Hospital { get; set; }

        [StringLength(100)]
        public string Doctor { get; set; }

        [StringLength(35)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }

        [StringLength(35)]
        public string SirName { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
#pragma warning disable CS0108 // 'tbl_Health.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'tbl_Health.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.

        [StringLength(550)]
        public string ProvinceName { get; set; }

        public virtual tbl_PersonalDetails tbl_PersonalDetails { get; set; }
    }
}
