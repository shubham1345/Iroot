using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.MailViewModel
{
    public class CGetEmailWithFileCount
    {
        public Nullable<long> Slno { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string ToAddress { get; set; }
        public string Admin { get; set; }
        public System.DateTime Emailsentdate { get; set; }
        public bool IsDeleted { get; set; }
        public System.Guid EmailUniqueId { get; set; }
        public string CCAddress { get; set; }
        public string BCCAddress { get; set; }
        public Nullable<bool> IsImportant { get; set; }
        public Nullable<int> FileCount { get; set; }
    }
}