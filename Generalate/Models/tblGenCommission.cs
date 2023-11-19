using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tblGenCommission : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string GenId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string MemberName { get; set; }
        public string DesignationName { get; set; }
        public string ResponsibilityName { get; set; }
        public string Status { get; set; }
        public string ManDate { get; set; }
    }
}