using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class tbl_DistSecCouncil : CommanProperties
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string DistSecNameName { get; set; }
        public string MemberName { get; set; }
        public string DesignationName { get; set; }
        public string ResponsibilityName { get; set; }
        [StringLength(150)]
        public string DistSecId { get; set; }

        [StringLength(150)]
        public string Superior { get; set; }
        [StringLength(150)]
        public string SuperiorDes { get; set; }

        [StringLength(150)]
        public string AssSuperior { get; set; }
        [StringLength(150)]
        public string AssSuperiorDes { get; set; }

        [StringLength(150)]
        public string CouncilorName { get; set; }

        [StringLength(150)]
        public string CouncilorDes { get; set; }

        [StringLength(150)]
        public string CouncilorName1 { get; set; }
        [StringLength(150)]
        public string Councilor1Des { get; set; }

        [StringLength(150)]
        public string CouncilorName2 { get; set; }
        [StringLength(150)]
        public string Councilor2Des { get; set; }

        [StringLength(150)]
        public string CouncilorName3 { get; set; }
        [StringLength(150)]
        public string Councilor3Des { get; set; }

        [StringLength(150)]
        public string FromDate { get; set; }
        [StringLength(150)]
        public string ToDate { get; set; }

        [StringLength(150)]
        public string ComMemName { get; set; }
        [StringLength(150)]
        public string ComMemDes { get; set; }

        [StringLength(150)]
        public string ComMemName1 { get; set; }
        [StringLength(150)]
        public string ComMemDes1 { get; set; }

        [StringLength(150)]
        public string ComMemName2 { get; set; }
        [StringLength(150)]
        public string ComMemDes2 { get; set; }

        [StringLength(150)]
        public string Secretory { get; set; }
        [StringLength(150)]
        public string SecretoryDes { get; set; }

        [StringLength(150)]
        public string Bursar { get; set; }
        [StringLength(150)]
        public string BursarDes { get; set; }

        public string History { get; set; }
    }
}