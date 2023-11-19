using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class PassedViewModel
    {
        public string Id { get; set; }
        public string ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string Name { get; set; }
        public string SirName { get; set; }
        public string CurrentStatusFor { get; set; }
        public string MemberID { get; set; }
    }
}