using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class CommanProperties
    {
        public CommanProperties()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }
    }
}