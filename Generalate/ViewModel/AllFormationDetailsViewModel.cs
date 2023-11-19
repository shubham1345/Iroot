using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Generalate.Controllers;
using Generalate.Models;

namespace Generalate.ViewModel
{
    public class AllFormationDetailsViewModel
    {
        public tbl_PersonalDetails TblPersonelDetails { get; set; }

        public Tbl_formationsDetails TblFormationDetails { get; set; }

        public tbl_Primarydetails TblPrimaryDetails { get; set; }
    }
}