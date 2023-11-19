using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class AllGeneralatedata
    {
        public string GeneralateName { get; set; }
        public string FGeneralateName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Country { get; set; }
        public string EmailId { get; set; }
        public string Fax { get; set; }
        public string website { get; set; }
        public List<GenDesignation> GenDesignation { get; set; }
    }
  
    public class GenDesignation
    {
        public string Designation { get; set; }
        public List<GenCouncil> GenCouncil { get; set; }
    }
    public class GenCouncil
    {
        public string ComisMemName { get; set; }
    }
}