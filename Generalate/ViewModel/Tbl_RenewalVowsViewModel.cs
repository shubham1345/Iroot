using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.ViewModel
{
    public class Tbl_RenewalVowsViewModel
    {
        public List<data> DataSet { get; set; }
    }

    public class data
    {
        public string ProvinceName { get; set; }
        public string CurrentStatus { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Superior { get; set; }
        public string Duration { get; set; }
        public string Witness { get; set; }
        public string IsChecked { get; set; }
        public string ProFileNo { get; set; }
        public string FileNo { get; set; }
        public string GenFileNo { get; set; }
        public string ArchiveNo { get; set; }
        public string MemberId { get; set; }
        public string GenFilecheck { get; set; }
        public HttpPostedFile FileName { get; set; }
        public string RenewalYear { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}