using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Generalate.Models.ViewModels;
#pragma warning disable CS0105 // The using directive for 'System' appeared previously in this namespace
using System;
#pragma warning restore CS0105 // The using directive for 'System' appeared previously in this namespace

namespace Generalate.Models
{
    public class tblProvinceImportantDates : CommanProperties
    {
        public tblProvinceImportantDates()
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