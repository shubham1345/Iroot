using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_AverageAge
    {
        [Key]
        public int Age_ID { get; set; }

        public string Average_Age { get; set; }

    }
}