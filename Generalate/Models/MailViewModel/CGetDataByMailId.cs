using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.MailViewModel
{
    public class CGetDataByMailId
    {
        public Nullable<long> Slno { get; set; }
        public System.Guid EmailUniqueId { get; set; }
        public Nullable<long> FileSlno { get; set; }
        public Nullable<int> FileCount { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string ToAddress { get; set; }
        public string Admin { get; set; }
        public System.Guid FileUniqueId { get; set; }
        public string attchedfilename { get; set; }
        public byte[] FileContent { get; set; }
        public string FileExtension { get; set; }
        public string FileMIMEtype { get; set; }
        public System.DateTime Filesendtime { get; set; }
    }
}