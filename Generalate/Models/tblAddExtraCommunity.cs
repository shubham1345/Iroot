
using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tblAddExtraCommunity : CommanProperties
    {
        [Key]
        public long EntryId { get; set; }

        [DisplayName("Name")]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(550)]
        public string UserId { get; set; }
    }
}
