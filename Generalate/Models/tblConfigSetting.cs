
using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tblConfigSetting : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        public string strConfigKey { get; set; }
        public string strConfigValue { get; set; }
        public string strPurpose { get; set; }
    }
}