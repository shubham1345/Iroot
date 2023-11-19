using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Tbl_RenewalVows : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string MyId { get; set; }
        public string FileNo { get; set; }
        [StringLength(50)]
        public string MemberId { get; set; }
        public string Archivecheck { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Superior { get; set; }

        [StringLength(550)]
        public string Duration { get; set; }

        [StringLength(50)]
        public string Witness { get; set; }

        [StringLength(50)]
        public string RenVowsDoc { get; set; }

        [StringLength(50)]
        public string Check { get; set; }

        [StringLength(50)]
        public string CurrentStatus { get; set; }
        public string DeathCheck { get; set; }
        public string SapCheck { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }

        [StringLength(50)]
        public string RenewalYear { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}