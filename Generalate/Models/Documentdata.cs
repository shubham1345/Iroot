using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Documentdata
    {
      //  public int ID { get; set; }
        public string ID { get; set; }
        public string CommunityName { get; set; }
        public string Place { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string DocumentCategory { get; set; }
        public string DocumentSubCategory { get; set; }
        public string Year { get; set; }
        public HttpPostedFileBase[] files { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
    }
}
//--CommunityName
//--Place
//--State
//--City
//--District
//--DocumentCategory
//--DocumentSubCategory
//--Year
