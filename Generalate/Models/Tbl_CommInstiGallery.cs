using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Generalate.Models.ViewModels;

namespace Generalate.Models
{
    public class Tbl_CommInstiGallery:CommanProperties
    {
        public Tbl_CommInstiGallery()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");

        }

        [key]
        public long Id { get; set; }
        public string MainID { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public Nullable<int> IsActive { get; set; }


    }
}