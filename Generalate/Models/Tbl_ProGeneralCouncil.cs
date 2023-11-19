using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Generalate.Models
{
    public class Tbl_ProGeneralCouncil
    {
        [Key]
        public int ProvGenCouncil_Id { get; set; }
        [StringLength(150)]
        public string GenId { get; set; }
        public string GenName { get; set; }
        [StringLength(150)]
        public string FromDate { get; set; }
        [StringLength(150)]
        public string ToDate { get; set; }
        public string SuperiorGeneral { get; set; }
        public string Designation1 { get; set; }
        public string AsstSuperiorGeneral { get; set; }
        public string Designation2 { get; set; }
        public string CouncillorSprituality { get; set; }
        public string Designation3 { get; set; }
        public string CouncillorFormation { get; set; }
        public string Designation4 { get; set; }
        public string CouncillorEducation { get; set; }
        public string Designation5 { get; set; }
        public string CouncillorSocApo { get; set; }
        public string Designation6 { get; set; }
        public string SecretaryGeneral { get; set; }
        public string Designation7 { get; set; }
        public string BursarGeneral { get; set; }
        public string Designation8 { get; set; }

        public string Name { get; set; }
        public string Designation { get; set; }
        public string Responsibility { get; set; }

        public int DataListItemsId { get; set; }
        public long? PersonalDetailsId { get; set; }
        [StringLength(150)]
        public string ProvinceId { get; set; }
        public string Status { get; set; }
        public string Mandate { get; set; }
        public string MissionCountry { get; set; }
    }
}