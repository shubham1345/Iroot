using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tbl_ProvinceGallery : CommanProperties
    {
        public tbl_ProvinceGallery()
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