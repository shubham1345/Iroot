using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Claustration
    {
        [Key]
        public string Id { get; set; }
        public string MemberId { get; set; }
        public string ClaustrationFromDate { get; set; }
        public string ClaustrationToDate { get; set; }
        public string ClaustrationPurpose { get; set; }
        public string ClaustrationPlace { get; set; }
        public string ClaustrationCommunity { get; set; }
        public string Claustrationdecree { get; set; }
        public string ClaustrationMotivation { get; set; }
        public string ClaustrationStatus { get; set; }
        public string ClaustrationRemarks { get; set; }
        public string CreatedBy { get; set; }
    }
}