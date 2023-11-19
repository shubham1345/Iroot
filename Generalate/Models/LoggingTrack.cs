using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class LoggingTrack: CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string LoggingTime{ get; set; }
        public string LoginLogout{ get; set; }
        public string LoginId{ get; set; }
    }
}