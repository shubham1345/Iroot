namespace Generalate.Models
{
    using Generalate.Models.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_OVCDoc : CommanProperties
    {
        [Key]
        public int OvcDocId { get; set; }

        // [Required]
        [StringLength(50)]
        public string DoccumentName { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string Phonenumber { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]

        [DisplayName("File")]
        public string File { get; set; }
        [StringLength(50)]

        [DisplayName("Photo")]
        public string Photo { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
        //public virtual tbl_MinistryDoc tbl_MinistryDoc { get; set; }
    }
}