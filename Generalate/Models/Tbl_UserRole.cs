using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_UserRole
    {
        [Key]
        public int Userrole_Id { get; set; }

        public string Role_Name { get; set; }
    }
}