using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Generalate.Models
{
    public partial class tbl_Bank_Details : CommanProperties
    {
        [Key]
        public long BankId { get; set; }

        [DisplayName("BankName")]
        [StringLength(100)]
        public string BankName { get; set; }

        [DisplayName("AccNum")]
        [StringLength(100)]
        public string AccNum { get; set; }

        [DisplayName("IFCS")]
        [StringLength(10)]
        public string IFCS { get; set; }

        [DisplayName("Branch")]
        [StringLength(10)]
        public string Branch { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}
