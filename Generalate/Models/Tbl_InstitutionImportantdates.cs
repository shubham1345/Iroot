using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Generalate.Models.ViewModels;

namespace Generalate.Models
{
    public class Tbl_InstitutionImportantdates:CommanProperties
    {
        public Tbl_InstitutionImportantdates()
        {
            CreatedDate = System.DateTime.Now.ToString("dd/MM/yyyy");

        }

        [key]
        public long Id { get; set; }

        public string MainID { get; set; }

        public string Name { get; set; }

        public int Day { get; set; }
        public int Month { get; set; }
        public Nullable<int> IsActive { get; set; }

    }
}