using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class GeneralateFileNo : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string ProFileNo { get; set; }
        public string GenFileNo { get; set; }
        public string GenFilecheck { get; set; }
    }
}