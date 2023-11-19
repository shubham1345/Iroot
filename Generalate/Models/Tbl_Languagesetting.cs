using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Generalate.Models.ViewModels;

namespace Generalate.Models
{
    public class Tbl_Languagesetting
    {
        public Tbl_Languagesetting()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");

        }

        [Key]
        public int Setting_Id { get; set; }

        public string Active { get; set; }
        public string Language_Name { get; set; }
        public int Language_Id { get; set; }
        public string CreatedDate { get; set; }
        public string LanguageCode { get; set; }
    }
}