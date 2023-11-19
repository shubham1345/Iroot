﻿using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public partial class tbl_FinancialReportDoc : CommanProperties
    {
        [Key]
        public int FinancialReportId { get; set; }

        // [Required]
        [StringLength(50)]
        public string DoccumentName { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]

        [DisplayName("File")]
        public string File { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        //public virtual tbl_FinancialReportDoc tbl_FinancialReportDoc { get; set; }
    }
}