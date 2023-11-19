using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Generalate.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class tblUserDynamicConfiguration : CommanProperties
    {
        [Key]
        public int Mainid { get; set; }

        public string ListType { get; set; }
        public string ListData { get; set; }
        public string CurrentUser { get; set; }
    }
}

