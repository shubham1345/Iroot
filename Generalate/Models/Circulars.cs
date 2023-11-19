using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Circulars : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public string Date { get; set; }
        public string Date2 { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string File { get; set; }
        public string GenFilecheck { get; set; }
    }
}