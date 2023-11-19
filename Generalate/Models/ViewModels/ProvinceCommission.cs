using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class ProvinceCommission
    {
        public string Responsibility { get; set; }
        public List<MemberData> MemberData { get; set; }
    }
    public class MemberData
    {
        public string AllMemberName { get; set; }
        public string MemberName { get; set; }
        public string DesignationName { get; set; }
    }
}