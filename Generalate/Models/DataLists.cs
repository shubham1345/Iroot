using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class DataLists: CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
        public string Name_French { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}