using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.ViewModel
{
    public class GetTotalCountByProvinceViewModel
    {
        public int TotalMember { get; set; }
        public int TotalIns { get; set; }
        public int TotalPro { get; set; }
        public int TotalSoc { get; set; }
        public int TotalRet { get; set; }
        public int TotalCom { get; set; }
        public int DepartedRecord { get; set; }
        public int TotalTrust { get; set; }
        public int AllPerpetualProfession { get; set; }
        public int AllDeparted { get; set; }
        public int DeathRecord { get; set; }
        public int TotalNovandPP { get; set; }
        public int TotalArchive { get; internal set; }
        public int TotalVowsRenewal { get; internal set; }
        public int TotalEnterToNov { get; internal set; }
    }
}