using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Tbl_CongrationsData : CommanProperties
    {
        public Tbl_CongrationsData()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        [Key]
        public int id { get; set; }
        public string CongrationId { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
#pragma warning disable CS0108 // 'Tbl_CongrationsData.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        public string CreatedDate { get; set; }
#pragma warning restore CS0108 // 'Tbl_CongrationsData.CreatedDate' hides inherited member 'CommanProperties.CreatedDate'. Use the new keyword if hiding was intended.
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}