using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class DistSector
    {

        public string DistName { get; set; }
        public List<CommunityData> CommunityData { get; set; }
    }
    public class CommunityData
    {
        public string Place { get; set; }
        public string CommunityName { get; set; }
        public string CommunityCode { get; set; }
        public string ComAddress { get; set; }
        public string ComEmailId { get; set; }
        public string ComPhone { get; set; }
    }
}