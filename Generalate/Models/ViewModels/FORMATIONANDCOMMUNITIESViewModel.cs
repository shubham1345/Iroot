using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class FORMATIONANDCOMMUNITIESViewModel
    {
        public string Place { get; set; }
        public string CommunityName { get; set; }
        public string CommunityCode { get; set; }
        public string ComAddress { get; set; }
        public string ComEmailId { get; set; }
        public string ComPhone { get; set; }
        public List<BrothersData> BrotherData { get; set; }
    }
    public class BrothersData
    {
        public string MemberId { get; set; }
        public string Knowname { get; set; }
        public string SurName { get; set; }
        public string mobilenumber { get; set; }
        public string emailid { get; set; }
        public string DesignationType { get; set; }
    }
    
}