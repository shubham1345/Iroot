using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class ComHouse : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string CommunityName { get; set; }
        public string CommunityCode { get; set; }
        public string ActiveCkeck { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public string OtherProvince { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string EmailId { get; set; }
        public string DisSec { get; set; }
        public string File { get; set; }
        public string MyId { get; set; }
        public string Activities { get; set; }
        public string Diocese { get; set; }
    }
}