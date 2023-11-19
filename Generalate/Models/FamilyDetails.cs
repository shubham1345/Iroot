using Generalate.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Generalate.Models
{
    public class FamilyDetails : CommanProperties
    {
        [Key]
        public int Id { get; set; }
        public string MemberId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string MemberName { get; set; }
        [StringLength(50)]
        public string Relationship { get; set; }
        [StringLength(50)]
        public string YearOfBirth { get; set; }
        [StringLength(50)]
        public string YearOfDeath { get; set; }
        [StringLength(50)]
        public string Mobile { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(150)]
        public string EmergencyContact { get; set; }
        [StringLength(550)]
        public string ProvinceName { get; set; }
        public string FamilyNationality { get; set; }
        public string FamilyProfession { get; set; }
        public string FamilyRemarks { get; set; }
        public string Country { get; set; }
        public string Nationality { get; set; }
        public string LangSpocken { get; set; }
    }
}
 