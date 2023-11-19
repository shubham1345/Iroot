
namespace Generalate.Models
{
    using Generalate.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class tbl_InstitutionFinal : CommanProperties
    {
        [Key]
        public int InstitutionId { get; set; }

        // [Required]

        public string INSTID { get; set; }


        public string InstName { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }

        public string InstType { get; set; }
    }
}
