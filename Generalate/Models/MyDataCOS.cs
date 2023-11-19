using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class MyDataCOS : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string ComId { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string File1 { get; set; }
        public string File2 { get; set; }
        public string other1 { get; set; }
        public string ProvinceName { get; set; }
    }
}