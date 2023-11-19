using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Tbl_Complains : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Date { get; set; }
        [StringLength(50)]
        public string MyDate { get; set; }
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Discription { get; set; }

        [StringLength(100)]
        public string NatureofTheComplaint { get; set; }

        [StringLength(100)]
        public string ComplaintReceived { get; set; }

        [StringLength(200)]
        public string Decision { get; set; }

        public string InvolvedIn { get; set; }

        [StringLength(50)]
        public string FileName { get; set; }

        [StringLength(50)]
        public string MemberId { get; set; }

        [StringLength(50)]
        public string MemberName { get; set; }

        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}