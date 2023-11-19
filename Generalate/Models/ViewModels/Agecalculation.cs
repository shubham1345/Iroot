using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class Agecalculation
    {
        //public List <OldBrothers> OldBrothers { get; set; }
        //public List <YoungBrothers> YoungBrothers { get; set; }
        public string YoungBrother { get; internal set; }
        public string OldBrother { get; internal set; }
        public int Average { get; internal set; }
        public int Year { get; internal set; }
    }
    //public class OldBrothers
    //{
    //    public string OldBrother { get; internal set; }
    //}
    //public class YoungBrothers
    //{
    //    public string YoungBrother { get; internal set; }
    //}

}