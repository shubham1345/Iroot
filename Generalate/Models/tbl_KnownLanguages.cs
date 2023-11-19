namespace Generalate.Models
{
    using Generalate.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_KnownLanguages : CommanProperties
    {
        [Key]
        public long KnownLanguagesId { get; set; }

        [Required]
        [DisplayName("Member ID")]
        [StringLength(15)]
        public string MemberID { get; set; }

        [DisplayName("Name")]
        [StringLength(20)]
        public string Name { get; set; }

        [DisplayName("Read")]
        [StringLength(20)]
        public string ToRead { get; set; }

        [DisplayName("Write")]
        [StringLength(20)]
        public string ToWrite { get; set; }

        [DisplayName("Speak")]
        [StringLength(20)]
        public string ToSpeak { get; set; }

        [StringLength(35)]
        public string Spare1 { get; set; }

        [StringLength(35)]
        public string Spare2 { get; set; }

        [StringLength(35)]
        public string Spare3 { get; set; }

        [StringLength(100)]
        public string LanguageName { get; set; }


        [StringLength(100)]
        public string SirName { get; set; }

    }
}
