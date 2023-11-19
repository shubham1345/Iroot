using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.ViewModel
{
    public class tbl_OfficialDocViewModel
    {
        public List<data1> DataSet { get; set; }
    }
    public class data1
    {
        public int EditDocId { get; set; }
        public string MemberId { get; set; }
        public string DocType1 { get; set; }
        public HttpPostedFile Document1 { get; set; }
        public string NameAndNo1 { get; set; }
    }
}