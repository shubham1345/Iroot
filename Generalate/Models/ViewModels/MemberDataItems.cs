using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class MemberDataItems
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int FromDate { get; set; }
        public int ToDate { get; set; }
        public string Designation { get; set; }
    }
}