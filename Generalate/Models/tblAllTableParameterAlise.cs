using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Generalate.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class tblAllTableParameterAlise : CommanProperties
    {

        [Key]
        public int Id { get; set; }
        public string TableName { get; set; }
        public string ParameterName { get; set; }
        public string AliasName { get; set; }
        public string FrenchName { get; set; }
        public string PageCode { get; set; }
        public int IsShow { get; set; }
    }
}