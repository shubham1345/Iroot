using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Generalate.Models.ViewModels
{
    public class AdministratorViewModel
    {
        public long Id { get; set; }
        public string Name{ get; set; }
        public string Title{ get; set; }
        public string Date { get; set; }
        public string Describtion { get; set; }
        public string Doccument { get; set; }
       
    }
}