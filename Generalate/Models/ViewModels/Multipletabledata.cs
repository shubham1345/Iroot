using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class Multipletabledata
    {
        public Tbl_Cong communityList { get; set; }
        public ComHouse communityHouse { get; set; }
        public ComOutSide communityOutside { get; set; }
    }
}