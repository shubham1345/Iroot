using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class TemporaryVowsViewModel
    {
        public string ProvinceName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Name { get; set; }
        public string SirName { get; set; }
        public string VowsDate { get; set; }
        public string Status { get; set; }
        public string MemberId { get; set; }
    }
}