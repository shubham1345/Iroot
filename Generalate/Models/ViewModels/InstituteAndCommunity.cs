using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class InstituteAndCommunity
    {
        public string State { get; set; }
        public string DioceseName { get; set; }
        public string DioId { get; set; }
        public List<Community> Community { get; set; }
        public int InstCount { get; internal set; }
        public int CommunityCount { get; internal set; }
        public int TotalInstCount { get; internal set; }
        public int TotalCommunityCount { get; internal set; }
    }

    public class Community
    {
        public string CommunityName { get; set; }
        public string CommunityCode { get; set; }
    }

}