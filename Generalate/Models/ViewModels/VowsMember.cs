using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class VowsMember
    {
        public string Name { get; set; }
        public string MemberId { get; set; }
        public string ProvinceName { get; set; }
        public string FileNo { get; internal set; }
        public string VowsStatus { get; internal set; }
        public string CurrentCommunity { get; internal set; }
        public string DOB { get; internal set; }
        public string Createdby { get; internal set; }
    }
}