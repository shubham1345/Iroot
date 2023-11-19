using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tbl_OfficialDocument : CommanProperties
    {
        [Key]

        public int Id { get; set; }
        public string MemberId { get; set; }
        public string DocType1 { get; set; }
        public string NameAndNo1 { get; set; }
        public string Document1 { get; set; }
        public string DocType2 { get; set; }
        public string NameAndNo2 { get; set; }
        public string Document2 { get; set; }
    }
}