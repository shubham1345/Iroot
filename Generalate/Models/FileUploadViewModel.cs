using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class FileUploadViewModel
    {
        public HttpPostedFileBase MyImages { get; set; }
        public string Memid { get; set; }
    }
}