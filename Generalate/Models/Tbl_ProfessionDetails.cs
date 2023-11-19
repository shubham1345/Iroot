using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class Tbl_ProfessionDetails : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string DataListName { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Name_French { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        [StringLength(50)]
        public string Institution { get; set; }
        public string FormationId { get; set; }
        [StringLength(50)]
        public string Community { get; set; }
        public string Continent { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public int intRank { get; set; }
    }
}